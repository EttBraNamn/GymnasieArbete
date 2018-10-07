using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GymArbete.Blocks
{
    public enum BlockType { Wall, Floor}
    public abstract class Block
    {
        protected Vector2 position;
        protected BlockType type;
        Color color;

        public Block(float value)
        {
            value /= 10;
            if (value < 0)
                value = 0.5f - value * -1f;
            else
                value = 0.5f + value;

            color = new Color(0.5f * value,value , 0.25f * value );
        }

        private Vector2 Position()
        {             
            return position * 1;
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
