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

    }
}
