using Microsoft.Xna.Framework;
namespace GymArbete.Blocks
{
    class Staircase : Block
    {
        bool down;
        public Staircase(Vector2 pos, bool down) : base(0)
        {
            this.down = down;
            position = pos;
            if (!down)
            {
                type = BlockType.Up;
            }
            else
            {
                type = BlockType.Down;
            }
        }
        public bool FloorUp()
        {
            return down;
        }
    }
}
