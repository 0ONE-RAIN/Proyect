using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.Model;

namespace Proyecto.ModelView
{
    public class AlienController
    {
        private Random random = new Random();
        
        private List<AlienShip> aliens;
        private Thread movementThread;
        private static int direction = 1;
        private static int stepX = 5;
        private static int stepY = 20;
        private static int leftBound = 30;
        private static int rightBound = 780;
        private static object lockObject = new object();
        public event Action<Bullet> OnBulletFired;

        public AlienController(List<AlienShip> aliens)
        {
            this.aliens = aliens;

            movementThread = new Thread(MoveAliens);
            movementThread.IsBackground = true;
            movementThread.Start();
            Thread shootingThread = new Thread(StartShooting);
            shootingThread.IsBackground = true;
            shootingThread.Start();
        }
        private void MoveAliens()
        {
            while (true)
            {
                lock (lockObject)
                {
                    bool shouldMoveDown = false;
                    foreach (var alien in aliens)
                    {
                        if ((alien.X + stepX >= rightBound && direction == 1) ||
                            (alien.X - stepX <= leftBound && direction == -1))
                        {
                            shouldMoveDown = true;
                            break;
                        }
                    }

                    if (shouldMoveDown)
                    {
                        direction *= -1;
                        foreach (var alien in aliens)
                        {
                            alien.Y += stepY;
                        }
                    }
                    else
                    {
                        foreach (var alien in aliens)
                        {
                            alien.X += stepX * direction;
                        }
                    }
                }

                UpdateSprites();
                NotifyObservers();

                if (random.Next(0,100)<80)
                {
                    AlienShoot();
                }
                Thread.Sleep(500);
            }
        }
        private void UpdateSprites()
        {
            foreach (var alien in aliens)
            {
                alien.UpdateSprite();
            }
        }

        private void NotifyObservers()
        {
            foreach (var alien in aliens)
            {
                alien.NotifyObservers();
            }
        }

        private void AlienShoot()
        {
            if(aliens.Count > 0)
            {
                int index = random.Next(aliens.Count);
                AlienShip alien  = aliens[index];

                Bullet bullet = BulletFactory.CreateBullet(alien.X + 15, alien.Y + 30, true);
                OnBulletFired?.Invoke(bullet);
                BulletController.AddBullet(bullet);
                BulletController.Move();
                


            }
        }
        private void StartShooting()
        {
            while (true)
            {
                Thread.Sleep(random.Next(1000, 3000)); // Disparos aleatorios cada 1-3 segundos
                AlienShoot();
            }
        }


    }
}
