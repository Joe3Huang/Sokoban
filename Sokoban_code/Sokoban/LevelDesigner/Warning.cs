using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelDesigner
{
    public partial class Warning : Form
    {
        public Warning()
        {
            InitializeComponent();
        }
        public void prompt(string message)
        {
            this.label1.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            this.Hide();
        }

    }
}
