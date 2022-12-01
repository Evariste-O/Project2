using Android.Icu.Number;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Resource;

namespace Project2
{
    internal class Piano
    {
        public Key[] Keys { get; set; }
        public Texture2D KeyTexture { get; set; }

        public Piano() 
        {
            int pianoLength = 15;
            Keys = new Key[12];
            for (int i = 0; i < 12; i++)
            {
                Keys[i] = new Key(i);
            }
        }

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            int whiteKeyCounter = 0;

            int keyX;
            int keyY = (screenHeight / 3) * 2;

            int whiteKeyWidth = screenWidth / 7;
            int whiteKeyHeight = screenHeight / 3;

            int blackKeyWidth = whiteKeyWidth / 2;
            int blackKeyHeight = (whiteKeyHeight / 3) * 2;

            int[] blackKeys = { 1, 3, 6, 8, 10 };

            for(int i = 0; i < 12; i++)
            {
                if(!blackKeys.Contains(Keys[i].Id))
                {
                    keyX = whiteKeyWidth * whiteKeyCounter;
                    Keys[i].Draw(spriteBatch, KeyTexture, new Rectangle(keyX, keyY, whiteKeyWidth, whiteKeyHeight));
                    whiteKeyCounter++;
                }
            }
            for (int i = 0; i < 12; i++)
            {
                if (blackKeys.Contains(Keys[i].Id))
                {
                    keyX = Keys[i - 1].KeyArea.Right - whiteKeyWidth / 4;
                    Keys[i].Draw(spriteBatch, KeyTexture, new Rectangle(keyX, keyY, blackKeyWidth, blackKeyHeight));
                }
            }
        }
    }
}
