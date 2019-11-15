using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using SpaceInvaders.Resources;

namespace SpaceInvaders
{
    class SpaceShip : GameObject
    {
        double speedPixelPerSecond = 10;
        Vecteur2D position = new Vecteur2D();
        int lives = 0;
        Bitmap image = SpaceInvaders.Properties.Resources.ship3;
        Missile missile = null ;

        public SpaceShip(){
            this.speedPixelPerSecond = 200;
            this.position.X = 0;
            this.position.Y = 0;
            this.lives = 0;
            this.missile = null;
        }
        public SpaceShip(double speedPixelPerSecond, double positionX, double positionY, int lives ){
            this.speedPixelPerSecond = speedPixelPerSecond;
            this.position.X = positionX;
            this.position.Y = positionY;
            this.lives = lives;
            this.missile = null;
        }

        public override void Update(Game gameInstance, double deltaT){
            if (gameInstance.keyPressed.Contains(Keys.Left))
            {
                if (this.position.X-speedPixelPerSecond<= 0){
                    this.position.X = 0;
                }else{
                    this.position.X=position.X-speedPixelPerSecond;
                }
            }
            if (gameInstance.keyPressed.Contains(Keys.Right))
            {
                if (this.position.X+speedPixelPerSecond >= gameInstance.gameSize.Width-this.image.Width){
                    this.position.X = gameInstance.gameSize.Width-this.image.Width;
                }else{
                    this.position.X=position.X+speedPixelPerSecond;
                }
            }
            if (gameInstance.keyPressed.Contains(Keys.Space))
            {
                
                    shoot();
                    GameObject newObject = this.missile;
                    gameInstance.AddNewGameObject(newObject);
                    gameInstance.ReleaseKey(Keys.Space);
               
                
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

        public void shoot()
        {
            if ( this.missile == null || this.missile.IsAlive() == false || this.missile.Position.Y <= 0)
            {
                this.missile = new Missile(this.position.X + 10, this.position.Y , 1, 1);
            }
            
        }

//g.DrawImage(image, position.X, position.Y, image.Width, image.Height);
    }
}
