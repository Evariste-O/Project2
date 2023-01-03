using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Project2.Enums;
using System;
using System.Diagnostics;
using System.Linq;

namespace Project2
{ 
    public class ButtonClickedEventArgs : EventArgs
    {
        public int Id { get; set; }
    }
    public class Game1 : Game
    {
        Piano piano;
        NoteWindow noteWindow;
        Menu menu;

        Stopwatch stopwatch= new Stopwatch();
        int errors = 0;
        bool isRunning = false;

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
            noteWindow = new NoteWindow();
            menu = new Menu();
            stopwatch.Start();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            piano.WhiteKeyTexture = Content.Load<Texture2D>("white");
            piano.BlackKeyTexture = Content.Load<Texture2D>("black");
            noteWindow.Lines = Content.Load<Texture2D>("symbols");
            menu.PlayButtonTexture = Content.Load<Texture2D>("playButton");

        }

        protected async override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            if (isRunning)
            {
                if (stopwatch.ElapsedMilliseconds > 1000) 
                { 
                    noteWindow.AddNote(Content);
                    stopwatch.Restart();
                }
                noteWindow.Update(gameTime);

                var touchState = TouchPanel.GetState();
                foreach (var touch in touchState)
                {
                    if (touch.State == TouchLocationState.Pressed)
                    {
                        var x = touch.Position.X;
                        var y = touch.Position.Y;
                        foreach (Key key in piano.Keys)
                        {
                            if (key.KeyArea.Contains(x, y))
                            {
                                var noteToSolve = noteWindow.Notes.FirstOrDefault(note => note.Active);
                                if (noteWindow.Notes.Any() && noteToSolve is not null && key.KeyValue == noteToSolve.Value)
                                {
                                    noteToSolve.Active = false;
                                }
                                else 
                                {

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                var touchState = TouchPanel.GetState();
                foreach (var touch in touchState)
                {
                    if (touch.State == TouchLocationState.Pressed)
                    {
                        var x = touch.Position.X;
                        var y = touch.Position.Y;
                        if (menu.PLayButton.Contains(x, y))
                        {
                            isRunning= true;
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
            if (isRunning)
            {
                piano.Draw(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
                noteWindow.Draw(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            }
            else
            {
                menu.Draw(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}