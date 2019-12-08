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
            this.ID = 2;
        }
   
        public override void Update(Game gameInstance, double deltaT)
        {

        }


        public override void Collision(Missile m)
        {
            //fait avec l'aide de Thibault

            double positionMissileX = m.Position.X;
            double positionMissileY = m.Position.Y;
            double MissileXBoundary = positionMissileX + this.image.Width;
            double MissileYBoundary = positionMissileY + this.image.Height;

            double positionBunkerX = this.position.X;
            double positionBunkerY = this.position.Y;
            double BunkerXBoundary = positionBunkerX + this.image.Width;
            double BunkerYBoundary = positionBunkerY + this.image.Height;


              if (IsOnTheRight(positionBunkerX, MissileXBoundary) || IsOnTheRight(positionMissileX, BunkerXBoundary) || IsAbove(positionBunkerY, MissileYBoundary) || IsAbove(positionMissileY, BunkerYBoundary))
              {
                  return;
              }
            for (int x = 0; x < m.image.Width; x++)
            {
                for (int y = 0; y < m.image.Height; y++)
                {
                    double PixelPosX = positionMissileX + x;
                    double PixelPosY = positionMissileY + y;

                    if (IsOnTheRight(PixelPosX, BunkerXBoundary) || IsOnTheRight(positionBunkerX, PixelPosX) || IsAbove(PixelPosY, BunkerYBoundary) || IsAbove(positionBunkerY, PixelPosY))
                    {
                        continue;
                    }
                    int MissilePixelOnBunkerPosX = (int)(PixelPosX - positionBunkerX);
                    int MissilePixelOnBunkerPosY = (int)(PixelPosY - positionBunkerY);

                    Color pixelColor = this.image.GetPixel(MissilePixelOnBunkerPosX, MissilePixelOnBunkerPosY);

                    //Console.WriteLine("pixel touche");
                    if (pixelColor.A == 255 && this.ID != m.ID)
                    {
                        this.image.SetPixel(MissilePixelOnBunkerPosX, MissilePixelOnBunkerPosY, Color.Transparent);
                        m.lives--;
                    }

                }
            }
            IsAlive();


        }

        public bool IsOnTheRight(double PosXa, double PosXb)
        {
            if (PosXa >= PosXb)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsAbove(double PosYa, double PosYb)
        {
            if (PosYa >= PosYb)
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
