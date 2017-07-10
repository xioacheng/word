using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BmpEdit
{
    public class OpenBMP
    {
        public  Bitmap bmp;
        string path = "";
        public Bitmap open()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Word File(*.bmp)|*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                path = open.FileName.ToString();
            }
            else path = "";
            try
            {
                bmp = (Bitmap)Image.FromFile(path);
                return bmp;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
