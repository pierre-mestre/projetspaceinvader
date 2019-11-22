using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using SpaceInvaders;

namespace SpaceInvaders 
{
    class SpaceShip : SimpleObject
    {
        double speedPixelPerSecond = 10;

        Missile missile = null ;

        public SpaceShip(){
            this.speedPixelPerSecond = 200;
            this.position = new Vecteur2D(0, 0);
            this.lives = 0;
            this.missile = null;
            this.image = SpaceInvaders.Properties.Resources.ship3;
        }
        public SpaceShip(double speedPixelPerSecond, Vecteur2D position, int lives ){
            this.speedPixelPerSecond = speedPixelPerSecond;
            this.position = position;
            this.lives = lives;
            this.missile = null;
            this.image = SpaceInvaders.Properties.Resources.ship3;
        }

        public override void Update(Game gameInstance, double deltaT){
            if (gameInstance.keyPressed.Contains(Keys.Left))
            {
                if (this.position.X-speedPixelPerSecond<= 0){
                    this.position.X = 0;
                }else{
                    this.position.X=position.X-speedPixelPerSecond;
                }
                 gameInstance.ReleaseKey(Keys.Left);
            }
            if (gameInstance.keyPressed.Contains(Keys.Right))
            {
                if (this.position.X+speedPixelPerSecond >= gameInstance.gameSize.Width-this.image.Width){
                    this.position.X = gameInstance.gameSize.Width-this.image.Width;
                }else{
                    this.position.X=position.X+speedPixelPerSecond;
                }
                 gameInstance.ReleaseKey(Keys.Right);
            }
            if (gameInstance.keyPressed.Contains(Keys.Space))
            {
                
                    shoot();
                    GameObject newObject = this.missile;
                    gameInstance.AddNewGameObject(newObject);
                    gameInstance.ReleaseKey(Keys.Space);
               
                
            }

        }
     

        public void shoot()
        {
            if ( this.missile == null || this.missile.IsAlive() == false || this.missile.Position.Y <= 0)
            {
                this.missile = new Missile(this.position.X + 10, this.position.Y , 1, 3);
            }
            
        }

//g.DrawImage(image, position.X, position.Y, image.Width, image.Height);
    }
}
