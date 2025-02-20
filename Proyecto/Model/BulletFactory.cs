using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Model
{
    public static class BulletFactory
    {
        private static readonly Image[] bulletSprites = new Image[]
        {
            Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Projectiles\\ProjectileA_1.png"),
            Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Projectiles\\ProjectileA__2.png"),
            Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Projectiles\\ProjectileA_3.png"),
            Image.FromFile("C:\\Users\\User\\Documents\\Final-Poryecto\\Proyect\\Proyecto\\Assets\\Sprites\\Projectiles\\ProjectileA_4.png")
        };
        public static Bullet CreateBullet(int x, int y, bool movingDown)
        {
            return new Bullet(x, y, movingDown, bulletSprites);

        }
    }
}
