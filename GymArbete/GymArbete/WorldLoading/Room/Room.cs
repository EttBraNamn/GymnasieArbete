using Microsoft.Xna.Framework;
using GymArbete.Blocks;
using System;

namespace GymArbete.WorldLoading
{
    enum Orientation {Left = 0, Up = 1, Down = 2, Right = 3, None = 4};
    class Room
    {
        Vector2 offset;
        int doors;
        public Orientation[] orientations;
        Orientation enterence;
        Block[,] blocks;

        public Room(Vector2 offset, int doorsLeft,Random rng, Orientation enterence = Orientation.None)
        {
            //The position the room will be in relative to all the other
            this.offset = offset;
            //What side the enterence will be on
            this.enterence = enterence;
            if (doorsLeft < 3 && doorsLeft > 0)
            {
                doors = rng.Next(0, doorsLeft + 1);
            }
            else if (doorsLeft > 4)
            {
                doors = rng.Next(0, 4);
            }
            orientations = new Orientation[doors];
            blocks = new Block[21, 13];

            if (enterence == Orientation.None)
            {
                blocks = Templates.Entrance(orientations);
            }
        }

    }
}
