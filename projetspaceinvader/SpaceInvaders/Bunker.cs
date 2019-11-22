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
                return false;
            }
            else
            {
                return true;
            }

        }

        public void collisionPixel(Missile m)
        {
            Vecteur2D start = m.Position - this.Position;

            for (int i = 0; i < m.image.Width && (int)(i+start.X) < this.image.Width-1; i++)
            {
                for (int j = 0; start.Y > -1 && j < m.image.Height && (int)(j+start.Y) < this.image.Height-1; j++)
                {
                    this.image.SetPixel((int)(i+start.X), (int)(j+start.Y), Color.FromArgb(0, 255, 255, 255));
                    
                    /*Vecteur2D positionFromScreen = new Vecteur2D(i, j) + m.position;
                    Vecteur2D positionPixelImage = this.position-m.position;
                    if (positionPixelImage.X >= this.position.X && 
                        positionPixelImage.Y >= this.position.Y && 
                        positionPixelImage.X <= Math.Min(this.position.X + this.image.Width, this.image.Width) && 
                        positionPixelImage.Y <= Math.Min(this.position.Y + this.image.Height,this.image.Height))
                    {
                        if (this.image.GetPixel((int)positionPixelImage.X, (int)positionPixelImage.Y) == Color.FromArgb(255, 0, 0, 0))
                        {
                            this.image.SetPixel((int)positionPixelImage.X, (int)positionPixelImage.Y, Color.FromArgb(0, 255, 255, 255));
                        }
                    }*/
                }
            }
        }
    }
}
