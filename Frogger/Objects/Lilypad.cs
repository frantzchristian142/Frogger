using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ZeEngine;

namespace Frogger.Objects
{
    public class Lilypad : Animated2d
    {
        public McTimer upTimer, downTimer;


        public bool isUp;
        public Lilypad(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, Color COLOR) : base(PATH, POS, DIMS, FRAMES, COLOR)
        {
            downTimer = new McTimer(GameGlobals.LILY_DOWN_TIMER);
            upTimer = new McTimer(GameGlobals.LILY_UP_TIMER);
            isUp = true;
            isAlive = true;
        }

        public override void Update(Vector2 OFFSET)
        {
            if (isUp)
            {
                upTimer.UpdateTimer();
                if (upTimer.Test())
                {
                    isUp = false;
                    upTimer.ResetToZero();
                }
            }

            else if(!isUp)
            {
                downTimer.UpdateTimer();
                if (downTimer.Test())
                {
                    isUp = true;
                    downTimer.ResetToZero();
                }
            }
        }

        public override void Draw()
        {
            if (myModel != null)
            {
                if (isUp)
                {
                    Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X), (int)(pos.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
                }
            }
        }
    }
}
