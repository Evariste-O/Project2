using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Project2.Components;
using Project2.Enums;
using System;
using System.Diagnostics;
using System.Linq;

namespace Project2
{
    public class Game1 : Game
    {
        GameObject gameObject;
        Menu menu;

        Stopwatch stopwatch= new Stopwatch();
        int errors = 0;
        bool isRunning = false;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.ApplyChanges();

            gameObject = new(Content);
            menu = new Menu(Content);
            stopwatch.Start();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            gameObject.Piano.WhiteKeyTexture = Content.Load<Texture2D>("white");
            gameObject.Piano.BlackKeyTexture = Content.Load<Texture2D>("black");
            gameObject.NoteWindow.Lines = Content.Load<Texture2D>("symbols");
            gameObject.NoteWindow.Symbol = Content.Load<Texture2D>("symbols");
            menu.PlayButtonTexture = Content.Load<Texture2D>("play-button");
        }

        protected override void Update(GameTime gameTime)
        {
            if (isRunning)
            {
                if(!gameObject.IsInitialized)gameObject.Initialize();   
                isRunning = gameObject.Update(gameTime);
            }
            else
            {
                isRunning = menu.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            if (isRunning)
            {
                gameObject.Draw(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            }
            else
            {
                menu.Draw(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, gameObject.HighScore);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}