using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SpaceInvaders
{
    class EnemyBlock : GameObject
    {
        HashSet<SpaceShip> enemyShips;
        int baseWidth;
        Size size;
        Vecteur2D position;
        double vitesseParseconde = 0.1;
        int bordure = 0;


        public EnemyBlock(int x, int y)
        {
            this.enemyShips = new HashSet<SpaceShip>();
            this.baseWidth = 400;
            this.size = new Size(baseWidth, y);
            this.position = new Vecteur2D(x - this.size.Width / 2, y);
            this.bordure = x * 2;
        }
        public EnemyBlock(HashSet<SpaceShip> enemyShips, int baseWidth, Size size, Vecteur2D position, double vitesseParseconde, int x, int y)
        {
            this.enemyShips = enemyShips;
            this.baseWidth = baseWidth;
            this.size = size;
            this.position = position;
            this.vitesseParseconde = vitesseParseconde;
            this.bordure = x * 2;

        }

        public void AddLine(int nbShips, int nbLives, Bitmap shipImage)
        {
            int espace = (this.size.Width - (nbShips * shipImage.Width)) / (nbShips - 1);


            for (int i = 0; i < nbShips; i++)
            {
                int positionX = (((this.size.Width / nbShips + 1) * i));
                this.enemyShips.Add(new SpaceShip(this.vitesseParseconde, new Vecteur2D(positionX+this.position.X, this.position.Y + this.size.Height), 10, shipImage));
                //positionX = positionX + espace;
            }
            this.size = new Size(size.Width, enemyShips.Last().image.Height + 10 + size.Height + 10);
        }
        public void UpdateSize()
        {

        }
        public override void Update(Game gameInstance, double deltaT)
        {
            for (int i = 0; i < this.enemyShips.Count; i++)
            {
              //  Console.WriteLine(enemyShips.ElementAt<SpaceShip>(i).position.X.ToString());
            }
          //  Console.WriteLine("--------------------------------------------------------------------------------");
        }
        public override void Draw(Game gameInstance, Graphics graphics)
        {
            foreach (SpaceShip ennemy in this.enemyShips)
            {
                graphics.DrawImage(ennemy.image, (float)(ennemy.position.X), (float)(ennemy.position.Y), ennemy.image.Width, ennemy.image.Height);
                Console.WriteLine(ennemy.position.X.ToString());
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
            graphics.DrawRectangle(new Pen(Color.Red), new Rectangle((int)this.position.X, (int)this.position.Y, this.size.Width, this.size.Height));
        }
        public override bool IsAlive()
        {
            for (int i = 0; i < enemyShips.Count; i++)
            {
                if (enemyShips.ElementAt<SpaceShip>(i).IsAlive() == false)
                {
                    enemyShips.Remove(enemyShips.ElementAt<SpaceShip>(i));
                    //enemyShips.ElementAt<SpaceShip>(i).Lives--;
                }
            }
            return enemyShips.Count > 0;
        }

        public override void Collision(Missile m)
        {
            for (int i = 0; i < this.enemyShips.Count; i++)
            {
                double MPosX = m.Position.X;
                double MPosY = m.Position.Y;
                double MissileXBoundary = MPosX + this.enemyShips.ElementAt<SpaceShip>(i).image.Width;
                double MissileYBoundary = MPosY + this.enemyShips.ElementAt<SpaceShip>(i).image.Height;

                double BPosX = this.enemyShips.ElementAt<SpaceShip>(i).position.X;
                double BPosY = this.enemyShips.ElementAt<SpaceShip>(i).position.Y;
                double BunkerXBoundary = BPosX + this.enemyShips.ElementAt<SpaceShip>(i).image.Width;
                double BunkerYBoundary = BPosY + this.enemyShips.ElementAt<SpaceShip>(i).image.Height;


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

                        Color pixelColor = this.enemyShips.ElementAt<SpaceShip>(i).image.GetPixel(MissilePixelOnBunkerPosX, MissilePixelOnBunkerPosY);

                        Console.WriteLine("pixel touche");
                            this.enemyShips.ElementAt<SpaceShip>(i).lives=0;
                                    m.lives--;
                        
                    }
                }
                IsAlive();
            }

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
