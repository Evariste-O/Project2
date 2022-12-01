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

        public void Draw(SpriteBatch spriteBatch, Texture2D keyTexture, Rectangle keyArea)
        {
            KeyArea = keyArea;
            spriteBatch.Draw(keyTexture, KeyArea, KeyColor);
        }
    }
}
