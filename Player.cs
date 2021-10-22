using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BackgroundTest
{
    class Player : MovingSprite
    {
        
        public Player( Rectangle newRectangle, int PlayerHealth, Game1 newRoot, String textureName)
        {
            
            rectangle = newRectangle;
            HealthPoints = PlayerHealth;
            Initialize();
            LoadContent(newRoot,textureName);
        }

        public void Update()
        {
            FramesPerSecond();
        }

        
    }
}
