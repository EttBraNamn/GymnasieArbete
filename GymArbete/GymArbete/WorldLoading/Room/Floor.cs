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
            rooms = 30;
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
                break;
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

            foreach(Room room in floor)
             {
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
                        else
                        {
                            room.orientations[i] = Orientation.None;
                            ++rooms;
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
                        else
                        {
                            room.orientations[i] = Orientation.None;
                            ++rooms;
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
                        else
                        {
                            room.orientations[i] = Orientation.None;
                            ++rooms;
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
                        else
                        {
                            room.orientations[i] = Orientation.None;
                            ++rooms;
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
