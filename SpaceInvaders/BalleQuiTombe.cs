﻿  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    /// <summary>
    /// Dummy class for demonstration
    /// </summary>
    class BalleQuiTombe : GameObject
    {
        #region Fields
        /// <summary>
        /// Position
        /// </summary>
        private double x, y;

        /// <summary>
        /// Radius
        /// </summary>
        private double radius = 10;

        /// <summary>
        /// Ball speed in pixel/second
        /// </summary>
        private double ballSpeed = 100;

        /// <summary>
        /// A shared black pen for drawing
        /// </summary>
        private static Pen pen = new Pen(Color.Black);

        private bool alive = true;

        #endregion

        #region Constructor
        /// <summary>
        /// Simple constructor
        /// </summary>
        /// <param name="x">start position x</param>
        /// <param name="y">start position y</param>
        public BalleQuiTombe(double x, double y) : base()
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Methods

        public override void Update(Game gameInstance, double deltaT)
        {
            y += ballSpeed * deltaT;
            if (y > gameInstance.gameSize.Height)
                alive = false;

            if (gameInstance.keyPressed.Contains(Keys.Left))
            {
                x = x - 1;
            }
            if (gameInstance.keyPressed.Contains(Keys.Right))
            {
                x = x + 1;
            }
        }

        public override void Draw(Game gameInstance, Graphics graphics)
        {
            float xmin = (float)(x - radius);
            float ymin = (float)(y - radius);
            float width = (float)(2 * radius);
            float height = (float)(2 * radius);
            graphics.DrawEllipse(pen, xmin, ymin, width, height);
        }

        public override bool IsAlive()
        {
            return alive;
        }

        public override void Collision(Missile m)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
