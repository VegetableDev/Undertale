using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Undertale.Scripts.PlayerScripts;


namespace Undertale.Scripts.Backend
{
    public class GameScene : IScene
    {

        public ContentManager contentMan { get; private set; }

        public List<GameObject> gameObjects;
        public Player player;

        public Camera camera;

        public GameScene(ContentManager contentManager)
        {
            this.contentMan = contentManager;
        }

        private SpriteFont font;

        public virtual void Load()
        {
            gameObjects = new List<GameObject>();

            player = SceneManager.instance.playerObjects.player;
            player.SetCurrentScene(this);
            camera = SceneManager.instance.playerObjects.camera;

            font = contentMan.Load<SpriteFont>("Fonts/Determination");
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
            }

        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            DrawAllObjects(_spriteBatch);
        }

        public void DrawUI(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "I like men", Vector2.Zero, Color.White);
        }

        public void DrawAllObjects(SpriteBatch _spriteBatch)
        {
            if (camera == null)
                return;
            foreach (GameObject gameObject in gameObjects)
            {
                Rectangle rect = new Rectangle(gameObject.rect.X + (int)camera.position.X, gameObject.rect.Y + (int)camera.position.Y, gameObject.rect.Width, gameObject.rect.Height);

                _spriteBatch.Draw(gameObject.spr.texture, rect, Color.White);
            }
        }
    }
}
