using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class Menu
    {
        public Rectangle PLayButton { get; set; }
        public Texture2D PlayButtonTexture { get; set; }

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            int x = screenWidth/ 2 - PlayButtonTexture.Width / 2;
            int y = screenHeight / 2 - PlayButtonTexture.Height / 2;
            PLayButton = new Rectangle( x, y, PlayButtonTexture.Width, PlayButtonTexture.Height);
            spriteBatch.Draw(PlayButtonTexture, new Vector2(x, y), Color.White);
        }
    }
}
