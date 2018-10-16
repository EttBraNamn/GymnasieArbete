using Microsoft.Xna.Framework;


namespace GymArbete.Blocks
{
    class Carpet : Block
    {

        public Carpet(Vector2 pos) : base(0)
        {
            type = BlockType.Carpet;
            position = pos;
        }

    }
}
