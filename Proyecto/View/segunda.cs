using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Proyecto.Model;
using Proyecto.ModelView;

namespace Proyecto.View
{
    public partial class segunda : Form, IObserver
    {
       

        private List<PictureBox> alienPictureBoxes = new List<PictureBox>(); // Lista de PictureBox para los aliens
        private Space_Ship _space;
        private AlienFactory AlienFactory;
        private List<AlienShip> aliens;  // Ahora es una lista
        private AlienController alienController;
        private List<PictureBox> bulletPictureBoxes = new List<PictureBox>();
        private List<Bullet> bullets = new List<Bullet>();

        public segunda()
        {
            InitializeComponent();
            startGame();
            DoubleBuffered = true;
        }

        private void startGame()
        {

            aliens = AlienFactory.CreateAliens();  // Crear lista de alienígenas correctamente
            alienController = new AlienController(aliens);
            alienController.OnBulletFired += HandleBulletFired;

            


            foreach (var alien in aliens)
            {
                PictureBox pb = new PictureBox
                {
                    Image = alien.Sprite, // Se asigna la imagen inicial
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Size = new Size(30, 30), // Tamaño de cada alien
                    Location = new Point(alien.X, alien.Y),
                    BorderStyle = BorderStyle.FixedSingle
                };

                alienPictureBoxes.Add(pb);
                this.Controls.Add(pb);
                alien.AddObserver(this); // El formulario observa a los aliens
            }
            

            _space = new Space_Ship(this.Size.Width / 2 - 30, 420);
            PictureBox playerBox = new PictureBox
            {
                Image = _space.Sprite,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Location = new Point(_space.X, _space.Y),
                Size = new Size(30, 30),
                BackColor = Color.Transparent
            };


            this.Controls.Add(playerBox);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        

        public void HandleBulletFired(Bullet bullet)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    PictureBox bulletBox = new PictureBox
                    {
                        Image = bullet.Sprite,
                        SizeMode = PictureBoxSizeMode.CenterImage,
                        Size = new Size(10, 20),
                        Location = new Point(bullet.X, bullet.Y),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    this.Controls.Add(bulletBox);
                    bulletPictureBoxes.Add(bulletBox);
                    bullet.AddObserver(this);
                });
            }

        }

        public void Update(Entityes entity)
        {
            if (this.IsHandleCreated)
            {
                if (entity is AlienShip alien)
                {
                    int index = aliens.IndexOf(alien);
                    if (index >= 0)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            alienPictureBoxes[index].Location = new Point(alien.X, alien.Y);
                            alienPictureBoxes[index].Image = alien.Sprite; // Cambiar sprite cuando se mueve
                            Console.WriteLine("Moviendo nave");
                        });
                    }
                }

                if (entity is Bullet bullet)
                {
                    int index = bullets.IndexOf(bullet);
                    if (index >= 0 )
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            bulletPictureBoxes[index].Location = new Point(bullet.X, bullet.Y);
                            bulletPictureBoxes[index].Image = bullet.Sprite;
                            
                            Console.WriteLine($"Moviendo bala");
                        });
                        

                    }
                    if (bullet.Y >= this.Height)
                    {
                        int index1 = bullets.IndexOf(bullet);

                        if (index1 >= 0 && index1 < bulletPictureBoxes.Count) // Validamos el índice
                        {
                            this.Controls.Remove(bulletPictureBoxes[index1]);
                            bulletPictureBoxes.RemoveAt(index1);
                        }

                        BulletController.RemoveBullet(bullet); // Eliminamos la bala del controlador
                        Console.WriteLine("Delete bullet");
                        bullets.Remove(bullet); // También eliminarla de la lista local
                    }


                }
            }


        }

    }
}
