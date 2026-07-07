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
    public static class HotReloader
    {
        private static readonly List<WeakReference<Sharp.UI.ContentPage>> _pages = new();
        private static readonly object _lock = new();

        public static void Register(Sharp.UI.ContentPage page)
        {
            lock (_lock)
            {
                _pages.RemoveAll(w => !w.TryGetTarget(out _));
                _pages.Add(new WeakReference<Sharp.UI.ContentPage>(page));
            }
        }

        public static void RebuildAll(Type[] updatedTypes)
        {
            List<Sharp.UI.ContentPage> alive;
            lock (_lock)
            {
                alive = _pages
                    .Select(w => w.TryGetTarget(out var p) ? p : null)
                    .Where(p => p is not null)
                    .Cast<Sharp.UI.ContentPage>()
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