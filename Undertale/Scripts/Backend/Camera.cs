

using Microsoft.Xna.Framework;
using Undertale.Scripts.PlayerScripts;

namespace Undertale.Scripts.Backend
{
    public class Camera
    {
        public Vector2 position;

        public Vector2 offset;

        public Camera(Vector2 position)
        {
            this.position = position;
        }

        public Camera(Vector2 position, Vector2 offset)
        {
            this.offset = offset;
            this.position = position;
        }

        public void FollowPosition(Rectangle target, Vector2 screenSize)
        {
            position = new Vector2(
                -target.X + (screenSize.X * .5f - target.Width * .5f),
                -target.Y + (screenSize.X * .5f - target.Width * .5f)
            );
        }

        public void FollowPosition(Player target, Vector2 screenSize)
        {
            position = new Vector2(
                -target.rect.X + (screenSize.X * .5f - target.rect.Width * .5f) + offset.X,
                -target.rect.Y + (screenSize.X * .5f - target.rect.Width * .5f) + offset.Y
            );
        }
    }
}
