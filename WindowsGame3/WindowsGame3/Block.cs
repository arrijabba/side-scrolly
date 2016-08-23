using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame3
{
    public class Block : Sprite
    {
        public Rectangle top
        {
            get
            {
                return new Rectangle(collisionRect.Left + 5, collisionRect.Top, collisionRect.Width - 10, 1);

            }
        }

        public Rectangle bottom
        {
            get
            {
                return new Rectangle(collisionRect.Left + 5, collisionRect.Bottom, collisionRect.Width - 10, 1);

            }
        }

        public Rectangle left
        {
            get
            {
                return new Rectangle(collisionRect.Left, collisionRect.Top + 5, 1, collisionRect.Height - 10);

            }
        }

        public Rectangle right
        {
            get
            {
                return new Rectangle(collisionRect.Right, collisionRect.Top + 5, 1, collisionRect.Height - 10);

            }
        }

        public override Vector2 direction
        {
            get { return Vector2.Zero; }
        }

        public override void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            base.Draw(gametime, spriteBatch);
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
          base.Update(gameTime, clientBounds);
        }


        public Block(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed)
            : base(textureimage, pos, frameSize, collisionOffset, currentFrame,
                sheetSize, speed)
        {

        }
    }

}
