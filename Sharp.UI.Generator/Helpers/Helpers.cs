using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Sharp.UI.Generator;

public class Helpers
{
    public static void WaitForDebugger(CancellationToken cancellationToken)
    {
#if DEBUG
        while (!Debugger.IsAttached && !cancellationToken.IsCancellationRequested) Task.Delay(1000).Wait(cancellationToken);
#endif
    }
}

