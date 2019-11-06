using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceInvaders
{
	class SpaceShip : GameObject
	{
		double speedPixelPerSecond = 10;
		Vecteur2D position = new Vecteur2D();
        int lives = 0;
		Bitmap image = SpaceInvaders.Properties.Resources.ship3;

        public SpaceShip(){
        	this.speedPixelPerSecond = 10;
            this.position.X = 0;
            this.position.Y = 0;
            this.lives = 0;
        }
         public SpaceShip(double speedPixelPerSecond, double positionX, double positionY, int lives ){
        	this.speedPixelPerSecond = speedPixelPerSecond;
            this.position.X = positionX;
            this.position.Y = positionY;
            this.lives = lives;
        }

        public override void Update(Game gameInstance, double deltaT){
            //TO DOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
             if (keyPressed.Contains(Keys.left))
            {
                // create new BalleQuiTombe
                this.position.X=position.X;
               
                // add it to the game
                AddNewGameObject(newObject);
                // release key space (no autofire)
                ReleaseKey(Keys.Space);
            }

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

		//g.DrawImage(image, position.X, position.Y, image.Width, image.Height);
	}
}
