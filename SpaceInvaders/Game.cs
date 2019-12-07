using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Game
    {
        public Size gameSize;
        PlayerSpaceship playerShip;
        private EnemyBlock enemies;
      
        enum GameState  {PLAY, PAUSE, WIN, LOST};
        GameState state;


        #region GameObjects management
        /// <summary>
        /// Set of all game objects currently in the game
        /// </summary>
        public HashSet<GameObject> gameNewObjects = new HashSet<GameObject>();

        /// <summary>
        /// Set of new game objects scheduled for addition to the game
        /// </summary>
        private HashSet<GameObject> pendingNewGameObjects = new HashSet<GameObject>();

        /// <summary>
        /// Schedule a new object for addition in the game.
        /// The new object will be added at the beginning of the next update loop
        /// </summary>
        /// <param name="gameObject">object to add</param>
        public void AddNewGameObject(GameObject gameObject)
        {
            pendingNewGameObjects.Add(gameObject);
        }
        #endregion

        #region game technical elements
        /// <summary>
        /// Size of the game area
        /// </summary>
        

        /// <summary>
        /// State of the keyboard
        /// </summary>
        public HashSet<Keys> keyPressed = new HashSet<Keys>();

        #endregion

        #region static fields (helpers)

        /// <summary>
        /// Singleton for easy access
        /// </summary>
        public static Game game { get; private set; }

        /// <summary>
        /// A shared black brush
        /// </summary>
        private static Brush blackBrush = new SolidBrush(Color.Black);

        /// <summary>
        /// A shared simple font
        /// </summary>
        private static Font defaultFont = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);
        #endregion


        #region constructors
        /// <summary>
        /// Singleton constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        /// 
        /// <returns></returns>
        public static Game CreateGame(Size gameSize)
        {
            if (game == null)
                game = new Game(gameSize);
            return game;
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        private Game(Size gameSize)
        {
            this.playerShip = new PlayerSpaceship(5, new Vecteur2D(gameSize.Width / 2 - 12, gameSize.Height - 26), 10, 1);
            this.gameSize = gameSize;
            Bunker bunker1 = new Bunker(new Vecteur2D(gameSize.Width*0.3-87, 500));
            Bunker bunker2 = new Bunker(new Vecteur2D(gameSize.Width/ 2 - 44 , 500));
            Bunker bunker3 = new Bunker(new Vecteur2D((gameSize.Width*0.85) -87, 500));
            this.enemies = new EnemyBlock(gameSize.Width/2,10);
            this.enemies.AddLine(5, 1, SpaceInvaders.Properties.Resources.ship8);
            this.enemies.AddLine(5, 1, SpaceInvaders.Properties.Resources.ship1);
            this.enemies.AddLine(5, 1, SpaceInvaders.Properties.Resources.ship8);
            this.enemies.AddLine(5, 1, SpaceInvaders.Properties.Resources.ship9);
            gameNewObjects.Add(playerShip);
            gameNewObjects.Add(bunker1);
            gameNewObjects.Add(bunker2);
            gameNewObjects.Add(bunker3);
            gameNewObjects.Add(enemies);
        }

        #endregion
     
        #region methods

        /// <summary>
        /// Force a given key to be ignored in following updates until the user
        /// explicitily retype it or the system autofires it again.
        /// </summary>
        /// <param name="key">key to ignore</param>
        public void ReleaseKey(Keys key)
        {
            keyPressed.Remove(key);
        }


        /// <summary>
        /// Draw the whole game
        /// </summary>
        /// <param name="g">Graphics to draw in</param>
        public void Draw(Graphics g)
        {
          
            Font drawFont = new Font("Arial", 20);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.
            float x = gameSize.Width/2-(state.ToString().Length*10);
            float y = gameSize.Height / 2;
            float xW = (gameSize.Width / 2) - 100;
            float yW = gameSize.Height / 2;
            float xL = (gameSize.Width / 2) - 100;
            float yL = gameSize.Height / 2;
            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;

            // Draw string to screen.
            if (state == GameState.PAUSE)
            {
                g.DrawString(state.ToString(), drawFont, drawBrush, x, y, drawFormat);
            }
            if (playerShip.lives < 0)
            {
                playerShip.lives = 0;
            }
            g.DrawString("VIES: "+playerShip.lives.ToString(), drawFont ,drawBrush, 0, gameSize.Height-30, drawFormat);
         
            foreach (GameObject gameObject in gameNewObjects)
            {
                gameObject.Draw(this, g);
            }
            if (state == GameState.WIN)
            {
                g.DrawString("PARTIE GAGNEE", drawFont, drawBrush, xW, yW, drawFormat);
            }
            if (state == GameState.LOST)
            {
                g.DrawString("PARTIE PERDUE", drawFont, drawBrush, xL, yL, drawFormat);
            }

        }

        /// <summary>
        /// Update game
        /// </summary>
        /// 


        public void Update(double deltaT)
        {
            if (state == GameState.PLAY)
            {

                // add new game objects
                gameNewObjects.UnionWith(pendingNewGameObjects);
                pendingNewGameObjects.Clear();
                // GameObject spaceShip = this.playerShip;
                /*AddNewGameObject(bunker1);
                AddNewGameObject(bunker2);
                AddNewGameObject(bunker3);
                AddNewGameObject(playerShip);
                */
                if (keyPressed.Contains(Keys.P))
                {
                    if (state == GameState.PLAY)
                    {
                        state = GameState.PAUSE;
                    }
                    else if (state == GameState.PAUSE)
                    {
                        state = GameState.PLAY;
                    }
                    ReleaseKey(Keys.P);

                }


                // update each game object
                foreach (GameObject gameObject in gameNewObjects)
                {
                    gameObject.Update(this, deltaT);
                }

                // remove dead objects
                gameNewObjects.RemoveWhere(gameObject => !gameObject.IsAlive());

                if (playerShip.IsAlive() == false)
                {
                    state = GameState.LOST;
                }
                foreach (SpaceShip s in enemies.EnemyShips)
                {
                    if (s.Position.Y >= gameSize.Height)
                    {
                        state = GameState.LOST;
                    }
                }
                if (enemies.checkLiveBlock() == false)
                {
                    state = GameState.WIN;
                }


            }
            else if (state == GameState.PAUSE)
            {
                if (keyPressed.Contains(Keys.P))
                {
                    if (state == GameState.PLAY)
                    {
                        state = GameState.PAUSE;
                    }
                    else if (state == GameState.PAUSE)
                    {
                        state = GameState.PLAY;
                    }
                    ReleaseKey(Keys.P);

                }
            }
            else if (state == GameState.LOST || state == GameState.WIN)
            {

            }
        }
        #endregion
    }
}
