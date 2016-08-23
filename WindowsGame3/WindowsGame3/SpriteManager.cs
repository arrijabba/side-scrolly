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
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public SpriteBatch spriteBatch;
        public UserControlledSprite player;
        List<Sprite> spriteList = new List<Sprite>();
        int nextSpawnTime = 0;
        int minMillisec = 1000;
        int maxMillisec = 2000;
        Point camera = new Point(0, 0);
        Point globalPos = new Point(0, 0);
        List<Sprite> blockList = new List<Sprite>();
        public SpriteFont scoreFont;
        public Weapon weap3;
        public Weapon bullet1;
        public Weapon weap1;
        public Weapon weap4;
        public Weapon weap5;
        public Weapon bullet2;
        public Weapon weap5f;
        public Weapon weap2;
        public Weapon weap4f;
        public Weapon weap3f;
        public Weapon boom;
        public Weapon boomRPG;
        int i = 0;
        bool animCheck = true;
        public int wepChek;
        public Image weap1inv;
        public Image weap2inv;
        public Image weap3inv;
        public Image weap4inv;
        public Image weap5inv;
        public Image selected;
        Predicate<Sprite> deadfinder = (Sprite ppp) => { return ppp.health == 0; };




        public SpriteManager(Game game)
            : base(game)
        {

            // TODO: Construct any child components here
        }

        public override void Initialize()
        {
            ResetSpawnTime();
            

            SpawnBlock(((Game1)Game).rnd.Next(1, 4), new Vector2(300, 450));
            SpawnBlock(((Game1)Game).rnd.Next(1, 4), new Vector2(400, 450));


            SpawnBlock(((Game1)Game).rnd.Next(1, 4), new Vector2(650, 300));
            SpawnBlock(((Game1)Game).rnd.Next(1, 3), new Vector2(1500, 300));
            SpawnBlock(((Game1)Game).rnd.Next(1, 3), new Vector2(1500, 300));
            SpawnBlock(((Game1)Game).rnd.Next(1, 3), new Vector2(2000, 400));
            SpawnBlock(((Game1)Game).rnd.Next(1, 3), new Vector2(2500, 300));

            player = new UserControlledSprite(Game.Content.Load<Texture2D>(@"Images/player"),
                Vector2.Zero, new Point(50, 50), 0, new Point(0, 0), new Point(0, 0), new Vector2(5, 3));
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            
            scoreFont = Game.Content.Load<SpriteFont>(@"Fonts/Score");
            boom = new Weapon(Game.Content.Load<Texture2D>(@"Images/boom"), Vector2.Zero, new Point(50, 50), 0, new Point(0, 0), new Point(3, 0), new Vector2(0, 0), 0, true);
            boomRPG = new Weapon(Game.Content.Load<Texture2D>(@"Images/boomRPG"), Vector2.Zero, new Point(150, 150), 0, new Point(0, 0), new Point(3, 0), new Vector2(0, 0), 0, true);

            weap3 = new Weapon(Game.Content.Load<Texture2D>(@"Images/pistol33x17"), new Vector2(100000, 100000), new Point(33, 17), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero,0, false);
            //     bullet1 = new Weapon(Game.Content.Load<Texture2D>(@"Images/bullet14x7"), new Vector2(100000, 100000), new Point(33, 17), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true);
            weap1 = new Weapon(Game.Content.Load<Texture2D>(@"Images/flyknife43x18"), new Vector2(100000, 100000), new Point(43, 18), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, false);
            weap4 = new Weapon(Game.Content.Load<Texture2D>(@"Images/rifle37x16"), new Vector2(100000, 100000), new Point(37, 16), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, false);
            weap5 = new Weapon(Game.Content.Load<Texture2D>(@"Images/RPG33x17"), new Vector2(100000, 100000), new Point(33, 17), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, false);
            //     bullet2 = new Weapon(Game.Content.Load<Texture2D>(@"Images/RPGammo9x5"), new Vector2(0, 0), new Point(9, 5), 0, new Point(0, 0), new Point(0, 0), new Vector2(3, 0), 0, true);
            weap5f = new Weapon(Game.Content.Load<Texture2D>(@"Images/RPGfired33x17"), new Vector2(100000, 100000), new Point(33, 17), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, false);
            weap2 = new Weapon(Game.Content.Load<Texture2D>(@"Images/throwknife"), new Vector2(100000, 100000), new Point(30, 10), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, false);

            weap4f = new Weapon(Game.Content.Load<Texture2D>(@"Images/rifle44x16"), new Vector2(100000, 100000), new Point(44, 16), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, false);
            weap3f = new Weapon(Game.Content.Load<Texture2D>(@"Images/pistol33x17f"), new Vector2(100000, 100000), new Point(33, 17), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, false);

            weap1inv = new Image(Game.Content.Load<Texture2D>(@"Images/flyknife43x18"), new Vector2(50, 30), new Point(43, 18), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 0);
            weap2inv = new Image(Game.Content.Load<Texture2D>(@"Images/throwknife"), new Vector2(110, 30), new Point(30, 10), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 0);
            weap3inv = new Image(Game.Content.Load<Texture2D>(@"Images/pistol33x17"), new Vector2(170, 30), new Point(33, 17), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 0);
            weap4inv = new Image(Game.Content.Load<Texture2D>(@"Images/rifle37x16"), new Vector2(230, 30), new Point(37, 16), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 0);
            weap5inv = new Image(Game.Content.Load<Texture2D>(@"Images/RPG33x17"), new Vector2(280, 30), new Point(33, 17), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 0);
            selected = new Image(Game.Content.Load<Texture2D>(@"Images/back"), new Vector2(100000, 1000000), new Point(50, 20), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 0);


            base.LoadContent();
        }



        public override void Update(GameTime gameTime)
        {
            boom.Update(gameTime, Game.Window.ClientBounds);
            boomRPG.Update(gameTime, Game.Window.ClientBounds);
            player.Update(gameTime, Game.Window.ClientBounds);

            weap1inv.Update(gameTime, Game.Window.ClientBounds);
            weap2inv.Update(gameTime, Game.Window.ClientBounds);
            weap3inv.Update(gameTime, Game.Window.ClientBounds);
            weap4inv.Update(gameTime, Game.Window.ClientBounds);
            weap5inv.Update(gameTime, Game.Window.ClientBounds);

            if (weap2.count == 0)
            {
                player.inv[1] = false;
            }
            else if (weap2.count > 0)
            {
                player.inv[1] = true;
            }

            if (weap3.count == 0)
            {
                player.inv[2] = false;
            }
            else if (weap3.count > 0)
            {
                player.inv[2] = true;
            }

            if (weap4.count < 1)
            {
                player.inv[3] = false;
            }
            else if (weap4.count > 0)
            {
                player.inv[3] = true;
            }

            if (weap5.count == 0)
            {
                player.inv[4] = false;
            }
            else if (weap5.count > 0)
            {
                player.inv[4] = true;
            }




            foreach (Sprite s in spriteList)
            {



                if (s.health <= 0)
                {
                    spriteList.RemoveAt(spriteList.FindIndex(deadfinder));
                    break;
                }



                for (int i = 0; i < ((Game1)Game).weaponManager.bulletList.Count; ++i)
                {
                    
                    Weapon w = ((Game1)Game).weaponManager.bulletList[i]; // using w to shorten code
                    if (w.collisionRect.Intersects(s.collisionRect))
                    {
                        ((Game1)Game).weaponManager.bulletList.RemoveAt(i);

                        if (w.iD != 4)
                        {
                            s.health -= 25;
                            boom.pos.Y = w.pos.Y - 25;
                            boom.pos.X = w.pos.X - 25;
                            animCheck = true;
                            //add some recoil
                        }

                        else if (w.iD == 4)
                        {
                            s.health -= 50;
                            wepChek = 2;
                            boomRPG.pos.Y = w.pos.Y - 75;
                            boomRPG.pos.X = w.pos.X - 75;
                            animCheck = true;
                            // add some big recoil
                        }

                        //else if (w.iD == 69)
                        //{

                        //}
                    }
                }

                if (s.playerCollisionRect.Intersects(player.enemyCollisionRect) == true)
                {
                    //    ((Game1)Game).currentGameState = Game1.GameState.GameOver;
                    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                    spriteBatch.DrawString(scoreFont, player.recSpeed.X.ToString(), new Vector2(400, 25), Color.Black);
                    spriteBatch.End();

                 //   player.pos.X += 1;
                    //player.recSpeed.X = Vector2.Normalize(s.direction).X * 20;
                    if (Vector2.Normalize(s.direction).X > 0)
                    {
                        player.recSpeed.X = 20;
                        player.recAcceleration.X = -1;
                    }
                    else if (Vector2.Normalize(s.direction).X < 0)
                    {
                        player.recSpeed.X = -20;
                        player.recAcceleration.X = -1;
                    }


                    

                    //DIRECTION OF THE MOVEMENT OF THE ENEMY SPRITE
                }


                s.Update(gameTime, Game.Window.ClientBounds);
            }

            nextSpawnTime -= gameTime.ElapsedGameTime.Milliseconds;
            if (nextSpawnTime < 0)
            {
                if (spriteList.Count < 1)
                {
                    //SpawnFollowSprite();
                }
                ResetSpawnTime();
            }

            int j = 0;
            foreach (Block s in blockList)
            {
                s.Update(gameTime, Game.Window.ClientBounds);
                j += staticCollide(s, player);
                staticCollide(s, spriteList);

                if (j > 0)
                    player.acceleration.Y = 0;
                else
                {
                    player.acceleration.Y = 1;
                    player.isColliding = false;
                }

                for (int i = 0; i < ((Game1)Game).weaponManager.bulletList.Count; ++i)
                {
                    Weapon w = ((Game1)Game).weaponManager.bulletList[i]; // using w to shorten code

                    if (w.collisionRect.Intersects(s.collisionRect))
                    {
                        ((Game1)Game).weaponManager.bulletList.RemoveAt(i);

                        if (w.iD != 4)
                        {
                            boom.pos.Y = w.pos.Y - 25;
                            boom.pos.X = w.pos.X - 25;
                            animCheck = true;
                        }

                        else if (w.iD == 4)
                        {
                            wepChek = 2;
                            boomRPG.pos.Y = w.pos.Y - 75;
                            boomRPG.pos.X = w.pos.X - 75;
                            animCheck = true;
                        }

                        //else if (w.iD == 69)
                        //{

                        //}
                    }
                }
            }

            for (int i = 1; i < 10; i++)
            {
                if (blockList.Count < 5)
                SpawnBlock(((Game1)Game).rnd.Next(4), (new Vector2(500, 350) + i * new Vector2(50, 0)));
            }

            //camera
            if ((Game.Window.ClientBounds.Width - player.pos.X) < 500)
            {
                camera.X -= 5;
                globalPos.X -= 5;

                foreach (Sprite s in spriteList)
                {
                    s.pos.X -= 5;
                }

                foreach (Sprite s in blockList)
                {
                    s.pos.X -= 5;
                }

                player.pos.X -= 5;
            }

            if (player.pos.X < 500 && globalPos.X < 0)
            {
                camera.X += 5;
                globalPos.X += 5;


                foreach (Sprite s in spriteList)
                {
                    s.pos.X += 5;
                }
                foreach (Sprite s in blockList)
                {
                    s.pos.X += 5;
                }

                player.pos.X += 5;
            }

            if (globalPos.X > 0)
            {
                globalPos.X = 0;
            }

            if (Math.Abs(camera.X) > 1024)
            {
                camera.X = 0;
            }

            if (player.weaponId > 1 && !player.inv[player.weaponId - 1])
            {
                player.weaponId--;
            }

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.DrawString(scoreFont, player.recSpeed.X.ToString(), new Vector2(400, 25), Color.Black);
            spriteBatch.End();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend); //important

            
            spriteBatch.Draw(Game.Content.Load<Texture2D>(@"Images/background"), new Vector2(camera.X,0), new Rectangle(0, 0, 1024, 500), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

            if (camera.X < 0)
            {
                spriteBatch.Draw(Game.Content.Load<Texture2D>(@"Images/background"), new Vector2(camera.X + 1024, 0), new Rectangle(0, 0, 1024, 500), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }
            else if (camera.X > 0)
            {
                spriteBatch.Draw(Game.Content.Load<Texture2D>(@"Images/background"), new Vector2(camera.X - 1024, 0), new Rectangle(0, 0, 1024, 500), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }


            spriteBatch.DrawString(scoreFont, Game.Window.ClientBounds.Width.ToString(), new Vector2(50, 150), Color.Black);
            spriteBatch.DrawString(scoreFont, globalPos.X.ToString(), new Vector2(100, 150), Color.Black);
            spriteBatch.DrawString(scoreFont, camera.X.ToString(), new Vector2(150, 150), Color.Black);
            spriteBatch.DrawString(scoreFont, (Math.Abs((int)player.direction.X)).ToString(), new Vector2(200, 150), Color.Black);


            //weap1inv.Draw(gameTime, spriteBatch,0,0);
            //weap2inv.Draw(gameTime, spriteBatch,0,0);
            //weap3inv.Draw(gameTime, spriteBatch,0,0);
            //weap4inv.Draw(gameTime, spriteBatch,0,0);
            //weap5inv.Draw(gameTime, spriteBatch,0,0);

            switch (player.weaponId)
            {
                case 1:
                    selected.pos = weap1inv.pos;
                    selected.frameSize = new Point(43, 18);
                    selected.Draw(gameTime, spriteBatch, 0, .99f);
                    break;

                case 2:
                    selected.pos = weap2inv.pos;
                    selected.frameSize = new Point(30, 10);
                    selected.Draw(gameTime, spriteBatch, 0, .99f);
                    break;

                case 3:
                    selected.pos = weap3inv.pos;
                    selected.frameSize = new Point(33, 17);
                    selected.Draw(gameTime, spriteBatch, 0, .99f);
                    break;

                case 4:
                    selected.pos = weap4inv.pos;
                    selected.frameSize = new Point(37, 16);
                    selected.Draw(gameTime, spriteBatch, 0, .99f);
                    break;

                case 5:
                    selected.pos = weap5inv.pos;
                    selected.frameSize = new Point(33, 17);
                    selected.Draw(gameTime, spriteBatch, 0, .99f);
                    break;

            }

            for (int p = 1; p <= 5; p++)
            {

                if (player.inv[p-1] == true)
                {
                    switch (p)
                    {
                        case 1:
                            weap1inv.Draw(gameTime, spriteBatch, 0, 0);
                            break;
                        case 2:
                            weap2inv.Draw(gameTime, spriteBatch, 0, 0);
                            break;
                        case 3:
                            weap3inv.Draw(gameTime, spriteBatch, 0, 0);
                            break;
                        case 4:
                            weap4inv.Draw(gameTime, spriteBatch, 0, 0);
                            break;
                        case 5:
                            weap5inv.Draw(gameTime, spriteBatch, 0, 0);
                            break;
                    }
                }
                else if (player.inv[p-1] == false)
                {
                    switch (p)
                    {
                        case 1:
                            weap1inv.DrawBlack(gameTime, spriteBatch, 0, 0);
                            break;
                        case 2:
                            weap2inv.DrawBlack(gameTime, spriteBatch, 0, 0);
                            break;
                        case 3:
                            weap3inv.DrawBlack(gameTime, spriteBatch, 0, 0);
                            break;
                        case 4:
                            weap4inv.DrawBlack(gameTime, spriteBatch, 0, 0);
                            break;
                        case 5:
                            weap5inv.DrawBlack(gameTime, spriteBatch, 0, 0);
                            break;
                    }
                }
            }

            if (player.isFacingRight == true)
            {
                player.Draw(gameTime, spriteBatch);
            }

            if (player.isFacingRight == false)
            {
                player.DrawLeft(gameTime, spriteBatch);
            }

            foreach (Sprite s in spriteList)
                s.Draw(gameTime, spriteBatch);

            foreach (Sprite s in blockList)
                s.Draw(gameTime, spriteBatch);


           // spriteBatch.DrawString(scoreFont, player. new Vector2(50, 100), Color.Black);
           
            spriteBatch.DrawString(scoreFont, player.weaponId.ToString(), new Vector2(50, 100), Color.Black);
           // Console.WriteLine(player.weaponId.ToString());

            spriteBatch.DrawString(scoreFont, weap2.count.ToString(), new Vector2(115, 50), Color.Black);
            spriteBatch.DrawString(scoreFont, weap3.count.ToString(), new Vector2(175, 50), Color.Black);
            spriteBatch.DrawString(scoreFont, weap4.count.ToString(), new Vector2(240, 50), Color.Black);
            spriteBatch.DrawString(scoreFont, weap5.count.ToString(), new Vector2(290, 50), Color.Black);
            spriteBatch.DrawString(scoreFont, "inf", new Vector2(60, 50), Color.Black);



            Console.WriteLine();
            Console.WriteLine(weap4.count);

            
            //spriteBatch.DrawString(scoreFont, weap2.count.ToString(), new Vector2(50, 70), Color.Black);
            //spriteBatch.DrawString(scoreFont, weap3.count.ToString(), new Vector2(80, 70), Color.Black);
            //spriteBatch.DrawString(scoreFont, weap4.count.ToString(), new Vector2(110, 70), Color.Black);
            //spriteBatch.DrawString(scoreFont, weap5.count.ToString(), new Vector2(140, 70), Color.Black);


            if (animCheck == true)
            {
                if (wepChek == 1)
                    boom.Draw(gameTime, spriteBatch);

                if (wepChek == 2)
                    boomRPG.Draw(gameTime, spriteBatch);


                i++;
            }

            if (i == 3)
            {
                wepChek = 1;
                i = 0;
                animCheck = false;
            }

            foreach (Block s in blockList)
            {
                foreach (Weapon w in ((Game1)Game).weaponManager.bulletList)
                {
                    if (w.collisionRect.Intersects(s.collisionRect))
                    {

                    }
                }
            }

            spriteBatch.End(); //also important

            base.Draw(gameTime);
        }

        private void ResetSpawnTime()
        {
            nextSpawnTime = ((Game1)Game).rnd.Next(minMillisec, maxMillisec);
        }

        public void SpawnFollowSprite()
        {
            spriteList.Add(new FollowSprite(Game.Content.Load<Texture2D>(@"Images/threerings"), Vector2.Zero, new Point(75, 75), 0, new Point(0, 0), new Point(6, 8), new Vector2(1, 1), player,50));
          //  spriteList.Add(new FollowSprite(Game.Content.Load<Texture2D>(@"Images/threerings"), Vector2.Zero, new Point(250, 250), 0, new Point(0, 0), new Point(0, 0), new Vector2(1, 1), player, 25));
              
        }

        public void SpawnBlock(int number, Vector2 pos)
        {
            switch (number)
            {
                case 1:
                    blockList.Add(new Block(Game.Content.Load<Texture2D>(@"Images/block1"), pos, new Point(50, 50), 0, new Point(0, 0), new Point(0, 0), new Vector2(0, 0)));
                    break;

                case 2:
                    blockList.Add(new Block(Game.Content.Load<Texture2D>(@"Images/block2"), pos, new Point(50, 50), 0, new Point(0, 0), new Point(0, 0), new Vector2(0, 0)));
                    break;

                case 3:
                    blockList.Add(new Block(Game.Content.Load<Texture2D>(@"Images/block3"), pos, new Point(50, 50), 0, new Point(0, 0), new Point(0, 0), new Vector2(0, 0)));
                    break;

            }
        }


        public int staticCollide(Block s, Sprite player)
        {
            // for walls, blocks etc
            if (s.top.Intersects(player.collisionRect))
            {
                player.pos.Y = (s.pos.Y - player.collisionRect.Height);
                //  player.acceleration.Y = 0;
                player.isColliding = true;
                return 1;
            }

            //player.isColliding = false;
            //player.acceleration.Y = 1;

            if (s.bottom.Intersects(player.collisionRect))
            {
                player.pos.Y = (s.pos.Y + 50);
                player.speed.Y = 2;
                return 0;
            }

            if (s.left.Intersects(player.collisionRect))
            {
                player.pos.X = (s.pos.X - player.collisionRect.Width);
                return 0;
            }

            if (s.right.Intersects(player.collisionRect))
            {
                player.pos.X = (s.pos.X + s.collisionRect.Width);
                return 0;
            }
            return 0;

        }

        private void staticCollide(Block s, List<Sprite> list)
        {
            // for walls, blocks etc and enemies
            // same as static collide but for multiple things

            foreach (Sprite q in list)
            {
                if (s.top.Intersects(q.collisionRect) == true)
                {
                    q.pos.Y = (s.pos.Y - q.collisionRect.Height);
                    q.acceleration.Y = 0;
                    q.isColliding = true;
                    break;
                }

                //q.isColliding = false;
                //q.acceleration.Y = 1;

                if (s.bottom.Intersects(q.collisionRect))
                {
                    q.pos.Y = (s.pos.Y + 50);
                    q.speed.Y = 2;
                }

                if (s.left.Intersects(q.collisionRect))
                {
                    q.pos.X = (s.pos.X - q.collisionRect.Width);
                }

                if (s.right.Intersects(q.collisionRect))
                {
                    q.pos.X = (s.pos.X + s.collisionRect.Width +5);
                }

            }

        }

    }
}

