using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Properties;
 


namespace Proyecto.Model
{
    public class Space_Ship : Entityes, IObserver
    {
        public Space_Ship(int x, int y) : base(x, y, ApplyGreenFilter(LoadImage()))
        {


        }

        private int _Posx {  get; set; }
        private int _Posy { get; set; }

        public void Update()
        {
            throw new NotImplementedException();
        }

        private static Image LoadImage()
        {
            try
            {
                return Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0006_Player.png");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar la imagen: {ex.Message}");
                return null;
            }
        }
        public static Image ApplyGreenFilter(Image originalImage)
        {
            Bitmap newBitmap = new Bitmap(originalImage.Width, originalImage.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
            new float[] { 0.1f, 0.3f, 0.1f, 0, 0 }, // Red reducido, más verde
            new float[] { 0.0f, 2.0f, 0.0f, 0, 0 }, // Más verde
            new float[] { 0.1f, 0.3f, 0.1f, 0, 0 }, // Azul reducido, más verde
            new float[] { 0, 0, 0, 1, 0 }, // Alpha (sin cambios)
            new float[] { 0, 0, 0, 0, 1 }  // Offset (sin cambios)
                });

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(originalImage,
                            new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                            0, 0, originalImage.Width, originalImage.Height,
                            GraphicsUnit.Pixel, attributes);
            }
            return newBitmap;
        }
    }
}
