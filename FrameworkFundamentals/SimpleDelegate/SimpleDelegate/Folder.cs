using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelegate
{
    class Folder
    {
        private bool ligado = true;

        public bool Ligado
        {
            get { return ligado; }            
        }

        public void StopFolding()
        {
            ligado = false;
        }
    }
}
