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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class WeaponManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private int timeSinceLastFire = 10000;
        private int millisecPerFire = 500;
        public UserControlledSprite player;
        public Weapon weap1;
        public Weapon weap2;
        public Weapon weap3;
        public Weapon weap4;
        public Weapon weap5;
        public Weapon weap1f;
        public Weapon weap2f;
        public Weapon weap3f;
        public Weapon weap4f;
        public Weapon weap5f;
        public SpriteBatch spriteBatch;

        
        public List<Weapon> bulletList = new List<Weapon>();


        public WeaponManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            timeSinceLastFire = 10000;
            // TODO: Add your initialization code here
            player = ((Game1)Game).spriteManager.player;

            weap1 = ((Game1)Game).spriteManager.weap1;
            weap2 = ((Game1)Game).spriteManager.weap2;
            weap3 = ((Game1)Game).spriteManager.weap3;
            weap4 = ((Game1)Game).spriteManager.weap4;
            weap5 = ((Game1)Game).spriteManager.weap5;
        //  weap1f = ((Game1)Game).spriteManager.weap1f;
        //  weap2f = ((Game1)Game).spriteManager.weap2f;
            weap3f = ((Game1)Game).spriteManager.weap3f;
            weap4f = ((Game1)Game).spriteManager.weap4f;
            weap5f = ((Game1)Game).spriteManager.weap5f;
            spriteBatch = ((Game1)Game).spriteManager.spriteBatch;

            base.Initialize();
        }

        protected override void LoadContent()
        {

            base.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {


            //if (((Game1)Game).spriteManager.weap2.count == 0)
            //{
            //    ((Game1)Game).spriteManager.player.inv[1] = false;
            //}
            //if (((Game1)Game).spriteManager.weap3.count == 0)
            //{
            //    ((Game1)Game).spriteManager.player.inv[2] = false;
            //}
            //if (((Game1)Game).spriteManager.weap4.count == 0)
            //{
            //    ((Game1)Game).spriteManager.player.inv[3] = true;
            //}
            //if (((Game1)Game).spriteManager.weap5.count == 0)
            //{
            //    ((Game1)Game).spriteManager.player.inv[4] = false;
            //}
 

            //add collision detection etc here, + controls 

            switch (player.weaponId)
            {
                case 0:

                    foreach (Weapon w in bulletList)
                    {
                        if (w.iD == 69 || w.iD == 68)
                            w.UpdateGrav(gameTime, Game.Window.ClientBounds);
                        else
                            w.Update(gameTime, Game.Window.ClientBounds);
                    }
                    //nothing
                    break;

                case 1:
                    weap1.pos.X = player.pos.X + 30;
                    weap1.pos.Y = player.pos.Y + 20;

                    weap1.Update(gameTime, Game.Window.ClientBounds);


                    foreach (Weapon w in bulletList)
                    {
                        if (w.iD == 69 || w.iD == 68)
                            w.UpdateGrav(gameTime, Game.Window.ClientBounds);
                        else
                            w.Update(gameTime, Game.Window.ClientBounds);
                    }
                    // butterfly knife
                    break;

                case 2:


                    weap2.pos.X = player.pos.X + 30;
                    weap2.pos.Y = player.pos.Y + 25;
                    weap2.Update(gameTime, Game.Window.ClientBounds);


                    foreach (Weapon w in bulletList)
                    {
                        if (w.iD == 69 || w.iD == 68)
                            w.UpdateGrav(gameTime, Game.Window.ClientBounds);
                        else
                            w.Update(gameTime, Game.Window.ClientBounds);
                    }
                    // throwing knife
                    break;

                case 3:
                    if (Keyboard.GetState().IsKeyDown(Keys.Space) == false)
                    {
                        weap3.pos.X = player.pos.X + 30;
                        weap3.pos.Y = player.pos.Y + 20;

                        weap3.Update(gameTime, Game.Window.ClientBounds);
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                    {
                        weap3f.pos.X = player.pos.X + 30;
                        weap3f.pos.Y = player.pos.Y + 20;



                        weap3f.Update(gameTime, Game.Window.ClientBounds);
                    }

                    foreach (Weapon w in bulletList)
                    {
                        if (w.iD == 69 || w.iD == 68)
                            w.UpdateGrav(gameTime, Game.Window.ClientBounds);
                        else
                            w.Update(gameTime, Game.Window.ClientBounds);
                    }
                    break;

                case 4:


                    if (Keyboard.GetState().IsKeyDown(Keys.Space) == false)
                    {
                        weap4.pos.X = player.pos.X + 30;
                        weap4.pos.Y = player.pos.Y + 20;

                        weap4.Update(gameTime, Game.Window.ClientBounds);
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                    {
                        weap4f.pos.X = player.pos.X + 30;
                        weap4f.pos.Y = player.pos.Y + 20;
                        


                        weap4f.Update(gameTime, Game.Window.ClientBounds);
                    }
                    //weap4.pos.X = player.pos.X + 20;
                    //weap4.pos.Y = player.pos.Y + 20;
                    //weap4.Update(gameTime, Game.Window.ClientBounds);

                    foreach (Weapon w in bulletList)
                    {
                        if (w.iD == 69 || w.iD == 68)
                            w.UpdateGrav(gameTime, Game.Window.ClientBounds);
                        else
                            w.Update(gameTime, Game.Window.ClientBounds);

                    }
                    // 3 burst
                    break;

                case 5:
                    if (Keyboard.GetState().IsKeyDown(Keys.Space) == false)
                    {
                        weap5.pos.X = player.pos.X + 20;
                        weap5.pos.Y = player.pos.Y + 20;

                        weap5.Update(gameTime, Game.Window.ClientBounds);
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                    {
                        weap5f.pos.X = player.pos.X + 20;
                        weap5f.pos.Y = player.pos.Y + 20;



                        weap5f.Update(gameTime, Game.Window.ClientBounds);
                    }

                    foreach (Weapon w in bulletList)
                    {
                        if (w.iD == 69 || w.iD == 68)
                            w.UpdateGrav(gameTime, Game.Window.ClientBounds);
                        else
                            w.Update(gameTime, Game.Window.ClientBounds);
                    }

                    // RPG
                    break;

            }

            //if (((Game1)Game).spriteManager.player.weaponId > 1 && !((Game1)Game).spriteManager.player.inv[((Game1)Game).spriteManager.player.weaponId - 1])
            //{
            //    ((Game1)Game).spriteManager.player.weaponId--;
            //}

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(); //important

            switch (player.weaponId)
            {
                case 0:

                    //nothing
                    break;

                case 1:
                    if (weap1.isFired == true)
                    {
                        //weap1.pos.X = player.pos.X + 30;
                        //weap1.pos.Y = player.pos.Y + 20;

                        if (player.isFacingRight == true)
                        {
                            weap1.pos.X = player.pos.X + 30;
                            weap1.pos.Y = player.pos.Y + 20;
                            weap1.Draw(gameTime, spriteBatch);
                        }

                        if (player.isFacingRight == false)
                        {
                            weap1.pos.X = player.pos.X - 20;
                            weap1.pos.Y = player.pos.Y + 20;
                            weap1.DrawLeft(gameTime, spriteBatch);
                        }
                        //  weap1.Draw(gameTime, spriteBatch);
                    }




                    timeSinceLastFire += gameTime.ElapsedGameTime.Milliseconds;

                    if (timeSinceLastFire > 100)
                    {
                        weap1.isFired = false;
                    }

                    if (timeSinceLastFire > 500)
                    {

                        if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                        {

                            weap1.isFired = true;
                            timeSinceLastFire = 0;
                        }
                    }

                    // butterfly knife
                    // not showing

                    break;

                case 2:

                    //  weap2.pos.X = player.pos.X + 30;
                    // weap2.pos.Y = player.pos.Y + 25;

                    // weap2.Draw(gameTime, spriteBatch);  

                    timeSinceLastFire += gameTime.ElapsedGameTime.Milliseconds;

                    if (timeSinceLastFire > 100)
                    {
                        weap2.isFired = false;
                    }

                    if (timeSinceLastFire > 300)
                    {

                        if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                        {
                            if (weap2.count > 0)
                            {
                                throwKnife();
                           //     player.bulletCount[1] -= 1;
                                weap2.isFired = true;
                                timeSinceLastFire = 0;
                            }
                        }
                    }


                    // throwing knife
                    // not shoing
                    break;

                case 3:
                    //weap3.pos.X = player.pos.X + 30;
                    // weap3.pos.Y = player.pos.Y + 20;
                    // weap3.Draw(gameTime, spriteBatch);

                    if (player.isFacingRight == true)
                    {
                        weap3.pos.X = player.pos.X + 30;
                        weap3.pos.Y = player.pos.Y + 20;
                        weap3.Draw(gameTime, spriteBatch);
                    }

                    if (player.isFacingRight == false)
                    {
                        weap3.pos.X = player.pos.X - 11;
                        weap3.pos.Y = player.pos.Y + 20;
                        weap3.DrawLeft(gameTime, spriteBatch);
                    }
                    //   if (/* Keyboard.GetState().IsKeyDown(Keys.Space) == false && */ weap5.isFired == false)
                    //{
                    //    weap3.pos.X = player.pos.X + 30;
                    //    weap3.pos.Y = player.pos.Y + 20;
                    //    weap3.Draw(gameTime, spriteBatch);
                    //}

                    if (weap3.isFired == true)
                    {
                        if (player.isFacingRight == true)
                        {
                            weap3f.pos.X = player.pos.X + 30;
                            weap3f.pos.Y = player.pos.Y + 20;
                            weap3f.Draw(gameTime, spriteBatch);
                        }

                        if (player.isFacingRight == false)
                        {
                            weap3f.pos.X = player.pos.X - 11;
                            weap3f.pos.Y = player.pos.Y + 20;
                            weap3f.DrawLeft(gameTime, spriteBatch);
                        }
                    }

                    timeSinceLastFire += gameTime.ElapsedGameTime.Milliseconds;

                    if (timeSinceLastFire > 500)
                    {
                        weap3.isFired = false;
                    }
                    if (timeSinceLastFire > 1000)
                    {

                        if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                        {

                            if (weap3.count > 0)
                            {
                                fireBullet();
                                weap3.isFired = true;
                                timeSinceLastFire = 0;
                            }
                        }
                    }

                    // pistol
                    //showing
                    break;

                case 4:

                    if (player.isFacingRight == true)
                    {
                        weap4.pos.X = player.pos.X + 20;
                        weap4.pos.Y = player.pos.Y + 20;
                        weap4.Draw(gameTime, spriteBatch);
                    }

                    if (player.isFacingRight == false)
                    {
                        weap4.pos.X = player.pos.X - 11;
                        weap4.pos.Y = player.pos.Y + 20;
                        weap4.DrawLeft(gameTime, spriteBatch);
                    }

                    if (weap4.isFired == true)
                    {

                        if (player.isFacingRight == true)
                        {
                            weap4f.pos.X = player.pos.X + 20;
                            weap4f.pos.Y = player.pos.Y + 20;
                            weap4f.Draw(gameTime, spriteBatch);
                        }

                        if (player.isFacingRight == false)
                        {
                            weap4f.pos.X = player.pos.X - 18;
                            weap4f.pos.Y = player.pos.Y + 20;
                            weap4f.DrawLeft(gameTime, spriteBatch);
                        }
                    }


                    timeSinceLastFire += gameTime.ElapsedGameTime.Milliseconds;

                    if (timeSinceLastFire > 150)
                    {
                        weap4.isFired = false;
                    }
                    if (timeSinceLastFire > 250)
                    {

                        if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                        {
                            if (weap4.count > 0)
                            {
                                fireBurst();
                                weap4.isFired = true;
                                timeSinceLastFire = 0;
                            }
                        }
                    }

                    // 3 burst m16
                    //showing
                    break;

                case 5:

                    if (/* Keyboard.GetState().IsKeyDown(Keys.Space) == false && */ weap5.isFired == false)
                    {
                        if (player.isFacingRight == true)
                        {
                            weap5.pos.X = player.pos.X + 20;
                            weap5.pos.Y = player.pos.Y + 20;
                            weap5.Draw(gameTime, spriteBatch);
                        }

                        if (player.isFacingRight == false)
                        {
                            weap5.pos.X = player.pos.X - 1;
                            weap5.pos.Y = player.pos.Y + 20;
                            weap5.DrawLeft(gameTime, spriteBatch);
                        }
                    }


                    //if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                    //{
                    ////    weap5f.pos.X = player.pos.X + 20;
                    ////    weap5f.pos.Y = player.pos.Y + 20;

                    //    weap5.isFired = true;
                    ////    weap5f.Draw(gameTime, spriteBatch);

                    //}

                    if (weap5.isFired == true)
                    {
                        if (player.isFacingRight == true)
                        {
                            weap5f.pos.X = player.pos.X + 20;
                            weap5f.pos.Y = player.pos.Y + 20 ;
                            weap5f.Draw(gameTime, spriteBatch);
                        }

                        if (player.isFacingRight == false)
                        {
                            weap5f.pos.X = player.pos.X - 11 + 10;
                            weap5f.pos.Y = player.pos.Y + 20;
                            weap5f.DrawLeft(gameTime, spriteBatch);
                        }
                    }


                    timeSinceLastFire += gameTime.ElapsedGameTime.Milliseconds;

                    if (timeSinceLastFire > 750)
                    {
                        weap5.isFired = false;
                    }
                    if (timeSinceLastFire > 1000)
                    {

                        if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                        {
                            if (weap5.count > 0)
                            {
                                fireRPG();
                                weap5.isFired = true;
                                timeSinceLastFire = 0;
                            }
                        }
                    }

                    // RPG
                    //showing
                    break;

            }



            for (int i = 0; i < bulletList.Count; ++i)
            {
                Weapon w = bulletList[i]; // using w to shorten code

                if (w.pos.X < 0)
                {
                    bulletList.RemoveAt(i);
                    continue;
                }
                //if (w.pos.Y < 0)
                //{
                //    bulletList.RemoveAt(i);
                //    continue;
                //}
                if (w.pos.X > (Game.Window.ClientBounds.Width))
                {
                    bulletList.RemoveAt(i);
                    continue;
                }

                if (w.pos.Y > (Game.Window.ClientBounds.Height))
                {
                    bulletList.RemoveAt(i);
                    continue;
                }

            }


            foreach (Weapon w in bulletList)
            {
                if (w.iD == 69)
                    w.DrawRotate(gameTime, spriteBatch);
                else
                {
                        w.Draw(gameTime, spriteBatch);
                }
            }

 //           spriteBatch.DrawString(scoreFont, bulletList.Count.ToString(), new Vector2(50, 100), Color.Black);

            spriteBatch.End(); //also important

            base.Draw(gameTime);
        }

        private void fireBullet()
        {
            if (player.isFacingRight == true)
            bulletList.Add(new Weapon(Game.Content.Load<Texture2D>(@"Images/bullet14x7"), new Vector2(weap3f.pos.X + 26, weap3f.pos.Y + 2), new Point(14, 7), 0, new Point(0, 0), new Point(0, 0), new Vector2(10, 0), 0, true));

            if (player.isFacingRight == false)
            bulletList.Add(new Weapon(Game.Content.Load<Texture2D>(@"Images/bullet14x7"), new Vector2(weap3f.pos.X - 40, weap3f.pos.Y + 7), new Point(14, 7), 0, new Point(0, 0), new Point(0, 0), new Vector2(-10, 0), 0, true, (float)3.14));

            weap3.count--;

        }

        private void fireBurst()
        {
            if (player.isFacingRight == true)
            bulletList.Add(new Weapon(Game.Content.Load<Texture2D>(@"Images/bullet14x7"), new Vector2(weap4f.pos.X + 37, weap4f.pos.Y + 3), new Point(14, 7), 0, new Point(0, 0), new Point(0, 0), new Vector2(10, 0), 0, true));

            if (player.isFacingRight == false)
            bulletList.Add(new Weapon(Game.Content.Load<Texture2D>(@"Images/bullet14x7"), new Vector2(weap4f.pos.X - 39, weap4f.pos.Y + 8), new Point(14, 7), 0, new Point(0, 0), new Point(0, 0), new Vector2(-10, 0), 0, true, (float)3.14));


            weap4.count--;

        }

        private void fireRPG()
        {
            if (player.isFacingRight == true)
            bulletList.Add(new Weapon(Game.Content.Load<Texture2D>(@"Images/RPGammo9x5"), new Vector2(weap5f.pos.X + 24, weap5f.pos.Y + 5), new Point(9, 5), 0, new Point(0, 0), new Point(0, 0), new Vector2(5, 0), 4, true, new Vector2(0, (float)0.01)));

            if (player.isFacingRight == false)
                bulletList.Add(new Weapon(Game.Content.Load<Texture2D>(@"Images/RPGammo9x5"), new Vector2(weap5f.pos.X - 23 + 10, weap5f.pos.Y + 9), new Point(9, 5), 0, new Point(0, 0), new Point(0, 0), new Vector2(-5, 0), 4, true, new Vector2(0, (float)0.01), (float)3.14));

            weap5.count--;

        }

        private void throwKnife()
        {
            if (player.isFacingRight == true)
            bulletList.Add(new Weapon(Game.Content.Load<Texture2D>(@"Images/throwknife"), new Vector2(player.pos.X + 20, player.pos.Y + 20), new Point(30, 10), 0, new Point(0, 0), new Point(0, 0), new Vector2(7, -5), 69, true, new Vector2(0, (float)0.3)));
        
            if (player.isFacingRight == false)
            bulletList.Add(new Weapon(Game.Content.Load<Texture2D>(@"Images/throwknife"), new Vector2(player.pos.X + 20, player.pos.Y + 20), new Point(30, 10), 0, new Point(0, 0), new Point(0, 0), new Vector2(-7, -5), 69, true, new Vector2(0, (float)0.3)));

            weap2.count--;
        }

    }
}
