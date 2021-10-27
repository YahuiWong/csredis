using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSRedisCore.Internal.Diagnostic
{
    public  class DiagnosticContext
    {
        public DiagnosticContext()
        {
            id = Guid.NewGuid();
        }
        public Activity? activity { get; set; }
        public string action { get; set; }
        public string key { get; set; }
        public Guid id { get; set; }
    }
}
