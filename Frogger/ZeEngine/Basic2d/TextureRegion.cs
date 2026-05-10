using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeEngine
{
    public class TextureRegion
    {
        public Texture2D texture;
        public Rectangle sourceRect;
        public int Width => sourceRect.Width;
        public int Height => sourceRect.Height;

        public TextureRegion()
        {

        }

        public TextureRegion(Texture2D TEXTURE, int x, int y, int width, int height)
        {
            texture = TEXTURE;
            sourceRect = new Rectangle(x, y, width, height);
        }
    }
}
