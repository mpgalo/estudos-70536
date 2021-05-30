using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileSystemWatcherTest
{
    class Program
    {
        static void Main(string[] args)
        {

            FileSystemWatcher watcher = new FileSystemWatcher();           
            watcher.Path = @"c:\";
            // Register for events
            watcher.Created += new FileSystemEventHandler(watcher_Changed);
            watcher.Deleted += new FileSystemEventHandler(watcher_Changed);
            watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
            watcher.Error += new ErrorEventHandler(watcher_Error);
            // Start Watching
            watcher.EnableRaisingEvents = true;
            // Event Handler    

            

        }

        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Directory changed({0}): {1}",
            e.ChangeType,
            e.FullPath);
        }

        static void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("Renamed from {0} to {1}",
            e.OldFullPath,
            e.FullPath);
        }

        static void watcher_Error(object sender,ErrorEventArgs e)
        {
            Console.WriteLine("Error: {0}",
            e.GetException());
        }
    }
}
