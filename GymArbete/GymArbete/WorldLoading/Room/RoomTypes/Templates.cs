using System;
using GymArbete.Blocks;
using Microsoft.Xna.Framework;
namespace GymArbete.WorldLoading
{
    static class Templates
    {
        //Makes a regular room
        public static Block[,] Room(Random rng, Orientation[] orientations, Orientation enterance)
        {
            Block[,] blocks = Walls(orientations, enterance);

            //Gets the pattern used for the floor
            int[,] pattern = RoomPattern(rng);

            for (int x = 0; x < 19; ++x)
            {
                for (int y = 0; y < 11; ++y)
                {
                    if (pattern[x, y] == 1)
                    {
                        blocks[1 + x, 1 + y] = new Carpet(new Vector2(1 + x, 1 + y));
                    }
                    else
                    {
                        blocks[1 + x, 1 + y] = new Ground(new Vector2(1 + x, 1 + y));
                    }
                }
            }
            return blocks;
        }
        public static Block[,] Entrance(Random rng, Orientation[] orientations)
        {
            //Creates the object and all the walls with doors
            Block[,] blocks = Walls(orientations, Orientation.None);

            //Making all the floor blocks randomising if they are regular floor or carpet
            for (int x = 1; x < 20; ++x)
            {
                for (int y = 1; y < 12; ++y)
                {
                    if (rng.Next(0, 2) != 1)
                    {
                        blocks[x, y] = new Ground(new Vector2(x, y));
                    }
                    else
                    {
                        blocks[x, y] = new Carpet(new Vector2(x, y));
                    }
                }
            }

            blocks[10, 6] = new Staircase(new Vector2(10, 6), true);
            return blocks;
        }


        //Makes all of the walls and doors
        private static Block[,] Walls(Orientation[] orientations, Orientation enterence)
        {
            Block[,] blocks = new Block[21, 13];

            //Creating all the walls
            for (int i = 0; i < 21; ++i)
            {
                blocks[i, 0] = new Wall(new Vector2(i, 0));
            }
            for (int i = 0; i < 21; ++i)
            {
                blocks[i, 12] = new Wall(new Vector2(i, 12));
            }

            for (int i = 0; i < 13; ++i)
            {
                blocks[0, i] = new Wall(new Vector2(0, i));
            }
            for (int i = 0; i < 13; ++i)
            {
                blocks[20, i] = new Wall(new Vector2(20, i));
            }
            
            //Creates all of the doors
            for (int i = 0; i < orientations.Length; ++i)
            {
                blocks = SetOrientation(blocks, orientations[i]);
            }
            blocks = SetOrientation(blocks, enterence);

            return blocks;
        }

        private static int[,] RoomPattern(Random rng)
        {
            int[,] vs = new int[19, 11];

            switch (rng.Next(0, 4))
            {
                case 0:
                    vs = Room0;
                    break;
                case 1:
                    vs = Room1;
                    break;
                case 2:
                    vs = Room2;
                    break;
                case 3:
                    vs = Room3;
                    break;
                default:
                    vs = Room0;
                    break;
            }

            return vs;
        }

        private static Block[,] SetOrientation(Block[,] blocks, Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Left:
                    blocks[0, 6] = new Ground(new Vector2(0, 6));
                    break;
                case Orientation.Up:
                    blocks[10, 0] = new Ground(new Vector2(10, 0));
                    break;
                case Orientation.Down:
                    blocks[10, 12] = new Ground(new Vector2(10, 12));
                    break;
                case Orientation.Right:
                    blocks[20, 6] = new Ground(new Vector2(20, 6));
                    break;
            }
            return blocks;
        }

        //Different room patterns. 1 = Carpet, 0 = Ground
        static private int[,] Room0
        {
            get
            {
                return new int[19, 11]
                    {
                        { 1,0,1,0,0,0,0,0,0,0,0},
                        { 0,1,0,1,0,0,0,0,0,0,0},
                        { 0,0,1,0,1,0,0,0,0,0,0},
                        { 0,0,0,1,0,1,0,0,0,0,0},
                        { 0,0,0,0,1,0,1,0,0,0,0},
                        { 0,0,0,0,0,1,0,1,0,0,0},
                        { 0,0,0,0,0,0,1,0,1,0,0},
                        { 0,0,0,0,0,0,0,1,0,1,0},
                        { 0,0,0,0,0,0,0,0,1,0,1},
                        { 0,0,0,0,0,0,0,0,0,1,0},
                        { 0,0,0,0,0,0,0,0,1,0,1},
                        { 0,0,0,0,0,0,0,1,0,1,0},
                        { 0,0,0,0,0,0,1,0,1,0,0},
                        { 0,0,0,0,0,1,0,1,0,0,0},
                        { 0,0,0,0,1,0,1,0,0,0,0},
                        { 0,0,0,1,0,1,0,0,0,0,0},
                        { 0,0,1,0,1,0,0,0,0,0,0},
                        { 0,1,0,1,0,0,0,0,0,0,0},
                        { 1,0,0,0,0,0,0,0,0,0,0},
                    };
            }
        }
        static private int[,] Room1
        {
            get
            {
                return new int[19, 11]
                    {
                        { 1,1,1,1,1,1,1,1,1,1,1},
                        { 1,0,0,0,0,0,0,1,0,1,1},
                        { 1,0,0,0,0,0,1,0,1,0,1},
                        { 1,0,0,0,0,1,0,1,0,1,1},
                        { 1,0,0,0,1,0,1,0,1,0,1},
                        { 1,0,0,1,0,1,0,1,0,0,1},
                        { 1,0,1,0,1,0,1,0,0,0,1},
                        { 1,1,0,1,0,1,0,0,0,1,1},
                        { 1,0,1,0,1,0,0,0,1,0,1},
                        { 1,1,0,1,0,0,0,1,0,1,1},
                        { 1,0,1,0,0,0,1,0,1,0,1},
                        { 1,1,0,0,0,1,0,1,0,1,1},
                        { 1,0,0,0,1,0,1,0,1,0,1},
                        { 1,0,0,1,0,1,0,1,0,0,1},
                        { 1,0,1,0,1,0,1,0,0,0,1},
                        { 1,1,0,1,0,1,0,0,0,0,1},
                        { 1,0,1,0,1,0,0,0,0,0,1},
                        { 1,1,0,1,0,0,0,0,0,0,1},
                        { 1,1,1,1,1,1,1,1,1,1,1},
                    };
            }
        }

        static private int[,] Room2
        {
            get
            {
                return new int[19, 11]
                    {
                        { 1,1,1,1,1,1,1,1,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,1,1,1,1,1,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,1,1,1,1,1,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,1,1,1,1,1,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,1,1,1,1,1,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,1,1,1,1,1,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,1,1,1,1,1,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,1,1,1,1,1,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,1,1,1,1,1,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,1,1,1,1,1,1,1,1},
                    };
            }
        }

        static private int[,] Room3
        {
            get
            {
                return new int[19, 11]
                    {
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                        { 1,1,1,0,1,1,1,0,1,1,1},
                    };
            }
        }
    }
}
