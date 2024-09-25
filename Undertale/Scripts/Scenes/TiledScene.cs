using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Undertale.Scripts.Backend;

namespace Undertale.Scripts.Scenes
{
    public class TiledScene : GameScene
    {
        public TiledScene(ContentManager contentManager) : base (contentManager)
        {

        }

        public TilemapObject tilemap;

        public override void Load()
        {
            base.Load();

            Texture2D text = contentMan.Load<Texture2D>("Sprites/Tilesets/unnamed_98");

            tilemap = new TilemapObject("test_Tile Layer 1.csv", 20, text);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            if (camera == null)
                return;
            tilemap.Draw(_spriteBatch, camera.position);

            DrawAllObjects(_spriteBatch);
        }
    }
}
