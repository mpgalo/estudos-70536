using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelegate
{
    class Painter
    {
        private bool ligado = true;

        public bool Ligado
        {
            get { return ligado; }           
        }

        public void PaintOff()
        {
            ligado = false;
        }
    }
}
