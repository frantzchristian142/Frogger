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
    public class Spawn
    {
        public Vector2 spawnPosition;
        public McTimer spawnTimer;
        public int direction;
 
        public Spawn(Vector2 POS, int DIRECTION, int spawnTime)
        {
            spawnPosition = POS;
            spawnTimer = new McTimer(spawnTime);
            direction = DIRECTION;
        }

        public virtual void Update(Level level)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                level.allObjects.Add(new Car("car", spawnPosition, new Vector2(GameGlobals.SPRITE_WIDTH, GameGlobals.SPRITE_HEIGHT), new Vector2(1, 1), Color.White, direction, level));
                spawnTimer.ResetToZero();
            }
        }
    }
}
