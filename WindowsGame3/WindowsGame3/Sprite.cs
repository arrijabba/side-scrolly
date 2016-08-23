using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame3
{
    public abstract class Sprite
    {
        protected Texture2D textureimage;
        public Point frameSize;
        public int collisionOffset;
        Point currentFrame;
        Point sheetSize;
      //  int timeSincelastframe = 0;
        const int defaultmillisecondsperFrame = 16;
        int millisecondsPerframe;
        public Vector2 speed;
        public Vector2 pos;
        public Vector2 acceleration = new Vector2(0, 1);
        public bool isColliding;
        public bool isFacingRight = true;
        private double rot = 0;
        public float rota = 0;
        public int health;


        public abstract Vector2 direction { get; }

        public virtual Rectangle collisionRect
        {
            get
            {
                return new Rectangle(((int)pos.X + collisionOffset), ((int)pos.Y + collisionOffset), frameSize.X - 2*collisionOffset, frameSize.Y - 2*collisionOffset);
            }

        }

        public virtual Rectangle playerCollisionRect
        {
            get
            {
                return new Rectangle();
            }

        }

        public Sprite(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame,Point sheetSize,Vector2 speed)
        {
            this.textureimage = textureimage;
            this.pos = pos;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.millisecondsPerframe = defaultmillisecondsperFrame;
        }

        public Sprite(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerframe)
        {
            this.textureimage = textureimage;
            this.pos = pos;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.millisecondsPerframe = millisecondsPerframe;
        }

        public Sprite(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerframe, Vector2 acceleration)
        {
            this.textureimage = textureimage;
            this.pos = pos;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.millisecondsPerframe = millisecondsPerframe;
            this.acceleration = acceleration;
        }

        public Sprite(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerframe, Vector2 acceleration, int health)
        {
            this.textureimage = textureimage;
            this.pos = pos;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.millisecondsPerframe = millisecondsPerframe;
            this.acceleration = acceleration;
            this.health = health;
        }

        public virtual void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureimage, pos, new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public virtual void DrawScroll(GameTime gametime, SpriteBatch spriteBatch, float offsetX)
        {
            spriteBatch.Draw(textureimage, new Vector2(pos.X+offsetX,pos.Y), new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public virtual void Draw(GameTime gametime, SpriteBatch spriteBatch, float rota)
        {
            spriteBatch.Draw(textureimage, pos, new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y), Color.White, rota, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public virtual void Draw(GameTime gametime, SpriteBatch spriteBatch, float rota, float depth)
        {
            spriteBatch.Draw(textureimage, pos, new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y), Color.White, rota, Vector2.Zero, 1, SpriteEffects.None, depth);
        }

        public virtual void DrawBlack(GameTime gametime, SpriteBatch spriteBatch, float rota, float depth)
        {
            spriteBatch.Draw(textureimage, pos, new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y), Color.Black, rota, Vector2.Zero, 1, SpriteEffects.None, depth);
        }


        public virtual void DrawRotate(GameTime gametime, SpriteBatch spriteBatch)
        {
            rot += (2*3.14/16);

            if (rot >= 6.28)
                rot = 0;

            
            spriteBatch.Draw(textureimage, pos, new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y), Color.White, (float)rot, new Vector2(frameSize.X/2, frameSize.Y/2), 1, SpriteEffects.None, 0);
         }

        public virtual void DrawLeft(GameTime gametime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureimage, pos, new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y), Color.White, (float)rot, Vector2.Zero,/*(frameSize.X / 2, frameSize.Y / 2)*/ 1, SpriteEffects.FlipHorizontally, 0);
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            ++currentFrame.X;
            if (currentFrame.X >= sheetSize.X)
            {
                currentFrame.X = 0;

                ++currentFrame.Y;
                if (currentFrame.Y >= sheetSize.Y)
                {
                    currentFrame.Y = 0;
                }

            }


            if (health < 0)
            {
                health = 0;
            }
        }



    }
}
