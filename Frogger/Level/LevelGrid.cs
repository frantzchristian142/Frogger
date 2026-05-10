
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using ZeEngine;

namespace Frogger
{
    public class LevelGrid
    {
        public  int[,] moveableArray;
        public LevelGrid()
        {
            moveableArray = new int[GameGlobals.LEVEL_WIDTH, GameGlobals.LEVEL_HEIGHT];
        }
        
        public virtual void DrawLevel()
        {
            for (int x = 0; x < GameGlobals.LEVEL_WIDTH; ++x)
            {
                for (int y = 0; y < GameGlobals.LEVEL_HEIGHT; ++y)
                {
                    Rectangle destRect = new Rectangle(x * GameGlobals.TILE_WIDTH, y * GameGlobals.TILE_HEIGHT,
                        GameGlobals.TILE_WIDTH, GameGlobals.TILE_HEIGHT);
                    switch (moveableArray[x, y])
                    {
                        case 0:
                            Globals.spriteBatch.Draw(GameGlobals.GRASS_TEX, destRect, null, Color.White, 0.0f, GameGlobals.TEX_ORIGIN, SpriteEffects.None, 1);
                            break;
                        case 1:
                            Globals.spriteBatch.Draw(GameGlobals.ROAD_TEX, destRect, null, Color.White, 0.0f, GameGlobals.TEX_ORIGIN, SpriteEffects.None, 1);
                            break;
                        case 2:
                            Globals.spriteBatch.Draw(GameGlobals.WATER_TEX, destRect, null, Color.White, 0.0f, GameGlobals.TEX_ORIGIN, SpriteEffects.None, 1);
                            break;
                        case 11:
                            Globals.spriteBatch.Draw(GameGlobals.ROAD_TEX, destRect, null, Color.White, 0.0f, GameGlobals.TEX_ORIGIN, SpriteEffects.None, 1);
                            break;
                        case 12:
                            Globals.spriteBatch.Draw(GameGlobals.ROAD_TEX, destRect, null, Color.White, 0.0f, GameGlobals.TEX_ORIGIN, SpriteEffects.None, 1);
                            break;
                        case 21:
                            Globals.spriteBatch.Draw(GameGlobals.WATER_TEX, destRect, null, Color.White, 0.0f, GameGlobals.TEX_ORIGIN, SpriteEffects.None, 1);
                            break;
                        case 22:
                            Globals.spriteBatch.Draw(GameGlobals.WATER_TEX, destRect, null, Color.White, 0.0f, GameGlobals.TEX_ORIGIN, SpriteEffects.None, 1);
                            break;
                        case 30:
                            Globals.spriteBatch.Draw(GameGlobals.WATER_TEX, destRect, null, Color.White, 0.0f, GameGlobals.TEX_ORIGIN, SpriteEffects.None, 1);
                            break;
                        case 99:
                            Globals.spriteBatch.Draw(GameGlobals.GRASS_TEX, destRect, null, Color.White, 0.0f, GameGlobals.TEX_ORIGIN, SpriteEffects.None, 1);
                            break;

                    }
                }
            }
        }
    }
}
