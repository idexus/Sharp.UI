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

        private static ContentPage FindContentPage(Element element)
        {
            if (element == null)
                return null;

            if (element is ContentPage)
                return element as ContentPage;

            return FindContentPage(element.Parent);
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

            HashSet<ContentPage> affectedPages = new();

            foreach (var view in alive)
            {
                var affected = updatedTypes.Any(t => t.IsInstanceOfType(view));
                if (affected)
                {
                    var page = FindContentPage(view);
                    if (page is not null)
                        affectedPages.Add(page);
                }
            }

            foreach (var page in affectedPages)
            {
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