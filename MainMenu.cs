using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BackgroundTest
{
    class MainMenu : Sprite
    {
        
        public MainMenu(Texture2D menuSpriteSheet, Rectangle sourceRectangle)
        {
            texture = menuSpriteSheet;
            rectangle = sourceRectangle;
            
        }

        
    }
}
