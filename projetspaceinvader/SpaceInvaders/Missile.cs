using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace SpaceInvaders.Resources
{
	class Missile : GameObject
	{
		Vecteur2D position = new Vecteur2D();
		double vitesse = 800;
		int lives = 5;
		Bitmap image = SpaceInvaders.Properties.Resources.shoot1;

        internal Vecteur2D Position { get => position; set => position = value; }
        public int Lives { get => lives; set => lives = value; }
        public double Vitesse { get => vitesse; set => vitesse = value; }

        public Missile()
		{
			this.position = new Vecteur2D(200,200);
			this.vitesse = 1;
			this.lives = 5;
		}
		public Missile(double vitesse, int lives)
		{
			this.position = new Vecteur2D();
			this.vitesse = vitesse;
			this.lives = lives;
		}
		public Missile(double x, double y, double vitesse, int lives)
		{
			this.position = new Vecteur2D(x,y);
			this.vitesse = vitesse;
			this.lives = lives;
		}
		public Missile(double x, double y)
		{
			this.position = new Vecteur2D(x,y);
		}
		public override void Update(Game gameInstance, double deltaT){
			position.Y = position.Y-vitesse;
		}
		public override void Draw(Game gameInstance, Graphics graphics){
			graphics.DrawImage(image, Convert.ToSingle(position.X), Convert.ToSingle(position.Y), image.Width, image.Height);
		}
		public override bool IsAlive(){
			if (this.lives > 0){
				return true;
			}else{
				return false;
			}
		}
	}
}
