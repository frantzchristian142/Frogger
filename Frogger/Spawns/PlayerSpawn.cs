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
    public class PlayerSpawn : Spawn
    {
        public PlayerSpawn(Vector2 POS, int DIRECTION, int SPAWNTIMER) : base(POS, DIRECTION, SPAWNTIMER)
        {
            spawnPosition = POS;
            DIRECTION = 0;
            SPAWNTIMER = 0;
        }
    }
}
