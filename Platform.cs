using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BackgroundTest
{
    class Platform : Sprite
    {
        public Platform(Texture2D platformTexture, Rectangle platformRectangle)
        {
            texture = platformTexture;
            rectangle = platformRectangle;
        }
    }
}
