using Microsoft.Xna.Framework;


namespace GymArbete.Blocks
{
    class Wall : Block
    {

        public Wall(Vector2 pos) : base(0)
        {
            position = pos;
            type = BlockType.Wall;
        }

    }
}
