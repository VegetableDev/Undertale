using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undertale.Scripts.Backend
{
    public class GameObject
    {
        public Sprite spr;
        public Vector2 position;
        public Vector2 scale;

        public float deltatime { get; private set; }

        public GameScene scene { get; private set; }
        public ContentManager content { get; private set; }

        public bool hasCollider;

        public bool isActive;

        public Rectangle rect
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)scale.X, (int)scale.Y);
            }
        }

        public GameObject(Vector2 position, Vector2 scale, GameScene scene)
        {
            this.scene = scene;
            if(scene != null)
                this.content = scene.contentMan;
            this.position = position;
            this.scale = scale;
            Initialize();
        }

        public void SetCurrentScene(GameScene scene)
        {
            this.scene = scene;
            this.content = scene.contentMan;
            Initialize();
        }

        public virtual void Initialize()
        {
            if (scene == null)
                return;
            spr = new Sprite(content.Load<Texture2D>("Sprites/Player/spr_f_maincharad_0"), Color.White);
            scale = new Vector2(spr.texture.Width, spr.texture.Height);
        }

        public virtual void Update(GameTime gameTime)
        {
            deltatime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public bool Collisions()
        {
            return Collisions(rect);
        }

        public bool Collisions(Rectangle _rect)
        {
            if (scene == null)
                return false;

            GameObject[] objs = scene.gameObjects.ToArray();

            foreach (GameObject gameObject in objs)
            {
                if (gameObject != this)
                {
                    if (gameObject.rect.Intersects(_rect) && gameObject.hasCollider)
                        return true;
                }
            }

            return false;
        }
    }
}
