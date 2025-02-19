using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Proyecto.Model
{
    public class AlienFactory

    {
        private static readonly Dictionary<int, Image>[] alienSprites = new Dictionary<int, Image>[]
           {
        new Dictionary<int, Image>
        {
            { 0, Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0000_A1.png") },
            { 1, Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0001_A2.png")}
        },
        new Dictionary<int, Image>
        {
            { 0,Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0002_B1.png") },
            { 1, Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0003_B2.png") }
        },
        new Dictionary<int, Image>
        {
            { 0, Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0004_C1.png") },
            { 1, Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0005_C2.png") }
        }
           };

        public static List<AlienShip> GetAliens() => aliens;
        private static List<AlienShip> aliens = new List<AlienShip>();
        private const int totalAliens = 55;
        private const int columns = 11;
        private const int spacingX = 40, spacingY = 40;
        private const int startX = 50, startY = 50;

        public static List<AlienShip> CreateAlien1(int index = 0)
        {
            if(index >= 50)
                return aliens;

            int row = index / columns;
            int col = index % columns;
            Dictionary<int, Image> sprites = alienSprites[row  < 1?0:(row <3 ? 1 : 2)];
            aliens.Add(new AlienShip(startX + col * spacingX, startY + row * spacingY, sprites[0]));

            return CreateAlien1(index + 1);
          
        } 

    }

}
