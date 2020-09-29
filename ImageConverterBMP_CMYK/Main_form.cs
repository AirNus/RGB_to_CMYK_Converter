using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConverterBMP_CMYK
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            FileWorker fileWorker = new FileWorker();
            pictureBoxImage.Image = fileWorker.SelectFile();            
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            Convert_RGB_to_CMYK converter = new Convert_RGB_to_CMYK(pictureBoxImage.Image);
            var kanals = converter.Convert();
            pictureBoxImage.Visible = false;
            pictureBox1.Image = kanals[0];
            pictureBox1.Visible = true;
            pictureBox2.Image = kanals[1];
            pictureBox2.Visible = true;
            pictureBox3.Image = kanals[2];
            pictureBox3.Visible = true;
        }
    }
}
