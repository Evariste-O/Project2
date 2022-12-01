using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class Key
    {
        public int Id { get; set; }
        public Color KeyColor { get; set; }
        public Rectangle KeyArea { get; set; }

        public Key(int id)
        {
            Id = id;
            KeyColor= Color.White;  
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D keyTexture, int screenWidth, int screenHeight)
        {
            int keyWidth = screenWidth / 7;
            int keyHeight = screenHeight / 3;
            int keyX = keyWidth * Id;
            int keyY = (screenHeight /3)*2;
            KeyArea = new Rectangle(keyX, keyY, keyWidth, keyHeight);
            spriteBatch.Draw(keyTexture, KeyArea, KeyColor);
        }
    }
}
