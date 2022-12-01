using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;



namespace Project2
{
    public class ButtonClickedEventArgs : EventArgs
    {
        public int Id { get; set; }
    }
    public class Game1 : Game
    {
        Piano piano;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.ApplyChanges();

            // TODO: Add your initialization logic here
            piano = new Piano();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            piano.WhiteKeyTexture = Content.Load<Texture2D>("white");
            piano.BlackKeyTexture = Content.Load<Texture2D>("white");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var touchState = TouchPanel.GetState();
            foreach (var touch in touchState)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    Log.Debug("swag", "screen touched!");
                    var x = touch.Position.X;
                    var y = touch.Position.Y;
                    foreach (Key key in piano.Keys)
                    {
                        if (key.KeyArea.Contains(x, y))
                        {
                            Log.Debug("swag", "button touched!");
                            if (key.Mask == Color.White)
                            {
                                key.Mask = Color.Tomato;
                            }
                            else
                            {
                                key.Mask = Color.White;
                            }
                            break;
                            //ClearButton.AnAction(ClearButton, new ButtonClickedEventArgs() { Id = ClearButton.Id });
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            piano.Draw(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}