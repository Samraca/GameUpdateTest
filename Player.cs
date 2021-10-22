using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BackgroundTest
{
    class Player : Sprite
    {
        public Player( Rectangle newRectangle, int PlayerHealth, Game1 newRoot, String textureName)
        {
            texture = LoadContent(newRoot,textureName);
            rectangle = newRectangle;
            HealthPoints = PlayerHealth;
        }

        
    }
}
