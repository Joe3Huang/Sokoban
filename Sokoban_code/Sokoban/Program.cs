using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           // LevelDesigner.Form1 lF = new LevelDesigner.Form1();
           // LevelDesigner.ILevel theLevel = new LevelDesigner.TheLevel();
           // LevelDesigner.Controller lCtl = new LevelDesigner.Controller(lF, theLevel);
           // lF.SetController(lCtl);

            Form1 f = new Form1();
           // f.SetLevelDesigner(lF);
            Application.Run(f);
        }

    }
}
