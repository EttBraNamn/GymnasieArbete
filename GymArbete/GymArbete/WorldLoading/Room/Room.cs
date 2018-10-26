using Microsoft.Xna.Framework;
using GymArbete.Blocks;
using System;
using System.Collections.Generic;

namespace GymArbete.WorldLoading
{
    public enum Orientation {Left = 0, Up = 1, Down = 2, Right = 3, None = 4};
    class Room
    {
        public Vector2 offset;
        public int doors;
        public Orientation[] orientations;
        Orientation enterence;
        Block[,] blocks;


        public bool AddDoor(Random rng)
        {
            if (orientations.Length > 2)
            {
                return false;
            }

            int i = rng.Next(0, 4);
            while (enterence != (Orientation)i && Contains(orientations, (Orientation)i))
            {
                i = rng.Next(0, 4);
            }
            orientations = new Orientation[1];
            orientations[0] = (Orientation)i;
            return true;
        }

        public Block[,] GetBlocks()
        {
            return blocks;
        }

        public Room(Vector2 offset, int doorsLeft,Random rng,Orientation enterence = Orientation.None)
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

            for (int i = 0; i < orientations.Length; ++i)
            {
                Orientation orientation = GetOrientation(rng);

                if (Contains(orientations, orientation))
                {
                    orientations[i] = orientation;
                }
            }

            blocks = new Block[21, 13];

            if (enterence == Orientation.None)
            {
                blocks = Templates.Entrance(rng, orientations);
            }
            else
            {
                blocks = Templates.Room(rng, orientations, enterence);
            }
        }

        public void MakeExit()
        {
            blocks[10, 6] = new Staircase(new Vector2(10, 6), false);
        }

        private Orientation GetOrientation(Random rng)
        {
            switch (rng.Next(0, 4))
            {
                case 0:
                    return Orientation.Left;
                case 1:
                    return Orientation.Right;
                case 2:
                    return Orientation.Up;
                case 3:
                    return Orientation.Down;
            }
            return Orientation.None;
        }

        private bool Contains(Orientation[] orarray, Orientation or)
        {
            for (int i = 0; i < orarray.Length; ++i)
            {
                if (orarray[i] == or)
                    return false;
            }
            return true;
        }

    }
}
