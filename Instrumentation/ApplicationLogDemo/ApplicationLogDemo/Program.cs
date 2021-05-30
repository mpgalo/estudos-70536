using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ApplicationLogDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write Event Log
            if (!EventLog.SourceExists("Chap10Demo", "Note-Marcus"))
            {
                EventLog.CreateEventSource("Chap10Demo", "Application", "Note-Marcus");
            }
            EventLog LogDemo = new EventLog("Application", "Note-Marcus", "Chap10Demo");
            LogDemo.WriteEntry("Event Written to Application Log", EventLogEntryType.Information, 234, Convert.ToInt16(3));

            //Read Event Log
            EventLog logExistente = new EventLog("Application", "Note-Marcus");

            foreach (EventLogEntry entry in logExistente.Entries)
            {
                if (entry.Source == "Chap10Demo")
                    Console.WriteLine(entry.TimeGenerated);
            }
        }
    }
}
