using System;
using System.Collections.Generic;
using System.Threading;
using Proyecto.Model;

namespace Proyecto.ModelView
{
    public class BulletController
    {
        private static Thread movementThread;
        private static bool running = true;
        private static object lockObject = new object();
        public static List<Bullet> Bullets { get; private set; } = new List<Bullet>();

        public BulletController()
        {
            
            movementThread = new Thread(Move);
            movementThread.IsBackground = true;
            movementThread.Start();
        }

        public static void Move()
        {
            lock (lockObject)
            {
                for (int i = Bullets.Count - 1; i >= 0; i--)
                {
                    Bullets[i].Y += Bullets[i].MovingDown ? 20 : -5;
                    Bullets[i].UpdateSprite();
                    NotifyObservers();
                    Console.WriteLine("Movimiento de las balas");


                    // Notificar cambios a la UI

                    if (Bullets[i].Y < 0 || Bullets[i].Y > 600)
                    {
                        RemoveBullet(Bullets[i]);
                    }
                }
            }
        }
        public static void NotifyObservers()
        {
            foreach (var bullet in Bullets)
            {
                bullet.NotifyObservers();
                Console.WriteLine("Mosatrar nueva bala");
            }
        }

        public static void AddBullet(Bullet bullet)
        {
            lock (lockObject)
            {
                Bullets.Add(bullet);
            }
        }

        public static void RemoveBullet(Bullet bullet)
        {
            lock (lockObject)
            {
                if (Bullets.Contains(bullet))
                {
                    Bullets.Remove(bullet);
                    Console.WriteLine("Bala eliminada");
                }
            }
        }

        public  static void UpdateBullets()
        {
            while (running)
            {
                
                CheckCollisions();
                Thread.Sleep(100);
            }
        }

        private static void CheckCollisions()
        {
            lock (lockObject)
            {
                for (int i = Bullets.Count - 1; i >= 0; i--)
                {
                    Bullet bullet = Bullets[i];

                    // Aquí se puede agregar la lógica para verificar colisiones con enemigos o jugador.
                    // Ejemplo: Si la bala choca con un enemigo, eliminar la bala y dañar al enemigo.
                }
            }
        }

        public static void Stop()
        {
            running = false;
        }
    }
}
