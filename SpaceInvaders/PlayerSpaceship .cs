using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class PlayerSpaceship : SpaceShip
    {
        public PlayerSpaceship(double speedPixelPerSecond, Vecteur2D position, int lives, int ID) : base(speedPixelPerSecond, position, lives, ID)
        {
        }

        public override void Update(Game gameInstance, double deltaT)
        {

            if (gameInstance.keyPressed.Contains(Keys.Left))
            {
                if (this.position.X - speedPixelPerSecond <= 0)
                {
                    this.position.X = 0;
                }
                else
                {
                    this.position.X = position.X - speedPixelPerSecond;
                }
                gameInstance.ReleaseKey(Keys.Left);
            }
            if (gameInstance.keyPressed.Contains(Keys.Right))
            {
                if (this.position.X + speedPixelPerSecond >= gameInstance.gameSize.Width - this.image.Width)
                {
                    this.position.X = gameInstance.gameSize.Width - this.image.Width;
                }
                else
                {
                    this.position.X = position.X + speedPixelPerSecond;
                }
                gameInstance.ReleaseKey(Keys.Right);
            }
            if (gameInstance.keyPressed.Contains(Keys.Space))
            {

                shoot(-1, 3, 1, gameInstance.gameSize.Height);
                GameObject newObject = this.missile;
                gameInstance.AddNewGameObject(newObject);
                gameInstance.ReleaseKey(Keys.Space);


            }
            else
            {

            }
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


                /*  if (IsOnTheRight(BPosX, MissileXBoundary) || IsOnTheRight(MPosX, BunkerXBoundary) || IsAbove(BPosY, MissileYBoundary) || IsAbove(MPosY, BunkerYBoundary))
                  {
                      return;
                  }*/
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
                            this.lives--;
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

