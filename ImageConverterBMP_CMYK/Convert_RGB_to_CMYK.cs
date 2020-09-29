using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverterBMP_CMYK
{
    public class Convert_RGB_to_CMYK
    {
        private Image image;
        public Convert_RGB_to_CMYK(Image image)
        {
            this.image = image;
        }
        public Bitmap[] Convert()
        {            
            Bitmap bitmap = new Bitmap(image);
            Bitmap firstKanal = new Bitmap(bitmap);
            Bitmap secondKanal = new Bitmap(bitmap);
            Bitmap thirdKanal = new Bitmap(bitmap);
            var width = image.Width;
            var height = image.Height;


            for (int x_pixel = 0; x_pixel < width; x_pixel++)
            {
                for (int y_pixel = 0; y_pixel < height; y_pixel++)
                {
                    // Берем пиксель считываем его RGB  и преобразовывае его в CMY
                    var pixel = bitmap.GetPixel(x_pixel, y_pixel);
                    var C = 255 - pixel.R;
                    var M = 255 - pixel.G;
                    var Y = 255 - pixel.B;
                    // Преобразоваем из CMY в CMYK
                    var K = Math.Min(C, Math.Min(M, Y));
                    C = C - K;
                    M = M - K;
                    Y = Y - K;
                    //var Y_linear = 0.2126 * C + 0.7152 * M + 0.0722 * Y;
                    //int Y_linear_to_byte = Convert.ToInt32(Y_linear);
                    // Задаем пикселю новые значения
                    firstKanal.SetPixel(x_pixel, y_pixel, Color.FromArgb(C, C, C));
                    secondKanal.SetPixel(x_pixel, y_pixel, Color.FromArgb(M, M, M));
                    thirdKanal.SetPixel(x_pixel, y_pixel, Color.FromArgb(Y, Y, Y));
                    ////

                }
            }
            return new Bitmap[] { firstKanal, secondKanal, thirdKanal };
        }
    }
}
