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
        public Game1 root;
        public String textureName;
        public int HealthPoints;

        public Texture2D LoadContent(Game1 newRoot, String newTextureName)
        {
            root = newRoot;
            textureName = newTextureName;
            return root.Content.Load<Texture2D>(textureName);
            
        }
        public void Update(GameTime gametime)
        {

        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture,rectangle,Color.White);
        }
    }
}
