using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSRedisCore.Internal.Diagnostic
{
    public static class LogContext
    {
    
        internal static class Cached
        {
            internal static readonly Lazy<DiagnosticListener> Default =
                new Lazy<DiagnosticListener>(() => new DiagnosticListener(DiagnosticHeaders.DefaultListenerName));
        }
    }
}
