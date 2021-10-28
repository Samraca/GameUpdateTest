using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BackgroundTest
{
    class Player : MovingSprite
    {
        Vector2 VectorialPosition;
        Vector2 Gravity;
        Point CardinalPosition;
        bool hasjumped;
        public int actualHeight;
        public Player(Rectangle newRectangle, int PlayerHealth, Game1 newRoot, String textureName)
        {
            VectorialPosition.X = newRectangle.X;
            VectorialPosition.Y = newRectangle.Y;
            hasjumped = true;
            rectangle = newRectangle;
            HealthPoints = PlayerHealth;
            actualHeight = 1000;
            Initialize();
            LoadContent(newRoot, textureName);
        }

        public void Update()
        {
            FramesPerSecond();
            Movement();
        }

        public void Movement()
        {
            VectorialPosition += Gravity;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                VectorialPosition.X++;
                Gravity.X = 3f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                VectorialPosition.X--;
                Gravity.X = -3f;
            }
            else
            {
                Gravity.X = 0f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasjumped == false)
            {
                VectorialPosition.Y -= 19f;
                Gravity.Y = -20f;
                hasjumped = true;
            }

            if (hasjumped)
            {
                float i = 1;
                Gravity.Y += 0.5f * i;
            }

            if (VectorialPosition.Y + rectangle.Height >= actualHeight)
            {
                hasjumped = false;
            }

            if (hasjumped == false)
            {
                Gravity.Y = 0f;
            }
            
            if (VectorialPosition.X <= -20)
            {
                VectorialPosition.X = -20;
            }
            CardinalPosition = Vector2ToPoint(VectorialPosition, CardinalPosition);
            rectangle.X = CardinalPosition.X;
            rectangle.Y = CardinalPosition.Y;

        }

        public Point Vector2ToPoint(Vector2 newVector, Point newPoint)
        {
            newPoint.X = Convert.ToInt32(newVector.X);
            newPoint.Y = Convert.ToInt32(newVector.Y);
            return newPoint;
        }

        public Boolean IsOnTop(Rectangle platform )
        {
            if (rectangle.X<=platform.Right && rectangle.X>=platform.Left && rectangle.Y<platform.Bottom)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void restartPosition()
        {
            VectorialPosition.X = 0f;
            VectorialPosition.Y = 0f;
            HealthPoints = 100;
            hasjumped = true;
        }
    }


}
