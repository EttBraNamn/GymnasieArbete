using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GymArbete.Blocks
{
    public enum BlockType { Wall, Floor, Carpet, Staircase}
    public abstract class Block
    {
        public Vector2 position;
        protected BlockType type;
        Color color;

        public Block(float value)
        {
            value /= 10;
            if (value < 0)
                value = 0.5f - value * -1f;
            else
                value = 0.5f + value;

            color = new Color(1 - 0.8967f * value, 1 - 0.4684f * value , 1 - 0.8f * value );
        }

        private Vector2 Position()
        {             
            return position * 16;
        }

        public BlockType Type()
        {
            return type;
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
