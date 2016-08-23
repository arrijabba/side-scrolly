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
    public class Menu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Image back;
        Image menu1;
        Image menu2;
        Image menu3;
        int timer1;

        int select = 1;

                public Menu(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }       
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            // need transparent Start/Exit images
            spriteFont = Game.Content.Load<SpriteFont>(@"Fonts/Score");
            menu1 = new Image(Game.Content.Load<Texture2D>(@"Images/start"),new Vector2(0, 0), new Point(250, 75), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 1);
            menu2 = new Image(Game.Content.Load<Texture2D>(@"Images/exit"), new Vector2(0, 75), new Point(250, 75), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 1); 
/*keep*/    back = new Image(Game.Content.Load<Texture2D>(@"Images/backfont"),new Vector2(100000, 1000000), new Point(250, 75), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 0);
            menu3 = new Image(Game.Content.Load<Texture2D>(@"Images/opt"), new Vector2(0, 150), new Point(250, 75), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 1); 


        }


        public override void Update(GameTime gameTime)
        {
            back.pos.X = menu1.pos.X;
            back.pos.Y = select * 75;


            timer1 += gameTime.ElapsedGameTime.Milliseconds;

            if (timer1 > 200)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down) == true)
                {
                    select += 1;
                    timer1 = 0;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Up) == true)
                {
                    select -= 1;
                    timer1 = 0;
                }
            }

            if (select <= 0)
                select = 0;
            if (select > 2)
                select = 2;

              
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
                    switch (select)
                    {
                        case 0:
                            // Start
                            ((Game1)Game).currentGameState = Game1.GameState.InGame; //use this

                            break;
                        case 1:
                            // exit
                            Game.Exit();

                            break;
                        case 2:
                            // opt

                            break;
                        case 3:
                            break;
                    }
            

                base.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend); // 1 in front // 


            menu1.Draw(gameTime, spriteBatch, 0, 0);
            menu2.Draw(gameTime, spriteBatch, 0, 0);
            menu3.Draw(gameTime, spriteBatch, 0, 0);
            back.Draw(gameTime, spriteBatch, 0, 1);


            spriteBatch.End();





            base.Draw(gameTime);
        }
    }
}
