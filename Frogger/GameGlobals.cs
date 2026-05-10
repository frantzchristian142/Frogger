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
    public class GameGlobals
    {
        public static int LEVEL_WIDTH = 12, LEVEL_HEIGHT = 24;
        public static int TILE_WIDTH = 64, TILE_HEIGHT = 64;
        public static int SPRITE_WIDTH = 64, SPRITE_HEIGHT = 64;
        public static int TILE_OFFSET = 64;

        public static PassObject CheckScroll;

        //0 = grass, 1 = road, 2 = water
        public static int TT_GRASS = 0, TT_ROAD = 1, TT_WATER = 2;
        public static int TT_CARSPAWN_L = 11, TT_CARSPAWN_R = 12;
        public static int TT_LOGSPAWN_L = 21, TT_LOGSPAWN_R = 22;
        public static int TT_LILYSPAWN = 30;
        public static int PLAYER_SPAWN = 99;

        public static Vector2 PLAYER_SPAWN_POS;

        public static int CAR_TIMER = 2000, LOG_TIMER = 1000;
        public static int LILY_UP_TIMER = 2000, LILY_DOWN_TIMER = 1000;


        public static int SPAWN_DIRECTION_LEFT = -1, SPAWN_DIRECTION_RIGHT = 1;
       
        //0 = up, 1 = right, 2 = down, 3 = left
        public static int DIRECTION_UP = 0, DIRECTION_RIGHT = 1, DIRECTION_DOWN = 2, DIRECTION_LEFT = 3;

        public static Texture2D GRASS_TEX = Globals.content.Load<Texture2D>("grass");
        public static Texture2D WATER_TEX = Globals.content.Load<Texture2D>("water");
        public static Texture2D ROAD_TEX = Globals.content.Load<Texture2D>("road");
        public static Texture2D BORDER_TEX = Globals.content.Load<Texture2D>("border");
        public static SpriteFont FONT = Globals.content.Load<SpriteFont>("Arial16");

        public static Vector2 TEX_ORIGIN = new Vector2(GameGlobals.TILE_WIDTH / 2, GameGlobals.TILE_HEIGHT / 2);

        public static Vector2 Vector2PosToArray(Vector2 pos)
        {
            int x = (int)pos.X / GameGlobals.TILE_WIDTH;
            int y = (int)pos.Y / GameGlobals.TILE_HEIGHT;

            return new Vector2(x, y);
        }
    }
}
