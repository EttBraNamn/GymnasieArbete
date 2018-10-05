﻿using GymArbete.Blocks;
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
        private static SpriteFont font;
        public static void Init(ContentManager content)
        {
            wall = content.Load<Texture2D>("wall");
            floor = content.Load<Texture2D>("floor");
            player = content.Load<Texture2D>("player");
            font = content.Load<SpriteFont>("font");
        }

        public static Texture2D Player()
        {
            return player;
        }

        public static SpriteFont Font()
        {
            return font;
        }

        public static Texture2D Block(BlockType type)
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
