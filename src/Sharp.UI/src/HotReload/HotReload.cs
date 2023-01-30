using System.IO.Pipes;
using System.Reflection;
using Microsoft.Maui.HotReload;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

namespace Sharp.UI
{
    class HotReloadToken
    {
        public string Token { get; set; }
    }

    class HotReloadRequest
    {
        public string[] TypeNames { get; set; }
    }

    class HotReloadData
    {
        public string[] TypeNames { get; set; }
        public byte[] AssemblyData { get; set; }
        public byte[] PdbData { get; set; }
    }

    public static partial class HotReload
    {
        static internal IPAddress[] IdeIPs;
        static List<ContentPage> registeredActivePages = new List<ContentPage>();

        internal static Dictionary<string, Type> ReplacedTypesDict = new Dictionary<string, Type>();

        // --------- public -----------

        public static void UpdateApplication(Type[] types)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var type in types)
                    ReplacedTypesDict[type.FullName] = type;
                InvokeHotReload();
            });
        }

        public static void ReplaceWithType(Type type)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ReplacedTypesDict[type.FullName] = type;
            });
        }

        public static void TriggerHotReload()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                InvokeHotReload();
            });
        }

        // ------------ internal/private -----------

        internal static void RegisterActive(ContentPage page)
        {
            registeredActivePages.Add(page);
        }

        public static ValueTask WriteAsync<T>(this NetworkStream stream, T obj, CancellationToken cancellationToken = default)
        {
            var jsonString = JsonSerializer.Serialize(obj);
            jsonString += "\0";
            var messageBytes = Encoding.UTF8.GetBytes(jsonString);
            return stream.WriteAsync(messageBytes, cancellationToken);
        }

        internal static void InitSharpUIHotReload<T>()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {                     
                        var pipeName = typeof(T).GetTypeInfo().Assembly.GetName().Name;

                        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut))
                        {
                            await pipeServer.WaitForConnectionAsync();

                            // ------- reequest types ---------

                            var requestedTypeNames = registeredActivePages
                                    .Select(e => e.GetType().FullName)
                                    .Distinct()
                                    .ToList();

                            requestedTypeNames.AddRange(ReplacedTypesDict.Keys);

                            var hotReloadRequest = new HotReloadRequest
                            {
                                TypeNames = requestedTypeNames.Distinct().ToArray()
                            };

                            var streamWriter = new StreamWriter(pipeServer);
                            streamWriter.AutoFlush = true;
                            var jsonRequest = JsonSerializer.Serialize(hotReloadRequest);
                            await streamWriter.WriteLineAsync(jsonRequest);

                            // --------- Hot Reload assembly data ----------

                            var streamReader = new StreamReader(pipeServer);
                            var jsonData = await streamReader.ReadLineAsync();

                            var hotReloadData = JsonSerializer.Deserialize<HotReloadData>(jsonData);

                            // --------- load, register and hot reload ----------

                            var assembly = Assembly.Load(hotReloadData.AssemblyData, hotReloadData.PdbData);

                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                foreach (var typeName in hotReloadData.TypeNames)
                                {
                                    var type = assembly.GetType(typeName);
                                    ReplacedTypesDict[type.FullName] = type;
                                }
                                InvokeHotReload();
                            });
                        }
                    }
#pragma warning disable CS0168
                    catch (Exception ex)
                    {

                    }
#pragma warning restore CS0168
                }
            });
        }

        internal static object BindingContext = null;
        static void InvokeHotReload()
        {
            try
            {
                foreach (var toReloadTypeName in ReplacedTypesDict.Keys)
                {
                    var activePagesForTypeName = registeredActivePages.Where(e => e.GetType().FullName == toReloadTypeName).ToList();

                    foreach (var activePage in activePagesForTypeName)
                    {
                        // check if page type changed
                        var typeToReload = ReplacedTypesDict[toReloadTypeName];
                        if (activePage.GetType() != typeToReload)
                        {
                            var replaced = false;
                            try
                            {
                                var newObject = ActivatorUtilities.GetServiceOrCreateInstance(Application.Services, typeToReload);
                                if (newObject is ContentPage newContentPage)
                                {
                                    BindingContext = activePage.BindingContext;

                                    var parent = activePage.Parent;
                                    if (parent is Window parentWindow)
                                    {
                                        parentWindow.Page = newContentPage;
                                        replaced = true;
                                    }
                                    else if (parent is ShellContent shellContent)
                                    {
                                        shellContent.ContentTemplate = null;
                                        shellContent.Content = newContentPage;
                                        if (newContentPage.Handler == null) newContentPage.Handler = activePage.Handler;
                                        replaced = true;
                                    }
                                }
                            }
                            finally
                            {
                                if (replaced) registeredActivePages.Remove(activePage);
                                BindingContext = null;
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}