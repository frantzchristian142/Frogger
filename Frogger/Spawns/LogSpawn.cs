using Frogger.Objects;
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
    public class LogSpawn : Spawn
    {
        public LogSpawn(Vector2 POS, int DIRECTION, int SPAWNTIME) : base(POS, DIRECTION, SPAWNTIME)
        {
            spawnPosition = POS;
            direction = DIRECTION;
            spawnTimer = new ZeEngine.McTimer(SPAWNTIME);
        }

        public override void Update(Level level)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                level.allObjects.Add(new Log("log", spawnPosition, new Vector2(GameGlobals.SPRITE_WIDTH, GameGlobals.SPRITE_HEIGHT), new Vector2(1, 1), Color.White, direction, level));
                spawnTimer.ResetToZero();
            }
        }
    }
}
