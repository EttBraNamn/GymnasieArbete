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
           // floor  = CreateFloor(rooms, rng);
        }
        /*
        private List<Room> CreateFloor(int rooms, Random rng)
        {
            List<Room> floor = new List<Room>();
            List<Buffer> buffers = new List<Buffer>();

            floor.Add(new Room(new Vector2(0), rooms, rng));
            rooms -= floor[floor.Capacity - 1].doors;

            buffers.Add();
            while (buffers.Capacity > 0)
            {
                floor.Add(new Room(buffers[0].offset, rooms, rng, ));
            }
        }
        */
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
