using GymArbete.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GymArbete
{
    public static class Textures
    {
        private static Texture2D wall;
        private static Texture2D floor;
        private static Texture2D player;
        
        public static void Init(ContentManager content)
        {
            wall = content.Load<Texture2D>("wall");
            floor = content.Load<Texture2D>("floor");
            player = content.Load<Texture2D>("player");

        }

        public static Texture2D GetTexture(BlockType type)
        {
            switch (type)
            {
                case BlockType.Floor:
                    return floor;
                case BlockType.Wall:
                    return wall;
            }
            return null;
        }

    }
}
