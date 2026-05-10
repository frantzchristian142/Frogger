using Frogger;
using Frogger.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ZeEngine
{
    public class LoadFromXML
    {
        public PlayerSpawn playerSpawn;

        public PlayerSpawn _PlayerSpawn
        {
            get
            {
                return playerSpawn;
            }
            set
            {
                playerSpawn = value;
            }
        }

        public LevelGrid LevelFromFile(ContentManager content, string filename, int[,] array, List<Spawn> spawns, List<Animated2d> objects, List<LevelTile> tiles)
        {
            string filePath = Path.Combine(content.RootDirectory, filename);

            using (Stream stream = TitleContainer.OpenStream(filePath))
            {
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    XDocument doc = XDocument.Load(reader);
                    XElement root = doc.Root;

                    XElement tilesetElement = root.Element("Tileset");

                    string regionAttribute = tilesetElement.Attribute("region").Value;
                    string[] split = regionAttribute.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int x = int.Parse(split[0]);
                    int y = int.Parse(split[1]);
                    int width = int.Parse(split[2]);
                    int height = int.Parse(split[3]);

                    int tileWidth = int.Parse(tilesetElement.Attribute("tileWidth").Value);
                    int tileHeight = int.Parse(tilesetElement.Attribute("tileHeight").Value);
                    string contentPath = tilesetElement.Value;

                    Texture2D texture = content.Load<Texture2D>(contentPath);

                    TextureRegion textureRegion = new TextureRegion(texture, x, y, width, height);
                    Tileset tileset = new Tileset(textureRegion, tileWidth, tileHeight);

                    XElement tilesElement = root.Element("Tiles");

                    string[] rows = tilesElement.Value.Trim().Split('\n', StringSplitOptions.RemoveEmptyEntries);

                    int columnCount = rows[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;

                    LevelGrid levelGrid = new LevelGrid();

                    for (int row = 0; row < rows.Length; row++)
                    {
                        string[] columns = rows[row].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        for (int column = 0; column < columnCount; column++)
                        {
                            int tilesetIndex = int.Parse(columns[column]);
                            array[column, row] = tilesetIndex;

                            tiles.Add(new LevelTile(new Vector2(column, row) * GameGlobals.TILE_OFFSET, tilesetIndex));

                            if (tilesetIndex == GameGlobals.TT_CARSPAWN_L)
                            {
                                spawns.Add(new CarSpawn(new Vector2(column, row) * GameGlobals.TILE_OFFSET, GameGlobals.SPAWN_DIRECTION_LEFT, GameGlobals.CAR_TIMER));
                            }
                            else if (tilesetIndex == GameGlobals.TT_CARSPAWN_R)
                            {
                                spawns.Add(new CarSpawn(new Vector2(column, row) * GameGlobals.TILE_OFFSET, GameGlobals.SPAWN_DIRECTION_RIGHT, GameGlobals.CAR_TIMER));
                            }
                            else if (tilesetIndex == GameGlobals.TT_LOGSPAWN_L)
                            {
                                spawns.Add(new LogSpawn(new Vector2(column, row) * GameGlobals.TILE_OFFSET, GameGlobals.SPAWN_DIRECTION_LEFT, GameGlobals.LOG_TIMER));
                            }
                            else if (tilesetIndex == GameGlobals.TT_LOGSPAWN_R)
                            {
                                spawns.Add(new LogSpawn(new Vector2(column, row) * GameGlobals.TILE_OFFSET, GameGlobals.SPAWN_DIRECTION_RIGHT, GameGlobals.LOG_TIMER));
                            }
                            else if (tilesetIndex == GameGlobals.TT_LILYSPAWN)
                            {
                                objects.Add(new Lilypad("lily", new Vector2(column, row) * GameGlobals.TILE_OFFSET, new Vector2(GameGlobals.SPRITE_WIDTH, GameGlobals.SPRITE_HEIGHT), new Vector2(1, 1), Color.White));
                            }
                            else if (tilesetIndex == GameGlobals.PLAYER_SPAWN)
                            {
                                _PlayerSpawn = new PlayerSpawn(new Vector2(column, row) * GameGlobals.TILE_OFFSET, 0, 0);
                            }
                        }
                    }

                    return levelGrid;
                }
            }
        }
    }
}
