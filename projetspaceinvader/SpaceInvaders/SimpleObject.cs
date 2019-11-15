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
        public Vecteur2D position = new Vecteur2D();
        public int lives = 5;

        public int Lives { get => lives; set => lives = value; }
        internal Vecteur2D Position { get => position; set => position = value; }

        public override void Draw(Game gameInstance, Graphics graphics)
        {
            graphics.DrawImage(image, Convert.ToSingle(position.X), Convert.ToSingle(position.Y), image.Width, image.Height);
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
    }
   
}
