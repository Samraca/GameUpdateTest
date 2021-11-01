using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BackgroundTest
{
    class Bullet : Sprite
    {
        bool isVisible;
        public Bullet(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;
            isVisible = false;
        }

        public void Update(Game1 root)
        {
            if (isVisible)
            {
                rectangle.X += 10;
                if (rectangle.X>root.Window.ClientBounds.Width)
                {
                    isVisible = false;
                }
            }
            
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (isVisible)
            {
                spritebatch.Draw(texture, rectangle, Color.White);
            }
        }

        public void SetIsVisbible(bool state)
        {
            isVisible = state;
        }

        public bool GetIsVisible()
        {
            return isVisible;
        }
    }
}
