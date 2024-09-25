using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undertale.Scripts.Backend
{
    public class TilemapObject
    {
        private Dictionary<Vector2, int> tilemap;
        private List<Rectangle> textureStore;

        private int tileSize;
        private Texture2D texture;


        public TilemapObject(string filename, int tileSize, Texture2D tileset)
        {
            tilemap = LoadMap("../../../Data/Tilemaps/" + filename);

            int width = tileset.Width;
            int height = tileset.Height;

            int tiledWidth = width / tileSize;
            int tiledHeight = height / tileSize;

            this.tileSize = tileSize;

            texture = tileset;

            textureStore = new();

            for (int y = 0; y < tiledHeight; y++)
            {
                for (int x = 0; x < tiledWidth; x++)
                {
                    textureStore.Add(new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize));
                }
            }
        }

        private Dictionary<Vector2, int> LoadMap(string filepath)
        {
            Dictionary<Vector2, int> result = new();

            StreamReader reader = new(filepath);
            string line;

            int j = 0;

            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');

                for (int i = 0; i < items.Length; i++)
                {
                    if (int.TryParse(items[i], out int value))
                    {
                        result[new Vector2(i, j)] = value;
                    }
                }

                j++;
            }

            return result;
        }

        public void Draw(SpriteBatch _spriteBatch, Vector2 offset)
        {
            foreach (var item in tilemap)
            {
                Rectangle dest = new(
                    ((int)item.Key.X * tileSize) + (int)offset.X,
                    ((int)item.Key.Y * tileSize) + (int)offset.Y,
                    tileSize,
                    tileSize
                );

                Rectangle src = textureStore[item.Value];

                _spriteBatch.Draw(texture, dest, src, Color.White);
            }
        }

    }
}
    
