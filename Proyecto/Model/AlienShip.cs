using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto.Model
{
    public class AlienShip : Entityes

    {

        private Image[] alienSprites;
        private int spriteIndex = 0;


        public AlienShip(int x, int y, Image[] sprites) : base(x, y, sprites[0])
        {
            alienSprites = sprites;

        }
        public void UpdatePosition(int x, int y)
        {
            X = x;
            Y = y;
            NotifyObservers();
        }
        public void UpdateSprite()
        {
            spriteIndex = (spriteIndex + 1) % alienSprites.Length;
            Sprite = alienSprites[spriteIndex];
            NotifyObservers();
        }


    }
}
