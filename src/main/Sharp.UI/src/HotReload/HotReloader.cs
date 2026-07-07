using System.IO.Pipes;
using System.Reflection;
using Microsoft.Maui.HotReload;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Diagnostics;
using Microsoft.Maui.Graphics;

namespace Sharp.UI
{
    public interface ISharpUIContent
    {
        void Rebuild();
    }

    public static class HotReloader
    {
        private static readonly List<WeakReference<ISharpUIContent>> _content = new();
        private static readonly object _lock = new();

        public static void Register(ISharpUIContent content)
        {
            lock (_lock)
            {
                _content.RemoveAll(w => !w.TryGetTarget(out _));
                _content.Add(new WeakReference<ISharpUIContent>(content));
            }
        }

        public static void RebuildAll(Type[] updatedTypes)
        {
            List<ISharpUIContent> alive;
            lock (_lock)
            {
                alive = _content
                    .Select(w => w.TryGetTarget(out var p) ? p : null)
                    .Where(p => p is not null)
                    .Cast<ISharpUIContent>()
                    .ToList();
            }

            foreach (var page in alive)
            {
                var affected = updatedTypes is null
                    || updatedTypes.Any(t => t.IsInstanceOfType(page));

                if (!affected) continue;

                try
                {
                    page.Rebuild();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Hot reload rebuild failed: {ex}");
                }
            }
        }
    }
}