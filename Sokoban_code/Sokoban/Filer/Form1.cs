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

namespace Filer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string path = System.IO.Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.MyDoc‌​uments), "Sokoban");
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                this.listBox1.Items.Add(Path.GetFileName(fileName));//.Add += fileName + "\n";
            }
            foreach (string fileName in fileEntries)
            {
                this.listBox2.Items.Add(fileName);//.Add += fileName + "\n";
            }
            // this.listBox1.Text += "hello";
        }
   /*     public string LoadFile()
        {
            InputForm input = new InputForm();
            input.SetLabel("File name: ");
            input.Text = "Load";
            string value = "";
            if (input.ShowDialog() == DialogResult.OK)
            {
                value = input.Read();
            }
            input.Dispose();
            return value;
        }*/
        public string LoadFile()
        {
            string value = "";
            string path = new Sokoban.GetPath().GetTheDirectory();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = path;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.Title = "Choose a file to import";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("No file selected!");
            }
            else
            {
                value = openFileDialog1.SafeFileName;
            }
            return value;
        }
        public string SaveFile()
        {
            InputForm input = new InputForm();
            input.SetLabel("File name: ");
            input.Text = "Save";
            string value = "";
            if (input.ShowDialog(Parent) == DialogResult.OK)
            {
                value = input.Read();
            }
            input.Dispose();
            return value;
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
    }
}



/*
public string LoadFile()
{
    //  Filer.InputForm input = new Filer.InputForm();
    //  input.SetLabel("File Name : ");
    string value = "";
    string path = new Sokoban.GetPath().GetTheDirectory();
    //  if (input.ShowDialog(Parent) == DialogResult.OK)
    //  {
    //      value = input.Read();
    //       input.Dispose();
    //   } 
    //    if (value == "")
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.InitialDirectory = path;
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog1.FilterIndex = 2;
        openFileDialog1.Title = "Choose a file to import";
        if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
        {
            MessageBox.Show("No file selected!");
        }
        else
        {
            value = openFileDialog1.SafeFileName;
        }
        //  if (openFileDialog1.ShowDialog() == DialogResult.OK)
        // {
        // //    try
        //    {
        //       value = openFileDialog1.SafeFileName;
        //    }
        //     catch (Exception ex)
        //   {
        //         MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
        //    }
        // }
    }

    return value;
}*/