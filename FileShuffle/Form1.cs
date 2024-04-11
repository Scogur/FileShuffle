using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileShuffle
{
    public partial class Form1 : Form
    {
        string folderName;
        string[] files;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);
            folderName = folderBrowserDialog1.SelectedPath;
            files = Directory.GetFiles(folderName);
            label1.Text = folderName;
        }

        private void shuffleNames(string[] names, string dir)
        {
            progressBar1.Maximum = names.Length;
            Random rnd = new Random();
            foreach (string name in names)
            {
                File.Move(name, $"{dir}\\{rnd.Next()}_{name.Remove(0, dir.Length + 1)}");
                progressBar1.Value++;
                //label1.Text += $@"{dir}{rnd.Next()}_{name.Remove(0, dir.Length + 1)}"+'\n';
            }
            progressBar1.Value = 0;
            MessageBox.Show("Done!","ShuffleRename");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shuffleNames(files, folderName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
