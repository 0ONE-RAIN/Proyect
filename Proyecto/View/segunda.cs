using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.Model;
using Proyecto.ModelView;

namespace Proyecto.View
{
    public partial class segunda : Form
    {

        private Space_Ship _space;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private List<PictureBox> alienPictureBox = new List<PictureBox>();
        private AlienController alienController;

        public segunda()
        {
            InitializeComponent();
            startGame();
        }

        private void startGame()
        {
            alienController = new AlienController();
             var AlienShip = AlienFactory.CreateAlien1();
            foreach (var alien in AlienShip )
            {
                PictureBox pb = new PictureBox
                {
                    Image = alien.sprite,
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Size = new Size(25, 25),
                    Location = new System.Drawing.Point(alien._PosX, alien._PosY),
                    BorderStyle = BorderStyle.FixedSingle

                };
                alienPictureBox.Add(pb);
                this.Controls.Add(pb);
            }
            _space = new Space_Ship(this.Size.Width / 2 - 30 , 420);
            pictureBox1 = new PictureBox
            {
                Image = _space.sprite,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Location = new Point(_space._PosX, _space._PosY),
                Size = new Size(30, 30),
                BorderStyle = BorderStyle.FixedSingle
                
            };
            pictureBox2 = new PictureBox
            {

            };
            this.Controls.Add(pictureBox1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        
        } 
        

        
    }
}
