using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace GymArbete.Blocks
{
    class Wall : Block
    {

        public Wall(Vector2 pos, float f) : base(f)
        {
            position = pos;
            type = BlockType.Wall;
        }

    }
}
