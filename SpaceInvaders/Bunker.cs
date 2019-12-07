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

            double MPosX = m.Position.X;
            double MPosY = m.Position.Y;
            double MissileXBoundary = MPosX + this.image.Width;
            double MissileYBoundary = MPosY + this.image.Height;

            double BPosX = this.position.X;
            double BPosY = this.position.Y;
            double BunkerXBoundary = BPosX + this.image.Width;
            double BunkerYBoundary = BPosY + this.image.Height;


              if (IsOnTheRight(BPosX, MissileXBoundary) || IsOnTheRight(MPosX, BunkerXBoundary) || IsAbove(BPosY, MissileYBoundary) || IsAbove(MPosY, BunkerYBoundary))
              {
                  return;
              }
            for (int x = 0; x < m.image.Width; x++)
            {
                for (int y = 0; y < m.image.Height; y++)
                {
                    double PixelPosX = MPosX + x;
                    double PixelPosY = MPosY + y;

                    if (IsOnTheRight(PixelPosX, BunkerXBoundary) || IsOnTheRight(BPosX, PixelPosX) || IsAbove(PixelPosY, BunkerYBoundary) || IsAbove(BPosY, PixelPosY))
                    {
                        continue;
                    }
                    int MissilePixelOnBunkerPosX = (int)(PixelPosX - BPosX);
                    int MissilePixelOnBunkerPosY = (int)(PixelPosY - BPosY);

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
