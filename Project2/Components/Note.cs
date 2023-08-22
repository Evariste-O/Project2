using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project2.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace Project2.Components
{
    internal class Note
    {
        public int Index { get; set; }
        public Clef Clef { get; set; }
        public KeyValue Value { get; set; }
        public Rectangle NoteArea { get; set; }
        public Rectangle SpriteArea { get; set; }
        public Color NoteColor { get; set; } = Color.White;
        public Texture2D NoteTexture { get; set; }
        public bool Active { get; set; }

        public Note(ContentManager content)
        {
            Active = true;
            Value = new KeyValue();
            Clef = new Random().Next(2) == 0 ? Clef.treble : Clef.bass;
            NoteArea = new Rectangle(1200, Clef == Clef.treble ? 0 : 694, 124, 694);
            Index = new Random().Next(0, 24);
            SpriteArea = new Rectangle(0 + 125 * Index, 0, 125, 694);
            NoteTexture = content.Load<Texture2D>("notes");
            switch (Index)
            {
                case 0:
                case 7:
                case 14:
                case 21:
                    Value = Clef == Clef.bass ? KeyValue.f : KeyValue.d; break;
                case 1:
                case 8:
                case 15:
                case 22:
                    Value = Clef == Clef.bass ? KeyValue.g : KeyValue.e; break;
                case 2:
                case 9:
                case 16:
                case 23:
                    Value = Clef == Clef.bass ? KeyValue.a : KeyValue.f; break;
                case 3:
                case 10:
                case 17:
                case 24:
                    Value = Clef == Clef.bass ? KeyValue.h : KeyValue.g; break;
                case 4:
                case 11:
                case 18:
                    Value = Clef == Clef.bass ? KeyValue.c : KeyValue.a; break;
                case 5:
                case 12:
                case 19:
                    Value = Clef == Clef.bass ? KeyValue.d : KeyValue.h; break;
                case 6:
                case 13:
                case 20:
                    Value = Clef == Clef.bass ? KeyValue.e : KeyValue.c; break;
            }
        }

        public void Update()
        {
            if (!Active)
            {
                SpriteArea = new Rectangle(SpriteArea.X, 0, SpriteArea.Width, SpriteArea.Height);
                NoteColor = NoteColor * 0.80f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(NoteTexture, NoteArea, SpriteArea, NoteColor);
        }
    }
}
