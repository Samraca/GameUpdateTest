using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BackgroundTest
{
    class Enemy : Sprite
    {
        public Enemy(Rectangle newRectangle, int EnemyHealth, Game1 newRoot, String textureName)
        {
            texture = LoadContent(newRoot,textureName);
            rectangle = newRectangle;
            HealthPoints = EnemyHealth;
        }
    }
}
