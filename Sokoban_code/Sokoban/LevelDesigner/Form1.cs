using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using System.Windows.Controls.Grid;
namespace LevelDesigner
{
    public partial class Form1 : Form
    {
        protected Image symbol = Sokoban.Properties.Resources.empty;
        protected Parts symbol_Parts = Parts.Empty;
        protected LevelDesigner.Controller Ctl;
        private Warning warningFrom = new Warning();
        public Form1()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 550;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }
        public void debugValue(int value)
        {
            this.Text = Convert.ToString(value);
        }
        
        public void SetController(LevelDesigner.Controller ctl)
        {
            this.Ctl = ctl;
        }

        private void Warning(string meassage)
        {
            warningFrom.prompt(meassage);
            warningFrom.Show();
        
        }

        public void GridOfButton(int width, int height)
        {
            if ((width > 0) && (height > 0))
            {
                int Button_width = this.btnGridPanel.Width / width;
                while ((Button_width * height) > this.btnGridPanel.Height)
                {
                    Button_width -= 2;
                }
                int centerOfScreenX = (this.btnGridPanel.Width - (Button_width * width)) / 2;
                int centerOfScreenY = (this.btnGridPanel.Height - (Button_width * height)) / 2;
                for (int h = 0; h < height; h++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        MakeButtons(Button_width, Button_width, i, h, centerOfScreenX, centerOfScreenY);
                    }
                }
            }
        }
        
        protected void MakeButtons(int button_height,int button_width, int x, int y,int startPointX,int startPointY)
        {
            Button btnNew = new Button();
            btnNew.Name = "btn_" + x + "_" + y;
            btnNew.Height = button_height;
            btnNew.Width = button_width;
            btnNew.Font = new Font("Arial", 10);
            //btnNew.Text = "btn_" + x + "_" + y;
            btnNew.Visible = true;
            btnNew.Location = new System.Drawing.Point(button_width * x + startPointX, button_height * y + startPointY);
            btnNew.BackgroundImage = Sokoban.Properties.Resources.empty;
            btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGridPanel.Controls.Add(btnNew);
            //this.g.adds(btnNew);
        }

        protected void WhoClicked(object sender,EventArgs e)
        {
            Button btnWho = sender as Button;
            btnWho.BackgroundImage = this.symbol;
            string s = btnWho.Name.ToString();
            int x = getXFromBtnName(s);// Int32.Parse(numberX);
            int y = getYFromBtnName(s);// Int32.Parse(numberY);
            string result = this.Ctl.AddItemToGird(symbol_Parts, x, y);
            if (result != "OK")
            {
                this.Warning(result);
            }
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
            for (int i = ( at + 1); i < name.Length; i++)
            {
                numberY += name[i];
            }
            return Int32.Parse(numberY);
        }
        public void SetClicks()
        {
            foreach (Control c in this.btnGridPanel.Controls)
            {
                if (c is Button)
                {
                    if (c.Name.StartsWith("btn"))
                    {
                        Button Who = c as Button;
                        Who.Click += new EventHandler(WhoClicked);
                    }
                }
            }
        }

        private void setSizeBtn_Click(object sender, EventArgs e)
        {
            this.btnGridPanel.Controls.Clear();
            int width = (int)numericUpDown1.Value;
            int height = (int)numericUpDown2.Value;
            GridOfButton(width, height);
            SetClicks();
            this.Ctl.SetLevel(width, height);
        }

        private void cleanBtn_Click(object sender, EventArgs e)
        {
            this.btnGridPanel.Controls.Clear();
        }

        private void wallBtn_Click(object sender, EventArgs e)
        {
            //this.symbol = "#";
            this.symbol = Sokoban.Properties.Resources.wall;
            this.symbol_Parts = Parts.Wall;
        }

        private void playerBtn_Click(object sender, EventArgs e)
        {
            //this.symbol = "@";
            this.symbol = Sokoban.Properties.Resources.player;
            this.symbol_Parts = Parts.Player;
        }

        private void emptyBtn_Click(object sender, EventArgs e)
        {
            //  this.symbol = "";
            this.symbol = Sokoban.Properties.Resources.empty;
            this.symbol_Parts = Parts.Empty;
        }

        private void boxBtn_Click(object sender, EventArgs e)
        {
            //this.symbol = "$";
            this.symbol = Sokoban.Properties.Resources.box;
            this.symbol_Parts = Parts.Block;
        }

        private void goalBtn_Click(object sender, EventArgs e)
        {
            // this.symbol = ".";
            this.symbol = Sokoban.Properties.Resources.goal;
            this.symbol_Parts = Parts.Goal;
        }


        private void btnGridPanel_Paint_1(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawButton(
            System.Drawing.Graphics.FromHwnd(this.btnGridPanel.Handle), 0, 0, this.btnGridPanel.Width, this.btnGridPanel.Height,
                    ButtonState.Flat);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics l = e.Graphics;
            l.DrawLine(System.Drawing.Pens.Red, 0, this.Height - 200,
                this.Width, this.Height - 200);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Ctl.go();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filer.Form1 f = new Filer.Form1();
            this.Ctl.Save(f.SaveFile());
        }

        public string setProjectName()
        {
            Filer.InputForm input = new Filer.InputForm();
            input.SetLabel("Project name: ");
            string value = "";
            if (input.ShowDialog(Parent) == DialogResult.OK)
            {
                value = input.Read();
            }
            input.Dispose();
            return value;
        }
        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Ctl.SetLevelName(setProjectName());
            this.btnGridPanel.Controls.Clear();
        }

        /*****************************Load Display**********************************************************************/
        private void openPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnGridPanel.Controls.Clear();
            Filer.Form1 f = new Filer.Form1();
            string fileName = f.LoadFile();
            if (fileName != "")
            {
                fileName = new Sokoban.GetPath().GetTheDirectory() + "\\" + fileName;
                this.Ctl.Load(fileName);
            }
        }

        public void DisplayGame(string[] stringArray)
        {
            string symbol = "";
            foreach (Control c in this.btnGridPanel.Controls)
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


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
