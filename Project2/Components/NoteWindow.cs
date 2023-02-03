using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project2.Enums;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input.Touch;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.ContactsContract.CommonDataKinds;
using Microsoft.Xna.Framework.Content;
using Android.Graphics.Fonts;

namespace Project2.Components
{
    internal class NoteWindow
    {
        public List<Note> Notes { get; set; }
        public Texture2D Lines { get; set; }
        SpriteFont SpriteFont { get; set; }
        public int Lives { get; set; }

        public NoteWindow(ContentManager content)
        {
            Notes = new List<Note>();
            Lives = 3;
            SpriteFont = content.Load<SpriteFont>("Font");
        }

        public void Update(GameTime gameTime)
        {
            MoveNotes(200 * gameTime.ElapsedGameTime.TotalSeconds);
            if (Notes.FirstOrDefault(note => note.SpriteArea.Top == 694) is null) AdjustFirstActiveSprite();
            foreach (var note in Notes)
            {
                note.Update();
                if(note.NoteArea.Left < -90)
                {
                    Lives--;
                }
            }
            Notes.RemoveAll(note => note.NoteArea.Left < -90 || note.NoteColor.A < 10);
        }

        private void AdjustFirstActiveSprite()
        {
            var firstActiveNote = Notes.FirstOrDefault(note => note.Active);
            if (firstActiveNote != null)
            {
                firstActiveNote.SpriteArea = new Rectangle(firstActiveNote.SpriteArea.X, 694, firstActiveNote.SpriteArea.Width, firstActiveNote.SpriteArea.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            //draw the lines
            spriteBatch.Draw(Lines, new Rectangle(0, 0, screenWidth, 694), new Rectangle(300, 0, 300, 694), Color.White);
            spriteBatch.Draw(Lines, new Rectangle(0, 694, screenWidth, 694), new Rectangle(300, 0, 300, 694), Color.White);

            //draw the notes
            foreach (var note in Notes)
            {
                note.Draw(spriteBatch);
            }
            spriteBatch.DrawString(SpriteFont, "Lives:" + Lives.ToString(), new Vector2(100, 0), Color.White);
        }

        public void MoveNotes(double speed)
        {
            foreach (var note in Notes)
            {
                Rectangle area = note.NoteArea;
                area.Offset((int)-speed, 0);
                note.NoteArea = area;
            }
        }

        public void AddNote(ContentManager content)
        {
            Notes.Add(new Note(content));
        }
    }
}