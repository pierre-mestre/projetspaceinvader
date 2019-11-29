using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using SpaceInvaders;

namespace SpaceInvaders 
{
    class SpaceShip : SimpleObject
    {
        public double speedPixelPerSecond = 10;

        public Missile missile = null ;

        public SpaceShip(){
            this.speedPixelPerSecond = 200;
            this.position = new Vecteur2D(0, 0);
            this.lives = 0;
            this.missile = null;
            this.image = SpaceInvaders.Properties.Resources.ship3;
        }
        public SpaceShip(double speedPixelPerSecond, Vecteur2D position, int lives ){
            this.speedPixelPerSecond = speedPixelPerSecond;
            this.position = position;
            this.lives = lives;
            this.missile = null;
            this.image = SpaceInvaders.Properties.Resources.ship3;
        }
        public SpaceShip(double speedPixelPerSecond, Vecteur2D position, int lives, Bitmap image)
        {
            this.speedPixelPerSecond = speedPixelPerSecond;
            this.position = position;
            this.lives = lives;
            this.missile = null;
            this.image = image;
        }
        public override void Update(Game gameInstance, double deltaT)
        {
        }


        public void shoot()
        {
            if ( this.missile == null || this.missile.IsAlive() == false || this.missile.Position.Y <= 0)
            {
                this.missile = new Missile(this.position.X + 10, this.position.Y ,1,3);
            }
            
        }

//g.DrawImage(image, position.X, position.Y, image.Width, image.Height);
    }
}
