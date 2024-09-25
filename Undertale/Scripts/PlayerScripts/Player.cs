using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Undertale.Scripts.Backend;

namespace Undertale.Scripts.PlayerScripts
{
    public class Player : GameObject
    {

        public Texture2D rightTex;
        public Texture2D leftTex;
        public Texture2D upTex;
        public Texture2D downTex;


        public float speed = 100f;

        public Vector2 movement;

        public Player(Vector2 position, Vector2 scale, GameScene scene) : base(position, scale, scene)
        {

        }

        public Player(Vector2 position, Vector2 scale) : base(position, scale, null)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
            if (scene == null)
                return;
            rightTex = content.Load<Texture2D>("Sprites/Player/spr_f_maincharar_0");
            leftTex = content.Load<Texture2D>("Sprites/Player/spr_f_maincharal_0");
            upTex = content.Load<Texture2D>("Sprites/Player/spr_f_maincharad_0");
            downTex = content.Load<Texture2D>("Sprites/Player/spr_f_maincharau_0");
        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);

            Vector2 input = Input.instance.arrowKeys;

            movement = input * speed * deltatime;

            position.X += movement.X;

            // Check for collisions on X axis
            if (Collisions(new Rectangle(rect.X + (int)movement.X, rect.Y, rect.Width, rect.Height)))
            {
                position.X -= movement.X;
                movement.X = 0;
            }

            position.Y += movement.Y;

            // Check for collisions on Y axis
            if (Collisions(new Rectangle(rect.X, rect.Y + (int)movement.Y, rect.Width, rect.Height)))
            {
                position.Y -= movement.Y;
                movement.Y = 0;
            }

            DetermineSprite();
        }

        public void DetermineSprite()
        {
            if (movement.X > 0)
                spr.texture = rightTex;
            else if (movement.X < 0)
                spr.texture = leftTex;

            if (movement.Y > 0)
                spr.texture = upTex;
            else if (movement.Y < 0)
                spr.texture = downTex;
        }
    }
}