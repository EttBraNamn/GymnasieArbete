using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GymArbete.Blocks
{
    public enum BlockType { Wall, Floor, Carpet, Up, Down}
    public abstract class Block
    {
        public Vector2 position;
        protected BlockType type;
        protected Color color;
        protected float value;
        public Block(float value)
        {
            Console.WriteLine(value);
            this.value = value;

            value += 1;
            value /= 2;

            color = new Color(1 - value , 1 - value,1 - value);
        }

        private Vector2 Position()
        {             
            return position * 16;
        }

        public BlockType Type()
        {
            return type;
        }

        public int GetValue()
        {
            int toReturn = 3;
            for (float i = -3; i < value; i += 0.25f, ++toReturn);

            return toReturn;
        }

        public Vector2 Key()
        {
            return position;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = Textures.Block(type);
            if (texture != null)
            {
                spriteBatch.Draw(texture, Position(), color);
            }
        }

    }
}
