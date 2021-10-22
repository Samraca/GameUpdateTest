using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BackgroundTest
{
    class Sprite
    {
        public Texture2D texture;
        public Rectangle rectangle;

        public void Draw(SpriteBatch spritebach)
        {
            spritebach.Draw(texture,rectangle,Color.White);
        }
    }
}
