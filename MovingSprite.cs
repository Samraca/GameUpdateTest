using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BackgroundTest
{
    class MovingSprite : Sprite
    {
        byte fps = 0;
        byte actualImage = 1;
        Texture2D[] Static;
        Texture2D[] MovingRight;
        Texture2D[] MovingLeft;

        public void Initialize()
        {
            Static = new Texture2D[6];
            MovingLeft = new Texture2D[6];
            MovingRight = new Texture2D[6];
        }
        public void LoadContent(Game1 root, String baseTextureName)
        {
            for (int i = 0; i < 6; i++)
            {
                Static[i] = root.Content.Load<Texture2D>(baseTextureName + (i + 1));
                //MovingRight[i] = root.Content.Load<Texture2D>(baseTextureName + (i + 1));
                //MovingLeft[i] = root.Content.Load<Texture2D>(baseTextureName + (i + 1));
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            for (int i = 0; i < 7; i++)
            {
                spritebatch.Draw(Static[actualImage], rectangle, Color.White);
                //spritebatch.Draw(MovingLeft[actualImage], rectangle, Color.White);
                //spritebatch.Draw(MovingRight[actualImage], rectangle, Color.White);
            }
        }

        public void FramesPerSecond()
        {
            fps++;
            if (fps>10)
            {
                fps = 0;
                actualImage +=1;
                if (actualImage >=6)
                {
                    actualImage = 0;
                }
            }
        }

    }
}
