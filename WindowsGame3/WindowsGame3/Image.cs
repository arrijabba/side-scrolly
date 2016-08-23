using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame3
{
    public class Image : Sprite

    {
        float depth = 0;

        public override Vector2 direction
        {
            get { return speed; }
        }

        public override void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            base.Draw(gametime, spriteBatch, this.rota, this.depth);
        }


        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {


            pos += direction;

            base.Update(gameTime, clientBounds);
        }

        public Image(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int iD, bool show,float rota, float depth)
            : base(textureimage, pos, frameSize, collisionOffset, currentFrame,
                sheetSize, speed)
        {
            this.depth = depth;
        }

    }
}
