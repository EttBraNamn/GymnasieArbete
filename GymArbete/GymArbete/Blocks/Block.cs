using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GymArbete.Blocks
{
    public enum BlockType { Wall, Floor}
    public abstract class Block
    {
        protected Vector2 position;
        protected BlockType type;


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
            Texture2D texture = Textures.GetTexture(type);

            if (texture != null)
            {
                spriteBatch.Draw(texture, Position(), Color.White);
            }
        }

    }
}
