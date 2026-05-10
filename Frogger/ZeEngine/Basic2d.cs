#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion


namespace ZeEngine
{
    public class Basic2d
    {
        public float rot;

        public string modelStr;

        public Vector2 pos, dims, frameSize, updateOffset;

        public Texture2D myModel;

        public Rectangle bounds;

        public Basic2d(string PATH, Vector2 POS, Vector2 DIMS)
        {
            pos = new Vector2(POS.X, POS.Y);
            dims = new Vector2(DIMS.X, DIMS.Y);
            rot = 0.0f;

            modelStr = PATH;
            myModel = Globals.content.Load<Texture2D>(modelStr);

            bounds = new Rectangle((int)POS.X, (int)POS.Y, (int)DIMS.X, (int)DIMS.Y);
        }

        public virtual void Update(Vector2 OFFSET)
        {
            updateOffset = OFFSET;
        }

        public virtual bool Hover(Vector2 OFFSET)
        {
            return HoverImg(OFFSET);
        }

        public virtual bool HoverImg(Vector2 OFFSET)
        {
            Vector2 mousePos = new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y);

            if(mousePos.X >= (pos.X +OFFSET.X)-dims.X/2 && mousePos.X <= (pos.X +OFFSET.X)+dims.X/2 && mousePos.Y >= (pos.Y +OFFSET.Y)-dims.Y/2 && mousePos.Y <= (pos.Y +OFFSET.Y)+dims.Y/2)
            {
                return true;
            }

            return false;
        }

        public virtual bool HoverFirst(Vector2 OFFSET)
        {
            Vector2 mousePos = new Vector2(Globals.mouse.firstMouse.X, Globals.mouse.firstMouse.Y);

            if(mousePos.X >= (pos.X +OFFSET.X)-dims.X/2 && mousePos.X <= (pos.X +OFFSET.X)+dims.X/2 && mousePos.Y >= (pos.Y +OFFSET.Y)-dims.Y/2 && mousePos.Y <= (pos.Y +OFFSET.Y)+dims.Y/2)
            {
                return true;
            }

            return false;
        }

        public virtual void Draw()
        {
            if (myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + updateOffset.X), (int)(pos.Y + updateOffset.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if(myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot, new Vector2(myModel.Bounds.Width/2, myModel.Bounds.Height/2), new SpriteEffects(), 0);
            }
        }

        public virtual void Draw(Vector2 OFFSET, Color COLOR)
        {
            if(myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, COLOR, rot, new Vector2(myModel.Bounds.Width/2, myModel.Bounds.Height/2), new SpriteEffects(), 0);
            }
        }

        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN, Color COLOR)
        {
            if(myModel != null)
            {
                Globals.spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, COLOR, rot, new Vector2(ORIGIN.X, ORIGIN.Y), new SpriteEffects(), 0);
            }
        }
    }
}
