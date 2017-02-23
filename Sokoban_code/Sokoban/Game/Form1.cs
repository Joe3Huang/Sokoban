using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        protected Image symbol = Sokoban.Properties.Resources.empty;
        protected Controller Ctl;
        int Block_width;
        int CenterOfScreenX;
        int CenterOfScreenY;

        public Form1()
        {
            InitializeComponent();
        }

        public void SetController(Controller ctl)
        {
            this.Ctl = ctl;
        }

        public void GridOfButton(int width, int height)
        {
            if ((width >=5) && (height >= 5))
            {
                this.ShowWin("Hello!");
                this.panel1.Controls.Clear();
                this.Block_width = this.panel1.Width / width;
                while ((Block_width * height) > this.panel1.Height)
                {
                    Block_width -= 2;
                }
                this.CenterOfScreenX = (this.panel1.Width - (Block_width * width)) / 2;
                this.CenterOfScreenY = (this.panel1.Height - (Block_width * height)) / 2;
                for (int h = 0; h < height; h++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        MakeButtons(this.Block_width, this.Block_width, i, h, CenterOfScreenX, CenterOfScreenY);
                    }
                }
            }
        }

        public void ShowWin(string s)
        {
            this.label1.Text = s;
        }

        public void ShowMoveCount(int i)
        {
            this.label2.Text = Convert.ToString(i);
        }

        public void MakeButtons(int button_height, int button_width, int x, int y, int startPointX, int startPointY)
        {
            Button btnNew = new Button();
            btnNew.Name = "btn_" + x + "_" + y;
            btnNew.Height = button_height;
            btnNew.Width = button_width;
            //btnNew.Font = new Font("Arial", 10);
            //btnNew.Text = "btn_" + x + "_" + y;
            btnNew.Visible = true;
            btnNew.Location = new System.Drawing.Point(this.Block_width * x + startPointX, this.Block_width * y + startPointY);
            btnNew.BackgroundImage = Sokoban.Properties.Resources.empty;
            btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(btnNew);
        }
        public void DisplayGame(string[] stringArray)
        {
            if (stringArray.Length > 0)
            {
                string symbol = "";
                 foreach (Control c in this.panel1.Controls)
                 {
                     if (c is Button)
                     {
                         if (c.Name.StartsWith("btn"))
                         {
                             Button Who = c as Button;
                             string s = Who.Name.ToString();
                             int x = getXFromBtnName(s);// Int32.Parse(numberX);
                             int y = getYFromBtnName(s);// Int32.Parse(numberY);
                             symbol = stringArray[y][x].ToString();
                             Who.BackgroundImage = this.getImage(symbol);// r;
                         }
                     }
                 }
            }

        }

        private Image getImage(string symbol)
        {
            Image img = Sokoban.Properties.Resources.empty;
            if (symbol == "#")
            {
                img = Sokoban.Properties.Resources.wall;
            }
            else if (symbol == "@")
            {
                img = Sokoban.Properties.Resources.player;
            }
            else if (symbol == "$")
            {
                img = Sokoban.Properties.Resources.box;
            }
            else if (symbol == ".")
            {
                img = Sokoban.Properties.Resources.goal;
            }
            else if (symbol == "*")
            {
                img = Sokoban.Properties.Resources.box;
            }
            else if (symbol == "+")
            {
                img = Sokoban.Properties.Resources.player;
            }
            else //if (symbol == " ")
            {
                img = Sokoban.Properties.Resources.empty;
            }
            return img;
        }

        private int getXFromBtnName(string name)
        {
            string target = "_";
            char[] anyOf = target.ToCharArray();
            int at = name.IndexOfAny(anyOf, 4);
            //this.label3.Text = Convert.ToString(at);
            string numberX = "";
            for (int i = 4; i < at; i++)
            {
                numberX += name[i];
            }
            return Int32.Parse(numberX);
        }

        private int getYFromBtnName(string name)
        {
            string target = "_";
            char[] anyOf = target.ToCharArray();
            int at = name.IndexOfAny(anyOf, 4);
            string numberY = "";
            for (int i = (at + 1); i < name.Length; i++)
            {
                numberY += name[i];
            }
            return Int32.Parse(numberY);
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filer.Form1 f = new Filer.Form1();
            string fileName = f.LoadFile();
            if (fileName != "")
            {
                fileName = new Sokoban.GetPath().GetTheDirectory() + "\\" + fileName;
                this.Ctl.Load(fileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Ctl.Move(Direction.up);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Ctl.Move(Direction.Down);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Ctl.Move(Direction.Left);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Ctl.Move(Direction.Right);
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Ctl.Restart();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Ctl.Undo();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filer.Form1 f = new Filer.Form1();
            this.Ctl.Save(f.SaveFile());
        }

    }
}
