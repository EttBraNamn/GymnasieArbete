using Microsoft.Xna.Framework;


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
