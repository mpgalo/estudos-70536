using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSystemWatcherTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"c:\";
            // Register for events
            watcher.Created += new FileSystemEventHandler(watcher_Changed);
            watcher.Deleted += new FileSystemEventHandler(watcher_Changed);
            watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
            watcher.Error += new ErrorEventHandler(watcher_Error);
            // Start Watching
            watcher.EnableRaisingEvents = true;
            watcher.
            // Event Handler    
           
        }
       
        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show(string.Format("Directory changed({0}): {1}",
            e.ChangeType,
            e.FullPath));
        }

        static void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            MessageBox.Show(string.Format("Renamed from {0} to {1}",
            e.OldFullPath,
            e.FullPath));
        }

        static void watcher_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(string.Format("Error: {0}",
            e.GetException()));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}