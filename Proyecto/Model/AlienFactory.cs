using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Model
{
    public class AlienFactory

    {
        public static List<AlienShip> aliens = new List<AlienShip>();
        private const int totalAliens = 55;
        private const int columns = 11;
        private const int spacingX = 40, spacingY = 40;
        private const int startX = 50, startY = 50;

        private static readonly Image[][] alienSprites = new Image[][]
        {
            new Image[] {Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0000_A1.png"), Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0001_A2.png") },


            new Image[] {Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0002_B1.png"), Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0003_B2.png") },

            new Image[] {Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0004_C1.png"), Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Invaders\\space__0005_C2.png") }

        };
        public static List<AlienShip> CreateAliens()
        {
            aliens.Clear();
            for (int i = 0; i < totalAliens; i++)
            {
                int row = i / columns;
                int col = i % columns;
                Image[] sprites = row == 0 ? alienSprites[0] : (row < 3 ? alienSprites[1] : alienSprites[2]);
                aliens.Add(new AlienShip(startX + col * spacingX, startY + row * spacingY, sprites));
            }
            return aliens;
        }




    }

}
