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
using ZeEngine;
using System.Security.Principal;
using Frogger.Objects;
#endregion

namespace Frogger
{
    public class Frog : Animated2d
    {
        public float jumpDist = 64.0f;
        public Vector2 currentTile, nextTile;

        //0 = up, 1 = right, 2 = down, 3 = left
        public int currentDirection, nextDirection;

        Level level;

        public bool onLog;
        public Frog(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, Color COLOR, Level LEVEL) : base(PATH, POS, DIMS, FRAMES, COLOR)
        {
            FRAMES = new Vector2(FRAMES.X, FRAMES.Y);
            level = LEVEL;
            currentTile = GameGlobals.Vector2PosToArray(level.playerSpawn.spawnPosition);
            nextTile = currentTile;
            isAlive = true;
            onLog = false;
        }

        public override void Update(Vector2 OFFSET)
        {

            if (Globals.keyboard.GetSinglePress("A"))
            {
                rot = MathHelper.ToRadians(270.0f);
                nextDirection = GameGlobals.DIRECTION_LEFT;
                if(CanMove())
                    pos = new Vector2(pos.X - jumpDist, pos.Y);

            }
            if (Globals.keyboard.GetSinglePress("D"))
            {
                rot = MathHelper.ToRadians(90.0f);
                nextDirection = GameGlobals.DIRECTION_RIGHT;
                if (CanMove())
                    pos = new Vector2(pos.X + jumpDist, pos.Y);

            }
            if (Globals.keyboard.GetSinglePress("W"))
            {
                rot = MathHelper.ToRadians(0.0f);
                nextDirection = GameGlobals.DIRECTION_UP;
                if (CanMove()) 
                    pos = new Vector2(pos.X, pos.Y - jumpDist);
            }
            if (Globals.keyboard.GetSinglePress("S"))
            {
                rot = MathHelper.ToRadians(180.0f);
                nextDirection = GameGlobals.DIRECTION_DOWN;
                if (CanMove())
                    pos = new Vector2(pos.X, pos.Y + jumpDist);
            }

            foreach(var obj in level.allObjects)
            {
                if (bounds.Intersects(obj.bounds))
                {
                    if(obj is Car)
                    {
                        ResetFrog();
                    }
                    else if(obj is Log)
                    {
                        onLog = true;
                        Log log = (Log)obj;
                        pos.X += log.speed * log.direction;
                    }

                    else if(obj is Lilypad)
                    {
                        Lilypad pad = (Lilypad)obj;
                        if (!pad.isUp)
                        {
                            ResetFrog();
                        }
                    }
                }
            }

            if (level.grid.moveableArray[(int)currentTile.X, (int)currentTile.Y] == GameGlobals.TT_WATER && onLog == false)
            {
               // ResetFrog();
            }

            if (!isAlive)
            {
                ResetFrog();
            }

            bounds = new Rectangle((int)pos.X, (int)pos.Y, GameGlobals.SPRITE_WIDTH, GameGlobals.SPRITE_HEIGHT);

            OutsideBounds();

            UpdateCurrentTile();

            base.Update(OFFSET);
        }

        public void UpdateCurrentTile()
        {
            if(pos.X < currentTile.X * 64)
            {
                nextTile = new Vector2(currentTile.X, currentTile.Y);
            }
            if (pos.X < currentTile.X * 64)
            {
                nextTile = new Vector2(currentTile.X, currentTile.Y);
            }
            if (pos.X < currentTile.X * 64)
            {
                nextTile = new Vector2(currentTile.X, currentTile.Y);
            }
            if (pos.X < currentTile.X * 64)
            {
                nextTile = new Vector2(currentTile.X, currentTile.Y);
            }

            currentDirection = nextDirection;
            currentTile = nextTile;
        }
        public bool CanMove()
        {
            int newX, newY;

            for (int x = 0; x < GameGlobals.LEVEL_WIDTH - 1; x++)
            {
                for (int y = 0; y < GameGlobals.LEVEL_HEIGHT - 1; y++)
                {
                    switch (nextDirection)
                    {

                        case 0:
                            newY = (int)currentTile.Y - 1;
                            if (newY < 0)
                            {
                                newY = 0;
                                return false ;
                            }
                            nextTile = new Vector2(currentTile.X, newY);
                            break;

                        case 1:
                            newX = (int)currentTile.X + 1;
                            if (newX > GameGlobals.LEVEL_WIDTH - 1)
                            {
                                newX = 0;
                                return false;
                            }
                            nextTile = new Vector2(newX, currentTile.Y);
                            break;

                        case 2:
                            newY = (int)currentTile.Y + 1;
                            if(newY > GameGlobals.LEVEL_HEIGHT - 1)
                            {
                                newY = GameGlobals.LEVEL_HEIGHT - 1;
                                return false;
                            }
                            nextTile = new Vector2(currentTile.X, currentTile.Y + 1);
                            break;

                        case 3:
                            newX = (int)currentTile.X - 1;
                            if(newX < 0)
                            {
                                newX = 0;
                                return false;
                            }
                            nextTile = new Vector2(currentTile.X - 1, currentTile.Y);
                            break;

                    }

                    return true;
                }
            }
            return false;
        }
        public virtual void ResetFrog()
        {
            isAlive = true;
            onLog = false;
            pos = level.playerSpawn.spawnPosition;
            currentTile = GameGlobals.Vector2PosToArray(level.playerSpawn.spawnPosition);
            nextTile = currentTile;
        }
    }
}
