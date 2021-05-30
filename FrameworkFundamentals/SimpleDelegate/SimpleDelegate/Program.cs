using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller control = new Controller();
            Folder folder = new Folder();
            Welder welder = new Welder();
            Painter painter = new Painter();

            control.Add(folder.StopFolding);
            control.Add(welder.FinishWelding);
            control.Add(painter.PaintOff);


            Console.WriteLine(string.Format("{0} {1} {2}",folder.Ligado,welder.Ligado,painter.Ligado));
            control.ShutDown();
            Console.WriteLine(string.Format("{0} {1} {2}", folder.Ligado, welder.Ligado, painter.Ligado));


        }
    }
}
