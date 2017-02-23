using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class Form1 : Form
    {
        Form TheLevelDesigner;

        public Form1()
        {
            InitializeComponent();  
        }

        public void SetLevelDesigner(LevelDesigner.Form1 levelDesigner)
        {
            this.TheLevelDesigner = levelDesigner;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LevelDesigner.Form1 lF = new LevelDesigner.Form1();
            LevelDesigner.ILevel theLevel = new LevelDesigner.TheLevel();
            LevelDesigner.Controller lCtl = new LevelDesigner.Controller(lF, theLevel);
            lF.SetController(lCtl);
            lF.Show();
        }
        public void StartFiler()
        {
            Form filer = new Filer.Form1();
            filer.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.StartFiler();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Game.Form1 gF = new Game.Form1();
            Game.Game gModel = new Game.Game();
            Game.Controller gCtl = new Game.Controller(gF, gModel);
            gF.SetController(gCtl);
            gF.Show();
        }
    }
}
