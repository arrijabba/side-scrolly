using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame3
{
    public class Weapon : Sprite
    {
        public int iD;
        public bool show;
        public bool isFired;
        public int count = 50;

        public override Vector2 direction
        {
            get { return speed; }
        }

        public override void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            base.Draw(gametime, spriteBatch,this.rota);
        }


        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {


            pos += direction;

            base.Update(gameTime, clientBounds);
        }


        public void UpdateGrav(GameTime gameTime, Rectangle clientBounds)
        {


            pos.X += direction.X;
            pos.Y += speed.Y;
            speed.Y += acceleration.Y;

            base.Update(gameTime, clientBounds);
        }


        public Weapon(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int iD, bool show)
            : base(textureimage, pos, frameSize, collisionOffset, currentFrame,
                sheetSize, speed)
        {
            this.iD = iD;
            this.show = show;
        }

        public Weapon(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int iD, bool show, Vector2 acceleration)
            : base(textureimage, pos, frameSize, collisionOffset, currentFrame,
                sheetSize, speed)
        {
            this.iD = iD;
            this.show = show;
            this.acceleration = acceleration;
        }

        public Weapon(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int iD, bool show, Vector2 acceleration, float rota)
            : base(textureimage, pos, frameSize, collisionOffset, currentFrame,
                sheetSize, speed)
        {
            this.iD = iD;
            this.show = show;
            this.acceleration = acceleration;
            this.rota = rota;
        }

        public Weapon(Texture2D textureimage, Vector2 pos, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int iD, bool show,float rota)
            : base(textureimage, pos, frameSize, collisionOffset, currentFrame,
                sheetSize, speed)
        {
            this.iD = iD;
            this.show = show;
            this.rota = rota;
        }

    }

}
