using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelegate
{
    class Welder
    {
        private bool ligado = true;

        public bool Ligado
        {
            get { return ligado; }            
        }

        public void FinishWelding()
        {
            ligado = false;
        }
    }
}
