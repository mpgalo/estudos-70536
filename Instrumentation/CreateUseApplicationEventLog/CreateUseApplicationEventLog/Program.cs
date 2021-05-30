using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CreateUseApplicationEventLog
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!EventLog.SourceExists("Chap10Demo", "micp100682.cemig.ad.corp"))
            {
                EventLog.CreateEventSource("Chap10Demo", "Application", "micp100682.cemig.ad.corp");
            }
            EventLog LogDemo = new EventLog("Application", "micp100682.cemig.ad.corp", "Chap10Demo");
            LogDemo.WriteEntry("Event Written to Application Log", EventLogEntryType.Information, 234, Convert.ToInt16(3));

            EventLog eventLog = new EventLog("Application");
            eventLog.Source = "TesteMarcus";
            eventLog.WriteEntry("Teste", EventLogEntryType.Information);

            EventLog applicationLog = new EventLog("Application");

            foreach (EventLogEntry entry in applicationLog.Entries)
            {
                Console.WriteLine(entry.Source + ":" + entry.Message);
            }

            EventLog securityLog = new EventLog("Security");
            securityLog.Clear();

            EventLog.Delete("Internet Explorer");
        }
    }
}
