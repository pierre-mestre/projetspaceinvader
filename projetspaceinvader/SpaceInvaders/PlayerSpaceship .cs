using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class PlayerSpaceship : SpaceShip
    {
        public PlayerSpaceship(double speedPixelPerSecond, Vecteur2D position, int lives) : base(speedPixelPerSecond, position, lives)
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

                shoot();
                GameObject newObject = this.missile;
                gameInstance.AddNewGameObject(newObject);
                gameInstance.ReleaseKey(Keys.Space);


            }
            else
            {

            }

        }
    }
}
