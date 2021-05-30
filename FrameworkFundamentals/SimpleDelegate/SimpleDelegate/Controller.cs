using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelegate
{
    class Controller
    {
        public delegate void stopMachineryEventHandler();
        private stopMachineryEventHandler stopMachinery;

        public void Add(stopMachineryEventHandler stopMethod)
        {
            stopMachinery += new stopMachineryEventHandler(stopMethod);
        }
        public void Remove(stopMachineryEventHandler stopMethod)
        {
            stopMachinery += new stopMachineryEventHandler(stopMethod);
        }

        public void ShutDown()
        {
            this.stopMachinery();
        }
    }
}
