using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Bunker : SimpleObject
    {


        public Bunker(Vecteur2D position)
        {
            this.position = position;
            this.lives = 10;
            this.image = SpaceInvaders.Properties.Resources.bunker;
        }

        public override void Update(Game gameInstance, double deltaT)
        {

        }
        public override void Collision(Missile m)
        {
            if (collisionRectangle(m) == true){
                collisionPixel(m);
            }
        }

        public bool collisionRectangle(Missile m)
        {
            if (m.position.X > this.position.X + this.image.Width || m.position.Y > this.position.Y + this.image.Height || this.position.X > m.position.X + m.image.Width || this.position.Y > m.position.Y + m.image.Height)
            {
                //Console.WriteLine("Sylvie la BEST <3");
                return true;
            }
            else
            {
                return false;
            }

        }

        public void collisionPixel(Missile m)
        {
            for (int i = 0; i < m.image.Width; i++)
            {
                for (int j = 0; j < m.image.Height; j++)
                {
                    if ()
                    {
                        Vecteur2D positionPixelImage = new Vecteur2D(m.position.X + i - this.position.X + i, m.position.Y + j - this.position.Y + j);
                        if (this.image.GetPixel((int)positionPixelImage.X, (int)positionPixelImage.Y) == Color.FromArgb(255, 0, 0, 0))
                        {
                            this.image.SetPixel((int)positionPixelImage.X, (int)positionPixelImage.Y, Color.FromArgb(255, 255, 255, 255));
                        }
                    }
                }
            }
        }
    }
}
