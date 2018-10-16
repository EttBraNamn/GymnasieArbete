using Microsoft.Xna.Framework;
namespace GymArbete.Blocks
{
    class Staircase : Block
    {
        bool up;
        public Staircase(Vector2 pos, bool up) : base(0)
        {
            this.up = up;
            position = pos;
            type = BlockType.Staircase;
        }
        public bool FloorUp()
        {
            return up;
        }
    }
}
