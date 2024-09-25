using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undertale.Scripts.Backend
{
    public class Sprite
    {
        public Texture2D texture;
        public Color color;

        public Sprite(Texture2D texture, Color color)
        {
            this.texture = texture;
            this.color = color;
        }
    }
}
