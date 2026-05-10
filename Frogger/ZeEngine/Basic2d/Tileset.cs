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
    public class Tileset
    {
        private TextureRegion[] tiles;
        public int tileWidth, tileHeight, columns, rows, count;

        public Tileset(TextureRegion region, int TILEWIDTH, int TILEHEIGHT)
        {
            tileHeight = TILEHEIGHT;
            tileWidth = TILEWIDTH;
            columns = region.Width / TILEWIDTH;
            rows = region.Height / TILEHEIGHT;
            count = columns * rows;

            tiles = new TextureRegion[count];

            for(int i = 0; i < count; i++)
            {
                int x = i % columns * tileWidth;
                int y = i / columns * tileHeight;
                tiles[i] = new TextureRegion(region.texture, region.sourceRect.X + x, region.sourceRect.Y + y, tileWidth, tileHeight);
            }
        }

        public TextureRegion GetTile(int index) => tiles[index];

        public TextureRegion GetTile(int column, int row)
        {
            int index = row * columns + column;
            return GetTile(index);
        }
    }
}
