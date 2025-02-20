﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Proyecto.ModelView;

namespace Proyecto.Model
{
    public  class Bullet : Entityes
    {
        private static readonly Image[] bulletSprites = new Image[]
        {
            Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Projectiles\\ProjectileA_1.png"),
            Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Projectiles\\ProjectileA__2.png"),
            Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Projectiles\\ProjectileA_3.png"),
            Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Projectiles\\ProjectileA_4.png")
        };

        private int indexSprite = 0;
        private Thread movementThread;
        public bool MovingDown { get; }


        public Bullet(int x, int y, bool movingDown, Image[] sprites) : base(x, y, bulletSprites[0])
        {
            MovingDown = movingDown;
            Console.WriteLine($"Bala creada en X: {x}, Y: {y}, movingDown: {movingDown}");
           
        }
        
        
      
        public void UpdateSprite()
        {
            indexSprite = (indexSprite + 1) % bulletSprites.Length;
            Sprite = bulletSprites[indexSprite];
            Console.WriteLine("Bala cmabiando");
            NotifyObservers();
        }


    }
}
