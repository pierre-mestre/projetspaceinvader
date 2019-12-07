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
       
        

        // 5=ennemie ; 2=Bunker ; 1 = player



        public SpaceShip(double speedPixelPerSecond, Vecteur2D position, int lives, int ID)
        {
            this.speedPixelPerSecond = speedPixelPerSecond;
            this.position = position;
            this.lives = lives;
            this.missile = null;
            this.image = SpaceInvaders.Properties.Resources.ship3;
            this.ID = ID;
        }
        public SpaceShip(double speedPixelPerSecond, Vecteur2D position, int lives, Bitmap image, int ID)
        {
            this.speedPixelPerSecond = speedPixelPerSecond;
            this.position = position;
            this.lives = lives;
            this.missile = null;
            this.image = image;
            this.ID = ID;
        }
        public override void Update(Game gameInstance, double deltaT)
        {
        
        }


        public void shoot(int direction, int lives, int ID, int size)
        {
            
            if ( this.missile == null || this.missile.IsAlive() == false )
            {
               if (direction == -1)
                {
                    this.missile = new Missile(this.position.X + 10, this.position.Y - this.image.Height, 1, lives, ID, direction);
                }
                else if (direction == 1)
                {
                    this.missile = new Missile(this.position.X + 10, this.position.Y + this.image.Height, 1, lives, ID, direction);
                }
                
            }
            
        }

//g.DrawImage(image, position.X, position.Y, image.Width, image.Height);
    }
}
