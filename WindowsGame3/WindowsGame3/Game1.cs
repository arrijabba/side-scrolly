using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public enum GameState { Start, InGame, GameOver, Exit };
        public  GameState currentGameState = GameState.Start;


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public SpriteManager spriteManager;
        static SpriteFont scoreFont;
        public Random rnd { get; private set; }
        public WeaponManager weaponManager;
        private Menu startMenu;
        public PowerUpManager powerUpManager;

        public Game1()
        {
            rnd = new Random();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 1024;
        }

        protected override void Initialize()
        {
            spriteManager = new SpriteManager(this);
            Components.Add(spriteManager);
            weaponManager = new WeaponManager(this);
            Components.Add(weaponManager);
            startMenu = new Menu(this);
            Components.Add(startMenu);
            powerUpManager = new PowerUpManager(this);
            Components.Add(powerUpManager);


            base.Initialize();
        }
        // LoadContent will be called once per game and is the place to load

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            scoreFont = Content.Load<SpriteFont>(@"Fonts/Score");
            // the @ symbol makes it so escape sequences are unneeded

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {

            switch (currentGameState)
            {
                case GameState.Start:
                    spriteManager.Enabled = false;
                    spriteManager.Visible = false;

                    weaponManager.Enabled = false;
                    weaponManager.Visible = false;
                    
                    powerUpManager.Enabled = false;
                    powerUpManager.Visible = false;

                    startMenu.Enabled = true;
                    startMenu.Visible = true;

                    
                    

                    break;

                case GameState.InGame:

                    spriteManager.Enabled = true;
                    spriteManager.Visible = true;

                    weaponManager.Enabled = true;
                    weaponManager.Visible = true;

                    
                    powerUpManager.Enabled = true;
                    powerUpManager.Visible = true;

                    startMenu.Enabled = false;
                    startMenu.Visible = false;


                    break;

                case GameState.GameOver:

                    this.Exit();

                    break;
            }


            IsMouseVisible = true;

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //pos2.X += speed1;
            //if (pos2.X > (Window.ClientBounds.Width - texture.Width) || pos2.X < 0)
            //    speed1 *= -1;

            //pos2.Y += speed2;

            //if (pos2.Y > (Window.ClientBounds.Height - texture.Height) || pos2.Y < 0)
            //    speed2 *= -1;

            MouseState mousestate = Mouse.GetState();

            //    if (mousestate.X != prevmouseState.X || mousestate.Y != prevmouseState.Y)
            //    {  pos1 = new Vector2(mousestate.X, mousestate.Y);
            //        prevmouseState = mousestate;
            //}
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            switch (currentGameState)
            {
                case GameState.Start:
                    break;
                case GameState.InGame:
                    break;
                case GameState.GameOver:
                    break;
            }


            // GraphicsDevice.Clear(Color.Purple);

            //spriteBatch.Begin();
            //spriteBatch.DrawString(scoreFont, "HEY HI HOW YA DOIN", new Vector2(50, 70), Color.White);
            //spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
