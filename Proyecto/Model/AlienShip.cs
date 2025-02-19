using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Model
{
    public class AlienShip : Entityes

    {
        private static int Direction = 1; // 1 = Derecha, -1 = Izquierda
        private static int StepX = 5;
        private static int StepY = 20;
        private static int LeftBound = 50;
        private static int RightBound = 500;
        private int spriteIndex = 0;
        private Image[] spriteVariants;

        public AlienShip(int x, int y, Image sprite) : base(x, y, sprite) { }


        public void Move()
        {
            _PosX += StepX * Direction;
            UpdateSprite();
            NotifyObservers();
        }

        private void UpdateSprite()
        {
            spriteIndex = (spriteIndex + 1) % spriteVariants.Length;
            sprite = spriteVariants[spriteIndex];
        }

        public static void ChangeDirectionAndMoveDown()
        {
            Direction *= -1;
            foreach (var alien in AlienFactory.GetAliens())
            {
                alien._PosY += StepY;
                alien.NotifyObservers();
            }
        }

    }
}
