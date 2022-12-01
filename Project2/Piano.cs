using Android.Icu.Number;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class Piano
    {
        public Key[] Keys { get; set; }
        public Texture2D KeyTexture { get; set; }

        public Piano() 
        {
            Keys = new Key[12];
            for (int i = 0; i < 12; i++)
            {
                Keys[i] = new Key(i);
            }
        }

        public void Draw(SpriteBatch spriteBatch, int width, int height)
        {
            for(int i = 0; i < 12 ; i++)
            {
                if(i % 2 == 0)
                {
                    Keys[i].Draw(spriteBatch, KeyTexture, width, height);
                }
            }
        }
    }
}
