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

namespace RenameTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Browse(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult res = fbd.ShowDialog();

                if(res == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] file = Directory.GetFiles(fbd.SelectedPath);
                    foreach(var item in file)
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
        }

        private void Start(object sender, EventArgs e)
        {

            foreach(string item in listBox1.Items)
            {
                FileInfo fi = new FileInfo(item);
                if (textBox1.Text != null && textBox2.Text != null)
                {
                    if (fi.Extension == textBox1.Text)
                        File.Move(item, fi.FullName.Split('.')[0] + textBox2.Text);
                }
            }
        }
    }
}
