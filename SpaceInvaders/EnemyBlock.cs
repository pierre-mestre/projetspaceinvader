using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

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
        double randomShootProbability = 0.001;

        Random r = new Random();

        internal HashSet<SpaceShip> EnemyShips { get => enemyShips; set => enemyShips = value; }

        public EnemyBlock(int x, int y)
        {
            this.enemyShips = new HashSet<SpaceShip>();
            this.baseWidth = 400;
            this.size = new Size(x, y);
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
                int positionX = (((this.size.Width / nbShips + 1) * i))+shipImage.Width;
                this.enemyShips.Add(new SpaceShip(this.vitesseParseconde, new Vecteur2D(positionX+this.position.X, this.position.Y + this.size.Height), nbLives, shipImage,5));
                //positionX = positionX + espace;
            }
            this.size = new Size(size.Width, enemyShips.Last().image.Height + 10 + size.Height + 10);
        }
        public void UpdateSize()
        {

        }
        public override void Update(Game gameInstance, double deltaT)
        {
            /* for (int i = 0; i < this.enemyShips.Count; i++)
             {
               //  Console.WriteLine(enemyShips.ElementAt<SpaceShip>(i).position.X.ToString());
             }
           //  Console.WriteLine("--------------------------------------------------------------------------------");
           */
           
            foreach (SpaceShip ships in this.enemyShips)
            {
                if (ships.IsAlive())
                {
                    ships.Position.X += this.vitesseParseconde;
                }
            }

            this.updateposition();

            foreach (SpaceShip ships in this.enemyShips)
            {
                if (r.NextDouble() <= randomShootProbability)
                {

                    ships.shoot(1, 1, 5, gameInstance.gameSize.Height);
                    GameObject newObject = ships.missile;
                    gameInstance.AddNewGameObject(newObject);
                    

                }
            }
            if (this.position.X + this.size.Width >= gameInstance.gameSize.Width || this.position.X <= 0)
            {
                this.vitesseParseconde = this.vitesseParseconde * (-1.05);
                foreach(SpaceShip ships in this.enemyShips)
                {
                    ships.Position.Y += 10;
                   // ships.Position.X += this.vitesseParseconde;
                }
                this.randomShootProbability *= 1.01;
                /*
                if (randomShootProbability > 0.3)
                {
                    randomShootProbability = 0.001;
                }*/

             
            }

        }
       
          

        
        public void updateposition()
        {
            // fait avec l'aide de sylvie
            double variableX = this.enemyShips.ElementAt<SpaceShip>(0).Position.X;
            double variableY = this.enemyShips.ElementAt<SpaceShip>(0).Position.Y;
            int size = 0;
            foreach (SpaceShip ships in this.enemyShips)
            {
                if (variableX > ships.Position.X)
                {
                    variableX = ships.Position.X;
                    //size = ships.image.Width;
                }
                
               /* if (variableX > ships.Position.Y)
                {
                    variableY = ships.Position.Y;
                }
                */
            }
            
            this.position.X = variableX - size / 2;
            this.position.Y = variableY;
        }

        public override void Draw(Game gameInstance, Graphics graphics)
        {
            foreach (SpaceShip ennemy in this.enemyShips)
            {
                graphics.DrawImage(ennemy.image, (float)(ennemy.position.X), (float)(ennemy.position.Y), ennemy.image.Width, ennemy.image.Height);
              //  Console.WriteLine(ennemy.position.X.ToString());
            }
            //Console.WriteLine("--------------------------------------------------------------------------------");
           // graphics.DrawRectangle(new Pen(Color.Red), new Rectangle((int)this.position.X, (int)this.position.Y, this.size.Width, this.size.Height));
        }
        public override bool IsAlive()
        {
            
               return enemyShips.Count >= 0;
        }
        public bool checkLiveBlock()
        {
            foreach (SpaceShip ennemy in this.enemyShips)
            {
                if(ennemy.Lives > 0)
                {
                    return true;
                }
            }
                return false;
        }
        public override void Collision(Missile m)
        {
            for (int i = 0; i < this.enemyShips.Count; i++)
            {
                double positionMissileX = m.Position.X;
                double positionMissileY = m.Position.Y;
                double MissileXBoundary = positionMissileX + this.enemyShips.ElementAt<SpaceShip>(i).image.Width;
                double MissileYBoundary = positionMissileY + this.enemyShips.ElementAt<SpaceShip>(i).image.Height;

                double positionBunkerX = this.enemyShips.ElementAt<SpaceShip>(i).position.X;
                double positionBunkerY = this.enemyShips.ElementAt<SpaceShip>(i).position.Y;
                double BunkerXBoundary = positionBunkerX + this.enemyShips.ElementAt<SpaceShip>(i).image.Width;
                double BunkerYBoundary = positionBunkerY + this.enemyShips.ElementAt<SpaceShip>(i).image.Height;


              /*  if (IsOnTheRight(BPosX, MissileXBoundary) || IsOnTheRight(MPosX, BunkerXBoundary) || IsAbove(BPosY, MissileYBoundary) || IsAbove(MPosY, BunkerYBoundary))
                {
                    return;
                }*/
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

                        Color pixelColor = this.enemyShips.ElementAt<SpaceShip>(i).image.GetPixel(MissilePixelOnBunkerPosX, MissilePixelOnBunkerPosY);

                       //Console.WriteLine("pixel touche");
                       if(pixelColor.A == 255 && this.enemyShips.ElementAt<SpaceShip>(i).ID != m.ID)
                        {
                            this.enemyShips.ElementAt<SpaceShip>(i).lives --;
                            m.lives--;
                        }

                    }
                }
                for (int z = 0;z < enemyShips.Count; z++)
                {
                    if (enemyShips.ElementAt<SpaceShip>(z).IsAlive() == false)
                    {
                        enemyShips.Remove(enemyShips.ElementAt<SpaceShip>(z));
                        //enemyShips.ElementAt<SpaceShip>(i).Lives--;
                        z--;
                    }
                }
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
