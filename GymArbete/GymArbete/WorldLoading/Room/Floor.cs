using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using GymArbete.Blocks;

namespace GymArbete.WorldLoading
{
    class Floor
    {
        List<Room> floor;
        public Floor(int rooms, Random rng, bool lastFloor = false)
        {
            floor = CreateFloor(rooms, rng, lastFloor);
        }


        private List<Room> CreateFloor(int rooms, Random rng, bool lastFloor)
        {
            List<Room> floor = new List<Room>();
            List<Buffer> buffers = new List<Buffer>();

            floor.Add(new Room(new Vector2(0), rooms, rng));
            rooms -= floor[floor.Count - 1].doors;

            AddBuffer(buffers, floor[floor.Count - 1]);
            while (buffers.Count > 0)
            {
                floor.Add(new Room(buffers[0].offset, rooms, rng, buffers[0].enterence));

                AddBuffer(buffers, floor[floor.Count - 1]);
                buffers.RemoveAt(0);
                rooms -= floor[floor.Count - 1].doors;
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
                        curr.Y = y + of.X;
                        dic[curr] = blocks[x, y];
                    }
                }
            }
            return dic;
        }

        //Adds all of the new rooms to the buffer
        private void AddBuffer(List<Buffer> buffers, Room room)
        {
            for (int i = 0; i < room.orientations.Length; ++i)
            {
                switch (room.orientations[i])
                {
                    case Orientation.Down:
                        buffers.Add(new Buffer(new Vector2(room.offset.X, room.offset.Y + 1), Orientation.Up));
                        break;
                    case Orientation.Left:
                        buffers.Add(new Buffer(new Vector2(room.offset.X - 1, room.offset.Y), Orientation.Right));
                        break;
                    case Orientation.Right:
                        buffers.Add(new Buffer(new Vector2(room.offset.X + 1, room.offset.Y), Orientation.Left));
                        break;
                    case Orientation.Up:
                        buffers.Add(new Buffer(new Vector2(room.offset.X, room.offset.Y - 1), Orientation.Up));
                        break;

                }
            }
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
