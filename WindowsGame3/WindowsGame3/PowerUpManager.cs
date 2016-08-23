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
    public class PowerUpManager : Microsoft.Xna.Framework.DrawableGameComponent
    {

        public List<PowerUp> powerList = new List<PowerUp>();
        public Random rnd1 { get; private set; }
        public Random rnd2 { get; private set; }
        public Random rnd3 { get; private set; }
        int nextSpawnTime = 0;
        int minMillisec = 3000;
        int maxMillisec = 4000;

        public PowerUpManager(Game game)
            : base(game)
        {

        }

        public override void Initialize()
        {
      //      spawnPowerUp(1,new Vector2(250,50));
        //    spawnPowerUp(2, new Vector2(250, 100));
          //  spawnPowerUp(3, new Vector2(300, 50));
            spawnPowerUp(1, new Vector2(350, 400));
            rnd1 = new Random();

            ResetSpawnTime();

            base.Initialize();
        }

        protected override void LoadContent()
        {

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            ((Game1)Game).spriteManager.spriteBatch.Begin();

            foreach (PowerUp p in powerList)
            {
                p.Draw(gameTime, ((Game1)Game).spriteManager.spriteBatch);
            }

            ((Game1)Game).spriteManager.spriteBatch.End();

            base.Draw(gameTime);
        }


        public override void Update(GameTime gameTime)
        {
            nextSpawnTime -= gameTime.ElapsedGameTime.Milliseconds;
            if (nextSpawnTime < 0)
            {
                if (powerList.Count < 1)
                {
                    spawnPowerUp(rnd1.Next(1, 5), new Vector2(350, 400));
                }
                ResetSpawnTime();
            }

            for (int i = 0; i<powerList.Count; i++)
            {
                if (powerList[i].collisionRect.Intersects(((Game1)Game).spriteManager.player.collisionRect) == true)
                {
                    applyPowerUp(powerList[i].getPID());   
                    powerList.RemoveAt(i);
                    continue;
                }
                powerList[i].Update(gameTime, Game.Window.ClientBounds);
            }

            //if (((Game1)Game).spriteManager.((Game1)Game).spriteManager.player.weaponId > 1 && !((Game1)Game).spriteManager.((Game1)Game).spriteManager.player.inv[((Game1)Game).spriteManager.((Game1)Game).spriteManager.player.weaponId - 1])
            //{
            //    ((Game1)Game).spriteManager.((Game1)Game).spriteManager.player.weaponId--;
            //}

            base.Update(gameTime);
        }

        public void spawnPowerUp(int p, Vector2 pos)
        {
            switch (p)
            {
                case 1:
                    powerList.Add(new PowerUp(Game.Content.Load<Texture2D>(@"Images/pow1"), pos, new Point(25, 25), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 0, 1));
                    break;

                case 2:
                    powerList.Add(new PowerUp(Game.Content.Load<Texture2D>(@"Images/pow2"), pos, new Point(25, 25), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 0, 2));
                    break;

                case 3:
                    powerList.Add(new PowerUp(Game.Content.Load<Texture2D>(@"Images/pow3"), pos, new Point(25, 25), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 0, 3));
                    break;

                case 4:
                    powerList.Add(new PowerUp(Game.Content.Load<Texture2D>(@"Images/pow4"), pos, new Point(33, 25), 0, new Point(0, 0), new Point(0, 0), Vector2.Zero, 0, true, 0, 0, 4));
                    break;

            }
        }


        public void applyPowerUp(int pow)
        {
            switch (pow)
            {
                case 1:

                    ((Game1)Game).spriteManager.weap2.count+=10;

                    break;

                case 2:

                    ((Game1)Game).spriteManager.weap3.count+=10;

                    break;

                case 3:

                    ((Game1)Game).spriteManager.weap4.count+=10;


                    break;

                case 4:

                    ((Game1)Game).spriteManager.weap5.count+=10;
                    break;
            }

        }

        private void ResetSpawnTime()
        {
            nextSpawnTime = ((Game1)Game).rnd.Next(minMillisec, maxMillisec);
        }
    }
}
