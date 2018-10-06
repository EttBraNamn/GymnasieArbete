using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GymArbete.Blocks;


namespace GymArbete.Blocks
{
    class Floor : Block
    {

        public Floor(Vector2 pos, float f) : base(f)
        {
            type = BlockType.Floor;
            position = pos;
        }

    }
}
