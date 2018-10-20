using Microsoft.Xna.Framework;
using System;
using GymArbete.Blocks;
using System.Collections.Generic;

namespace GymArbete.WorldLoading
{
    class Floors
    {
        Floor[] floors;


        public Floors(int seed, int height, Vector2 pos)
        {
            //The random that's going to be used for all of the floors
            Random rng = new Random((int)(seed * pos.X + height * pos.Y));

            floors = new Floor[height];
            int roomAmount = 10;

            for (int i = 0; i < floors.Length -1 ; ++i)
            {
                roomAmount = RoomAmount(roomAmount, rng);
                floors[i] = new Floor(roomAmount, rng);
            }

            roomAmount = RoomAmount(roomAmount, rng);
            floors[floors.Length - 1] = new Floor(roomAmount, rng, true);
        }

        public int Lenght()
        {
            return floors.Length;
        }

        //Returns the floor converted to a block multiarray for ease of use. The floors start at 0
        public Dictionary<Vector2, Block> GetFloor(int i)
        {
            if (i < 0 || i >= Lenght())
            {
                return ErrorRoom();
            }
            return floors[i].GetFloor();
        }

        //Gets the number of floors that are going to be in the next room
        private int RoomAmount(int last, Random rng)
        {
            int min, max;
            if (last <= 5)
            {
                min = 2;
            }
            else
            {
                min = last - 3;
            }
            if (last <= 3)
            {
                max = 5;
            }
            else
            {
                max = last + 3;
            }

            return rng.Next(min, max + 1);
        }

        private Dictionary<Vector2, Block> ErrorRoom()
        {
            Dictionary<Vector2, Block> dic = new Dictionary<Vector2, Block>();

            Vector2 vec = new Vector2(0);
            dic[vec] = new Staircase(vec, true);
            return dic;
        }
    }
}
