using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Undertale.Scripts.Backend;
using Undertale.Scripts.PlayerScripts;

namespace Undertale.Scripts
{
    public class PersistentScene : IScene
    {

        public Player player;

        public Camera camera;

        public void Load()
        {
            player = new Player(new Vector2(320 / 2, 180 / 2), new Vector2(19, 40));
            

            camera = new Camera(Vector2.Zero, new Vector2(0f, -40f));
        }

        public void Update(GameTime gametime)
        {
            player.Update(gametime);

            
            camera.FollowPosition(player, new Vector2(320, 240));
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            Rectangle rect = new Rectangle(player.rect.X + (int)camera.position.X, player.rect.Y + (int)camera.position.Y, player.rect.Width, player.rect.Height);

            _spriteBatch.Draw(player.spr.texture, rect, Color.White);
        }

        public void DrawUI(SpriteBatch _spriteBatch)
        {

        }
    }
}
