using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    abstract class SimpleObject : GameObject
    {
        public Bitmap image; 
        public Vecteur2D position= new Vecteur2D();
        public int lives;
        public int ID = 0;

        public int Lives { get => lives; set => lives = value; }
        internal Vecteur2D Position { get => position; set => position = value; }

        public override void Draw(Game gameInstance, Graphics graphics)
        {
            graphics.DrawImage(image, (float) position.X, (float) position.Y, image.Width, image.Height);
        }
        public override bool IsAlive()
        {
            if (this.lives > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Collision(Missile m)
        {
            
        }
    }
   
}
