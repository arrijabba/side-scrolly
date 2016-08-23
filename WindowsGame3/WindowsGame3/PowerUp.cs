using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame3
{
    public class PowerUp : Sprite
    {
        private int pID = 0;
        private float depth;
        private bool show;

        public override Vector2 direction
        {
            get { return speed; }
        }

        public int getPID()
        {
            return this.pID;
        }

        public override void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {



            base.Draw(gametime, spriteBatch, this.rota);
        }


        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            base.Update(gameTime, clientBounds);
        }
        

        public PowerUp(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int iD, bool show,float rota, float depth, int pID)
            : base(textureimage, pos, frameSize, collisionOffset, currentFrame,
                sheetSize, speed)
        {
            this.rota = rota;
            this.depth = depth;
            this.show = show;
            this.pID = pID;
        }

    }
}
