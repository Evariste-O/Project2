﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Components
{
    internal class Menu
    {
        public ContentManager Content { get; private set; }
        public Rectangle PLayButton { get; set; }
        public Texture2D PlayButtonTexture { get; set; }


        public Menu(ContentManager content) 
        {
            Content = content;
        }
        public bool Update()
        {
            var touchState = TouchPanel.GetState();
            foreach (var touch in touchState)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    var x = touch.Position.X;
                    var y = touch.Position.Y;
                    if (PLayButton.Contains(x, y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight, int highScore)
        {
            int x = screenWidth / 2 - PlayButtonTexture.Width / 2;
            int y = screenHeight / 2 - PlayButtonTexture.Height / 2;
            PLayButton = new Rectangle(x, y, PlayButtonTexture.Width, PlayButtonTexture.Height);
            spriteBatch.Draw(PlayButtonTexture, new Vector2(x, y), Color.White);
            spriteBatch.DrawString(Content.Load<SpriteFont>("Font"), highScore.ToString(), new Vector2(510, 600), Color.Black);
        }
    }
}
