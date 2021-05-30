using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerMachine computer = new ComputerMachine();
            computer.AddToMonitor();
            System.Threading.Thread.Sleep(2000);
        }


    }

    class StopMachineryEventArgs : EventArgs
    {
        private int hh;

        public int Hh
        {
            get { return hh; }
        }
        private int mm;

        public int Mm
        {
            get { return mm; }            
        }
        private int ss;

        public int Ss
        {
            get { return ss; }            
        }

        public StopMachineryEventArgs(int hh, int mm, int ss)
        {
            this.hh = hh;
            this.mm = mm;
            this.ss = ss;
        }

    }

    class MachineryWatcher
    {
        public delegate void stopMachineryEventHandler(StopMachineryEventArgs e);

        public event stopMachineryEventHandler stopMachinery;

        private System.Timers.Timer ticking = new System.Timers.Timer();

        private IMachine machine;

        public MachineryWatcher(IMachine machine)
        {
            this.ticking.Elapsed += new ElapsedEventHandler(this.OnTimedEvent);
            this.ticking.Interval = 1000; // 1 second
            this.ticking.Enabled = true;            
            this.machine = machine;
            
        }

        private void OnTimedEvent(object source, ElapsedEventArgs args)
        {
            int hh = args.SignalTime.Hour;
            int mm = args.SignalTime.Minute;
            int ss = args.SignalTime.Second;
            StopMachineryEventArgs stopMachineryEventArgs = new StopMachineryEventArgs(hh, mm, ss);
            this.MonitoreMachines(stopMachineryEventArgs);
        }

        private void MonitoreMachines(StopMachineryEventArgs e)
        {
            if (this.machine.Temperature > 50 && this.machine.On)
            {
                if (this.stopMachinery != null)
                {
                    this.stopMachinery(e);
                }
            }
        }
    }

    class ComputerMachine : IMachine
    {

        #region IMachinery Members

        private int temperature = 60;
        private bool on = true;
        private MachineryWatcher machineWatcher;

        public ComputerMachine()
        {
            machineWatcher = new MachineryWatcher(this);
            
        }

        public void AddToMonitor()
        {
            machineWatcher.stopMachinery += new MachineryWatcher.stopMachineryEventHandler(StopMachine);
        }

        public int Temperature
        {
            get { return temperature; }
        }

        public bool On
        {
            get { return on; }
        }

        public void StopMachine(StopMachineryEventArgs e)
        {
            on = false;
            Console.WriteLine("Máquina parada as {0}:{1}:{2}", e.Hh, e.Mm, e.Ss);
        }

        #endregion

       
    }

    interface IMachine
    {
        bool On
        {
            get;
        }
        int Temperature
        {
            get;
        }
        void StopMachine(StopMachineryEventArgs e);
    }
}
