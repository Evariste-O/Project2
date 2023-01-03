using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project2.Enums;

namespace Project2
{
    internal class Key
    {
        public int Id { get; set; }
        public KeyValue KeyValue { get; set; }
        public Rectangle KeyArea { get; set; }
        public Color Mask { get; set; } = Color.White;

        public Key(int id, KeyValue value)
        {
            Id = id;
            KeyValue = value;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D keyTexture, Rectangle keyArea)
        {
            KeyArea = keyArea;
            spriteBatch.Draw(keyTexture, KeyArea, Mask);
        }
    }
}
