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
            floor  = CreateFloor(rooms, rng);
        }

        private List<Room> CreateFloor(int rooms)
        {
            List<Room> floor = new List<Room>();
            List<Vector2> buffer = new List<Vector2>();

            buffer.Add(new Vector2(0));
            while (buffer.Capacity > 0)
            {
                floor.Add(new Room(buffer[0], ));
            }
        }
    }
}
