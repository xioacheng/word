using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BmpEdit
{
    public partial class Form1 : Form
    {
        OpenBMP open = new OpenBMP();
        Bitmap bmp;
        List<List<double>> array = new List<List<double>>();
        public Form1()
        {
            InitializeComponent();
        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bmp = open.open();
            pictureBox1.Image = bmp;
        }

        private void getArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            array.Clear();
            Feature feature = new Feature();
            array = feature.CunWangGe(bmp, 4);
            //List<List<float>> array = CunWangGe(bmp, 4);
            foreach (List<double> temp in array)
            {
                foreach (double a in temp)
                {
                    textBox1.Text += a.ToString("0")+ " ";
                }
                textBox1.Text += "\r\n";//换行
            }
        }

        private void getCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compare temp = new Compare();
            string getChar = temp.GetChar(array);
            textBox2.Text = getChar;
        }
    }
}
