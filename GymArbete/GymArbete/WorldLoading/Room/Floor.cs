using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GymArbete.WorldLoading
{
    class Floor
    {
        List<Room> floor;
        public Floor(int rooms, Random rng)
        {
            floor = CreateFloor(rooms, rng);
        }


        private List<Room> CreateFloor(int rooms, Random rng, bool lastFloor = false)
        {
            List<Room> floor = new List<Room>();
            List<Buffer> buffers = new List<Buffer>();

            floor.Add(new Room(new Vector2(0), rooms, rng));
            rooms -= floor[floor.Capacity - 1].doors;

            AddBuffer(buffers, floor[floor.Capacity - 1]);
            while (buffers.Capacity > 0)
            {
                floor.Add(new Room(buffers[0].offset, rooms, rng, buffers[0].enterence));

                AddBuffer(buffers, floor[floor.Capacity - 1]);
                buffers.RemoveAt(0);
                rooms -= floor[floor.Capacity - 1].doors;
            }

            if (!lastFloor)
            floor[floor.Capacity - 1].MakeExit();

            return floor;
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
