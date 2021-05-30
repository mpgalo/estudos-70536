using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Net;
using System.IO;

namespace MonitorWebSite
{
    public partial class MonitorWebSite : ServiceBase
    {
        public MonitorWebSite()
        {
            InitializeComponent();
            t = new Timer(10000);
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
        }

        private Timer t = null;

        protected override void OnStart(string[] args)
        {
            t.Start();
        }

        protected override void OnStop()
        {
            t.Start();
        }

        protected override void OnContinue()
        {
            t.Start();
        }

        protected override void OnPause()
        {
            t.Stop();
        }

        protected override void OnShutdown()
        {
            t.Stop();
        }

        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            { // Send the HTTP request 
                string url = "http://www.microsoft.com"; 
                HttpWebRequest g = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse r = (HttpWebResponse)g.GetResponse();
                // Log the response to a text file
                string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log.txt";
                TextWriter tw = new StreamWriter(path, true); tw.WriteLine(DateTime.Now.ToString() + " for " + url + ": " + r.StatusCode.ToString()); tw.Close();
                // Close the HTTP response
                r.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application",
                "Exception: " + ex.Message.ToString());
            }
        }
    }
}
