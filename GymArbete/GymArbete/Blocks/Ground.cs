using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GymArbete.Blocks;


namespace GymArbete.Blocks
{
    class Ground : Block
    {

        public Ground(Vector2 pos) : base(0)
        {
            type = BlockType.Floor;
            position = pos;
        }


        public Ground(Vector2 pos, float f) : base(f)
        {
            type = BlockType.Floor;
            position = pos;
        }

    }
}
