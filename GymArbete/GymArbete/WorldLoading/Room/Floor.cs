using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using GymArbete.Blocks;

namespace GymArbete.WorldLoading
{
    class Floor
    {
        List<Room> floor;
        private int rooms;
        public Floor(int rooms, Random rng, bool lastFloor = false)
        {
            floor = CreateFloor(rooms, rng, lastFloor);
        }


        private List<Room> CreateFloor(int amountRooms, Random rng, bool lastFloor)
        {
            rooms = 1000;
            List<Room> floor = new List<Room>();
            List<Buffer> buffers = new List<Buffer>();
            List<Buffer> illegalBuffers = new List<Buffer>();
            illegalBuffers.Add(new Buffer(new Vector2(0, 0), Orientation.None));
            floor.Add(new Room(new Vector2(0), rooms, rng));

            AddBuffer(buffers, illegalBuffers,floor[floor.Count - 1]);
            while (rooms > 0)
            {
                while (buffers.Count > 0)
                {
                    floor.Add(new Room(buffers[0].offset, rooms, rng, buffers[0].enterence));

                    AddBuffer(buffers, illegalBuffers, floor[floor.Count - 1]);
                    buffers.RemoveAt(0);
                }
                
                if (rooms > 0)
                {
                    int i = rng.Next(0, floor.Count);
                    while (floor[i].AddDoor(rng) == false)
                    {
                        i = rng.Next(0, floor.Count);
                    }
                    AddBuffer(buffers, illegalBuffers,floor[i]);
                }
            }
            

            if (!lastFloor)
            floor[floor.Count - 1].MakeExit();

            return floor;
        }

        public Dictionary<Vector2, Block> GetFloor()
        {
            Dictionary<Vector2, Block> dic = new Dictionary<Vector2, Block>();
            List<Vector2> offsets = new List<Vector2>();
            foreach(Room room in floor)
             {
                offsets.Add(room.offset);
                Vector2 of = new Vector2(21, 13) * room.offset;
                Block[,] blocks = room.GetBlocks();
                Vector2 curr = new Vector2(0);
                for (int x = 0; x < 21; ++x)
                {
                    curr.X = x + of.X;
                    for (int y = 0; y < 13; ++y)
                    {
                        curr.Y = y + of.Y;
                        blocks[x, y].position.Y = curr.Y;
                        blocks[x, y].position.X = curr.X;

                        dic[curr] = blocks[x,y];
                    }
                }
            }

            foreach(Vector2 vec in offsets)
            {
                Vector2 compare = vec;

                --compare.Y;
                if (offsets.Contains(compare))
                {
                    AddDoor(dic, vec, Orientation.Up);
                }
                compare.Y += 2;
                if (offsets.Contains(compare))
                {
                    AddDoor(dic, vec, Orientation.Down);
                }
                --compare.Y;
                --compare.X;
                if (offsets.Contains(compare))
                {
                    AddDoor(dic, vec, Orientation.Left);
                }
                compare.X += 2;
                if (offsets.Contains(compare))
                {
                    AddDoor(dic, vec, Orientation.Right);
                }
            }

            return dic;
        }

        private static Dictionary<Vector2, Block> AddDoor(Dictionary<Vector2, Block> dic, Vector2 offset, Orientation orientation)
        {
            Vector2 curr = (new Vector2(21, 13)) * offset;
            switch (orientation)
            {
                case Orientation.Left:
                    curr.Y += 6;
                    dic[curr] = new Ground(new Vector2(curr.X, curr.Y));
                    break;
                case Orientation.Up:
                    curr.X += 10;
                    dic[curr] = new Ground(new Vector2(curr.X, curr.Y));
                    break;
                case Orientation.Down:
                    curr.Y += 12;
                    curr.X += 10;
                    dic[curr] = new Ground(new Vector2(curr.X, curr.Y));
                    break;
                case Orientation.Right:
                    curr.X += 20;
                    curr.Y += 6;
                    dic[curr] = new Ground(new Vector2(curr.X, curr.Y));
                    break;
            }
            return dic;
        }

        //Adds all of the new rooms to the buffer
        private void AddBuffer(List<Buffer> buffers, List<Buffer> illegal, Room room)
        {
            for (int i = 0; i < room.orientations.Length; ++i)
            {
                Buffer buf;
                switch (room.orientations[i])
                {
                    case Orientation.Down:
                        buf = new Buffer(new Vector2(room.offset.X, room.offset.Y + 1), Orientation.Up);
                        if (Allowed(illegal, buf))
                        {
                            illegal.Add(buf);
                            buffers.Add(buf);
                            --rooms;
                        }
                        break;
                    case Orientation.Left:
                        buf = new Buffer(new Vector2(room.offset.X - 1, room.offset.Y), Orientation.Right);
                        if (Allowed(illegal, buf))
                        {
                            --rooms;
                            illegal.Add(buf);
                            buffers.Add(buf);
                        }
                        break;
                    case Orientation.Right:
                        buf = new Buffer(new Vector2(room.offset.X + 1, room.offset.Y), Orientation.Left);
                        if (Allowed(illegal, buf))
                        {
                            --rooms;
                            illegal.Add(buf);
                            buffers.Add(buf);
                        }
                        break;
                    case Orientation.Up:
                        buf = new Buffer(new Vector2(room.offset.X, room.offset.Y - 1), Orientation.Down);
                        if (Allowed(illegal, buf))
                        {
                            --rooms;
                            illegal.Add(buf);
                            buffers.Add(buf);
                        }
                        break;
                }


            }
        }


        private bool Allowed(List<Buffer> illegal, Buffer buf)
        {
            foreach (Buffer illBuf in illegal)
            {
                if (illBuf.offset == buf.offset)

                    return false;
            }
            return true;
        }
    }
    public class Buffer
    {
        public Vector2 offset;
        public Orientation enterence;

        public Buffer(Vector2 of, Orientation ent)
        {
            offset = of;
            enterence = ent;
        }
    }
}
