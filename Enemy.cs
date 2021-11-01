using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BackgroundTest
{
    class Enemy : MovingSprite
    {
        bool emc11;
        bool emc12;
        bool isDead;
        public Enemy(Rectangle newRectangle, int EnemyHealth, Game1 newRoot, String textureName)
        {
            
            rectangle = newRectangle;
            HealthPoints = EnemyHealth;
            emc11 = true;
            emc12 = false;
            isDead = false;
            Initialize();
            LoadContent(newRoot, textureName);
        }

        public void Update(int leftBorder, int rightBorder)
        {
            FramesPerSecond();
            MoveControl(leftBorder,rightBorder);
        }

        public void MoveLeft()
        {
            rectangle.X -= 1;

        }

        public void MoveRight()
        {
            rectangle.X += 1;

        }
        public void MoveControl(int a, int b)
        {
            if (emc11 && isDead == false)
            {
                this.MoveRight();
            }
            if (rectangle.X >= b)
            {
                emc11 = false;
                emc12 = true;
            }
            if (emc12 && isDead == false)
            {
                this.MoveLeft();
            }
            if (rectangle.X <= a)
            {
                emc11 = true;
                emc12 = false;
            }
        }
    }
}
