using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace WindowsGame3
{
    public class UserControlledSprite : Sprite
    {
        //bool pow = false;
        public Vector2 lastPosition;
        public int weaponId = 1;
        private int timeSinceLastPress = 0;
        private int millisecPerPress = 250;
        // public int inv = 5;
        public bool[] inv = {true,false,false,false,false};  
       // public List<bool> inv = new List<bool>(5);
      //  private int timer1 = 1000000000;
    //    int powerUpTime;
  //      int pID;
//public int[] bulletCount = new int[5]{1,10,20,30,2};
        public Vector2 recSpeed = new Vector2(0,0);
        public Vector2 recAcceleration = new Vector2(0, 0);

        public Rectangle enemyCollisionRect
        {
            get
            {
                return new Rectangle(((int)pos.X + 7), ((int)pos.Y), frameSize.X - 25, frameSize.Y);
            }

        }



        public override void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            base.Draw(gametime, spriteBatch);
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {

            pos.X += direction.X;
            pos.Y += speed.Y;

            pos.X += recSpeed.X;
            pos.Y += recSpeed.Y;


            if (recSpeed.X != 0)
            {
                if (recSpeed.X < Vector2.Zero.X)
                {
                    recSpeed.X -= recAcceleration.X;
                }
                if (recSpeed.X > Vector2.Zero.X)
                {
                    recSpeed.X += recAcceleration.X;
                }
        //        recSpeed.X += recAcceleration.X;
        //        recSpeed.Y += recAcceleration.Y;
            }

            speed.Y += acceleration.Y;



            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (pos.Y >= 420 || isColliding == true)
                {
                    speed.Y = -20;

                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                acceleration.Y = 1;
            }

            if (pos.X < 0)
                pos.X = 0;
            if (pos.Y < 0)
                pos.Y = 0;

            if (pos.X > (clientBounds.Width - frameSize.X))
                pos.X = clientBounds.Width - frameSize.X;

            if (pos.Y > (clientBounds.Height - frameSize.Y))
                pos.Y = clientBounds.Height - frameSize.Y;

            if (pos != lastPosition)
                lastPosition = pos;


            timeSinceLastPress += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastPress > millisecPerPress)
            {

                while (weaponId < 5)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.K))
                    {
                        for (int i = weaponId; i < 5; i++)
                        {
                            if (inv[i] == true)
                            {
                                weaponId = i + 1;
                                break;
                            }
                        }
                       // weaponId += 1;

                        //while (!inv[weaponId + 1])
                        //{
                        //    weaponId += 1;
                        //}
                        timeSinceLastPress = 0;
                        break;
                    }
                    else
                        break;

                }
                while (weaponId > 1)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.J))
                    {
                        for (int i = (weaponId - 2); i > -1; i--)
                        {
                            if (inv[i] == true)
                            {
                                weaponId = i + 1;
                                break;
                            }
                        }
                        // weaponId -= 1;
                        timeSinceLastPress = 0;
                        break;
                    }
                    else
                        break;
                }
            }




            //if (Keyboard.GetState().IsKeyDown(Keys.Q))
            //{
            //    this.setInvFalse(3);
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.W))
            //{
            //    //this.setInv();
            //}


            //if (Keyboard.GetState().IsKeyDown(Keys.Y))
            //{
            //    inv[0] = !inv[0];
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.U))
            //{
            //    inv[1] = !inv[1];
            //} 
            //if (Keyboard.GetState().IsKeyDown(Keys.I))
            //{
            //    inv[2] = !inv[2];
            //} 
            //if (Keyboard.GetState().IsKeyDown(Keys.O))
            //{
            //    inv[3] = !inv[3];
            //} 
            //if (Keyboard.GetState().IsKeyDown(Keys.P))
            //{
            //    inv[4] = !inv[4];
            //} 
            




                base.Update(gameTime, clientBounds);
        }



        public override Vector2 direction
        {
            get
            {
                Vector2 inputdirection = Vector2.Zero;

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    isFacingRight = false;
                    inputdirection.X -= 1;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    isFacingRight = true;
                    inputdirection.X += 1;
                }

                //if (Keyboard.GetState().IsKeyDown(Keys.Down))
                //    inputdirection.Y += 1;

                //if (Keyboard.GetState().IsKeyDown(Keys.Up))
                //{
                //    if (pos.Y >= 420)
                //    {
                //        while (pos.Y >= 250)
                //        {
                //            inputdirection.Y -= 5;
                //            return inputdirection * speed;
                //        }
                //    }
                //}

                return inputdirection * speed;



            }

        }

        public UserControlledSprite(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed)
            : base(textureimage, pos, frameSize, collisionOffset, currentFrame,
                sheetSize, speed)
        {

        }

        public UserControlledSprite(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerframe)
            : base(textureimage, pos, frameSize, collisionOffset, currentFrame,
                sheetSize, speed, millisecondsPerframe)
        {

        }


    }
}
