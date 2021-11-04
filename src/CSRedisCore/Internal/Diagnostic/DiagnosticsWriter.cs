using CSRedis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSRedisCore.Internal.Diagnostic
{
    internal sealed class DiagnosticsWriter
    {
        private readonly DiagnosticListener diagnosticListener = LogContext.Cached.Default.Value;
        private const string name = DiagnosticHeaders.Execute;

        internal Activity? WriteStarted(DiagnosticContext context, DateTimeOffset startTimeUtc)
        {
            if (!diagnosticListener.IsEnabled(name))
            {
                return null;
            }

            var activity = new Activity(name);
            activity.SetStartTime(startTimeUtc.UtcDateTime);
            activity.AddTag(DiagnosticHeaders.Id, context.id.ToString());
            activity.AddTag(DiagnosticHeaders.Key, context.key);
            activity.AddTag(DiagnosticHeaders.Action, context.action);

            diagnosticListener.StartActivity(activity, context);
            return activity;
        }

        internal void WriteStopped(Activity? activity, DateTimeOffset endTimeUtc, DiagnosticContext context)
        {
            if (activity != null && diagnosticListener.IsEnabled(name))
            {
                activity.SetEndTime(endTimeUtc.UtcDateTime);
                diagnosticListener.StopActivity(activity, context);
            }
        }

        public void WriteException(Activity? activity, Exception exception)
        {
            if (activity != null && diagnosticListener.IsEnabled(name))
            {
                diagnosticListener.Write(name + ".Exception", exception);
            }
        }
    }
}
