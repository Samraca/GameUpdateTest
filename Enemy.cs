using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BackgroundTest
{
    class Enemy : MovingSprite
    {
        public Enemy(Rectangle newRectangle, int EnemyHealth, Game1 newRoot, String textureName)
        {
            
            rectangle = newRectangle;
            HealthPoints = EnemyHealth;
            Initialize();
            LoadContent(newRoot, textureName);
        }

        public void Update()
        {
            FramesPerSecond();
        }
    }
}
