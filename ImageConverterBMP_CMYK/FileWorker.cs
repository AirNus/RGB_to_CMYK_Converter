using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConverterBMP_CMYK
{
    public class FileWorker
    {
        public Image SelectFile()
        {
            PictureBox picture = new PictureBox();
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "BMP Photos (*.bmp)|*.bmp|All files (*.*)|*.*";
                if(openFile.ShowDialog() == DialogResult.OK)
                {
                    picture.Image = Image.FromFile(openFile.FileName);                   
                }
                
            }
            return picture.Image;
        }
    }
}
