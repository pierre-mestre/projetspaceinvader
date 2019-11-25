using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

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


        public EnemyBlock( int x, int y)
        {
            this.enemyShips = new HashSet<SpaceShip>();
            this.baseWidth = 400;
            this.size = new Size(baseWidth,y);
            this.position = new Vecteur2D(x-this.size.Width/2, y);
            this.bordure = x * 2;
        }
        public EnemyBlock(HashSet<SpaceShip> enemyShips , int baseWidth, Size size, Vecteur2D position, double vitesseParseconde, int x , int y)
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
            int espace = (this.size.Width - (nbShips * shipImage.Width))/(nbShips-1);
           

            for (int i = 0; i < nbShips; i++)
            {
                int positionX = ((this.size.Width / nbShips+1)*i);
                this.enemyShips.Add(new SpaceShip(this.vitesseParseconde, new Vecteur2D(positionX, this.position.Y+size.Height),1));
                //positionX = positionX + espace;

            }
            this.size = new Size(size.Width, enemyShips.Last().image.Height+10 + size.Height+10);
        }
        public void UpdateSize()
        {

        }
        public override void Update(Game gameInstance, double deltaT)
        {
          int direction = -1;

            if (this.position.X + size.Width + vitesseParseconde >= this.bordure || this.position.X + vitesseParseconde <= 0)
            {
                vitesseParseconde = (vitesseParseconde * direction);
                this.position.Y = this.position.Y + 3;
                vitesseParseconde = vitesseParseconde * 1.2;
            }
            else
            {
                this.position.X = this.position.X + vitesseParseconde;
            }
            
        }
        public override void Draw(Game gameInstance, Graphics graphics)
        {
            foreach (SpaceShip ennemy in this.enemyShips)
            {
                graphics.DrawImage(ennemy.image, (float)(ennemy.position.X + this.position.X), (float)(ennemy.position.Y + this.position.Y), ennemy.image.Width, ennemy.image.Height);
            }
            graphics.DrawRectangle(new Pen(Color.Red), new Rectangle((int)this.position.X, (int)this.position.Y, this.size.Width, this.size.Height));
        }
        public override bool IsAlive()
        {
            for( int i = 0; i<enemyShips.Count; i++)
            {
                if(enemyShips.ElementAt<SpaceShip>(i).IsAlive() == false)
                {
                    return false;
                }
            }
            return true;
        }

        public override void Collision(Missile m)
        {
           
        }
    }
}
