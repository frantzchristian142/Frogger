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

namespace Frogger
{
    public class LevelTile
    {
        public Vector2 position;
        public int type;
        public bool occupied;
        public Rectangle bounds;
        public LevelTile(Vector2 POSITION, int TYPE)
        {
            position = POSITION;
            type = TYPE;
            occupied = false;
            bounds = new Rectangle((int)POSITION.X, (int)POSITION.Y, GameGlobals.TILE_WIDTH, GameGlobals.TILE_HEIGHT);
        }
    }
}
