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
    public interface IHotReloadable
    {
        public void Reload();

        public void InitializeSharpUI()
        {
            this.Reload();
            if (this is Element) HotReloader.Register(this as Element);
        }
    }

    public static class HotReloader
    {
        private static readonly List<WeakReference<Element>> _elements = new();
        private static readonly object _lock = new();

        public static void Register(Element content)
        {
            lock (_lock)
            {
                _elements.RemoveAll(w => !w.TryGetTarget(out _));
                _elements.Add(new WeakReference<Element>(content));
            }
        }

        private static IHotReloadable FindHotReloadable(Element element)
        {
            if (element == null)
                return null;

            if (element is IHotReloadable)
                return element as IHotReloadable;

            return FindHotReloadable(element.Parent);
        }

        public static void RebuildAll(Type[] updatedTypes)
        {
            if (updatedTypes is null || updatedTypes.Length == 0)
            {
                System.Diagnostics.Debug.WriteLine("Hot reload rebuild: no updated types provided.");
                return;
            }

            List<Element> alive;
            lock (_lock)
            {
                alive = _elements
                    .Select(w => w.TryGetTarget(out var v) ? v : null)
                    .Where(v => v is not null)
                    .Cast<Element>()
                    .ToList();
            }

            HashSet<IHotReloadable> affectedSet = new();

            foreach (var element in alive)
            {
                var isAffected = updatedTypes.Any(t => t.IsInstanceOfType(element));
                if (isAffected)
                {
                    var hotReloadable = FindHotReloadable(element);
                    if (hotReloadable is not null)
                        affectedSet.Add(hotReloadable);
                }
            }

            foreach (var affected in affectedSet)
            {
                try
                {
                    affected.Reload();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Hot reload rebuild failed: {ex}");
                }
            }
        }
    }
}