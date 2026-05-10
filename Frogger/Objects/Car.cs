using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeEngine;

namespace Frogger
{
    public class Car : Animated2d
    {
        float speed;
        //-1 left 1 right
        int direction;
        public int size;

        public Vector2 currentTile, nextTile;

        Level level;
        public Car(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, Color COLOR, int DIRECTION, Level LEVEL) : base(PATH, POS, DIMS, FRAMES, COLOR)
        {
            speed = 5.0f;
            direction = DIRECTION;
            currentTile = GameGlobals.Vector2PosToArray(POS);
            level = LEVEL;

            Random r = new Random();
            size = r.Next(1, 3);

            isAlive = true;
        }

        public override void Update(Vector2 OFFSET)
        {
            pos.X += speed * direction;

            bounds = new Rectangle((int)pos.X, (int)pos.Y, GameGlobals.SPRITE_WIDTH * size, GameGlobals.SPRITE_HEIGHT);

            OutsideBounds();
        }

        public override void Draw()
        {
            if (myModel != null && isAlive == true)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X ), (int)(pos.Y ), (int)dims.X * size, (int)dims.Y), null, Color.White, rot, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }
    }
}
