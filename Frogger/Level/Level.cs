using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Reflection.Emit;
using ZeEngine;

namespace Frogger
{
    public class Level
    {
        public Frog frog;
        public LevelGrid grid;

        public PlayerSpawn playerSpawn;
        public List<Spawn> spawnList = new List<Spawn>();

        public List<Animated2d> allObjects = new List<Animated2d>();
        public List<LevelTile> tiles = new List<LevelTile>();

        public int occupiedCount;
        public LoadFromXML loadFromXML;
        public Level()
        {
            grid = new LevelGrid();
            loadFromXML = new LoadFromXML();
            loadFromXML.LevelFromFile(Globals.content, "Level1.xml", grid.moveableArray, spawnList, allObjects, tiles);

            playerSpawn = new PlayerSpawn(loadFromXML._PlayerSpawn.spawnPosition, 0, 0);
            frog = new Frog("frog", playerSpawn.spawnPosition, new Vector2(64, 64), new Vector2(1, 1), Color.White, this);

            for(int x = 0; x <grid.moveableArray.Length; x++)
            {

            }
            //allObjects.Add(frog);
        }

        public virtual void Update(Vector2 OFFSET)
        {

            for(int i = 0; i < allObjects.Count; i++)
            {
                allObjects[i].Update(OFFSET);
                if(allObjects[i].isAlive == false)
                {
                    allObjects.RemoveAt(i);
                }

                for(int j = tiles.Count - 1; j > 0; j--)
                {
                    if (allObjects[i].bounds.Intersects(tiles[j].bounds))
                    {
                        tiles[j].occupied = true;
                    }
                    else
                    {
                        tiles[j].occupied = false;
                    }
                }
            }

            foreach(Spawn obj in spawnList)
            {
                obj.Update(this);
            }

            frog.Update(OFFSET);
        }

        public virtual void Draw(Texture2D pixel)
        {
            grid.DrawLevel();

            foreach (var obj in allObjects)
            {
                obj.Draw();
            }

            for(int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i].occupied)
                {
                    Globals.spriteBatch.Draw(GameGlobals.BORDER_TEX, new Rectangle((int)tiles[i].position.X - 32, (int)tiles[i].position.Y - 32, 64, 64), Color.White);
                }
                Globals.spriteBatch.DrawString(GameGlobals.FONT, tiles[i].occupied.ToString(), new Vector2(tiles[i].position.X, tiles[i].position.Y), Color.White);
            }

            frog.Draw();
        }
    }
}
