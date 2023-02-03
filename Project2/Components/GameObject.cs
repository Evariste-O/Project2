using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO.IsolatedStorage;
using System.Xml.Linq;
using System.IO;

namespace Project2.Components
{
    internal class GameObject
    {
        public ContentManager Content { get; private set; }
        public bool IsInitialized { get; private set; }
        public Piano Piano { get; set; }
        public NoteWindow NoteWindow { get; set; }

        readonly Stopwatch stopwatch = new();
        readonly Stopwatch score = new();

        public GameObject(ContentManager content) 
        {
            Content = content;
            NoteWindow = new NoteWindow(content);
            Piano = new Piano();
        }

        public void Initialize()
        {
            stopwatch.Restart();
            score.Restart();
            IsInitialized= true;
        }

        public bool Update(GameTime gameTime) 
        {
            if (stopwatch.ElapsedMilliseconds > 1000)
            {
                NoteWindow.AddNote(Content);
                stopwatch.Restart();
            }
            NoteWindow.Update(gameTime);

            var touchState = TouchPanel.GetState();
            foreach (var touch in touchState)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    var x = touch.Position.X;
                    var y = touch.Position.Y;
                    foreach (Key key in Piano.Keys)
                    {
                        if (key.KeyArea.Contains(x, y))
                        {
                            var noteToSolve = NoteWindow.Notes.FirstOrDefault(note => note.Active);
                            if (NoteWindow.Notes.Any() && noteToSolve is not null && key.KeyValue == noteToSolve.Value)
                            {
                                noteToSolve.Active = false;
                            }
                            else
                            {
                                NoteWindow.Lives--;
                                
                            }
                        }
                    }
                }
            }
            if (NoteWindow.Lives < 0)
            {
                NoteWindow.Lives = 3;
                NoteWindow.Notes.Clear();
                IsInitialized = false;
                return false;
            }
            return true;   
        }

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            Piano.Draw(spriteBatch, screenWidth, screenHeight);
            NoteWindow.Draw(spriteBatch, screenWidth, screenHeight);
            spriteBatch.DrawString(Content.Load<SpriteFont>("Font"), "Score: " + (score.ElapsedMilliseconds/100).ToString(), new Vector2(600, 0), Color.White);
        }
    }
}
