using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame3
{

    class FollowSprite : Sprite
    {
        UserControlledSprite player;


        public override void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            base.Draw(gametime, spriteBatch);
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {

            pos.X += direction.X;
            pos.Y += speed.Y;
     //       speed.Y += acceleration.Y;


            if (pos.X < 0)
                pos.X = 0;
            if (pos.Y < 0)
                pos.Y = 0;

            if (pos.X > (clientBounds.Width - frameSize.X))
                pos.X = clientBounds.Width - frameSize.X;

            if (pos.Y > (clientBounds.Height - frameSize.Y))
                pos.Y = clientBounds.Height - frameSize.Y;

            //if (pos.X > (clientBounds.Width - frameSize.X) || pos.X < 0)
            //    this.speed.X *= -1;

            //if (pos.Y > (clientBounds.Height - frameSize.Y) || pos.Y < 0)
            //   this.speed.Y *= -1;

            base.Update(gameTime, clientBounds);
        }

        public override Vector2 direction
        {
            get
            {
                return (Vector2.Normalize((player.pos - this.pos)) * speed);
            }

        }

        public override Rectangle playerCollisionRect
        {
            get
            {
                return new Rectangle(((int)pos.X + 4), ((int)pos.Y), frameSize.X - 20, frameSize.Y);
            }

        }


        public FollowSprite(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, UserControlledSprite player, int health)
            : base(textureimage, pos, frameSize, collisionOffset, currentFrame,
                sheetSize, speed)
        {
            this.player = player;
            this.health = health;

        }

        public FollowSprite(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerframe, UserControlledSprite player)
            : base(textureimage, pos, frameSize, collisionOffset, currentFrame,
                sheetSize, speed, millisecondsPerframe)
        {
            this.player = player;
        }

    }
}
