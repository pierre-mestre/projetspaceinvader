using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace SpaceInvaders
{
	class Missile : SimpleObject
	{
		double vitesse = 800;
        int direction = 1;
        internal Vecteur2D Position { get => position; set => position = value; }
        public int Lives { get => lives; set => lives = value; }
        public double Vitesse { get => vitesse; set => vitesse = value; }

        public Missile()
		{
			this.position = new Vecteur2D(200,200);
			this.vitesse = 1;
			this.lives = 3;
            this.image = SpaceInvaders.Properties.Resources.shoot1;
        }
		public Missile(double vitesse, int lives)
		{
			this.position = new Vecteur2D();
			this.vitesse = vitesse;
			this.lives = lives;
            this.image = SpaceInvaders.Properties.Resources.shoot1;
        }
		public Missile(double x, double y, double vitesse, int lives,int ID,int direction)
		{
			this.position = new Vecteur2D(x,y);
			this.vitesse = vitesse;
			this.lives = lives;
            this.image = SpaceInvaders.Properties.Resources.shoot1;
            this.ID = ID;
            this.direction = direction;
        }
		public Missile(double x, double y)
		{
			this.position = new Vecteur2D(x,y);
            this.image = SpaceInvaders.Properties.Resources.shoot1;
        }
		public override void Update(Game gameInstance, double deltaT){
			position.Y = position.Y+(vitesse*this.direction);
            foreach(GameObject gameObject in gameInstance.gameNewObjects)
            {
                gameObject.Collision(this);
            }
            if(this.ID == 1 && this.Position.Y <= 0)
            {
                //gameInstance.gameNewObjects.RemoveWhere(gameObject => !gameObject.IsAlive());
                this.lives = 0;
            }
            if(this.ID == 5 && this.Position.Y >= gameInstance.gameSize.Height)
            {
                //gameInstance.gameNewObjects.RemoveWhere(gameObject => !gameObject.IsAlive());
                this.lives = 0;
            }
            if (this.lives == 0)
            {
             //   gameInstance.gameNewObjects.RemoveWhere(gameObject => !gameObject.IsAlive());
            }
            
                 
        }

     

    }
}
