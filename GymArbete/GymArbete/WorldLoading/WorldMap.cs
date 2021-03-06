﻿using Microsoft.Xna.Framework;
using System;

namespace GymArbete.WorldLoading
{
    class WorldMap
    {
     
        private int sizeY, sizeX;
        Vector2[,] values;
        public WorldMap(int sX, int sY,int seed = 4)
        {
            sizeX = sX;                                  
            sizeY = sY;

            if (sizeX % 10 != 0)
            {
                Environment.Exit(-101);
            }
            if (sizeY % 10 != 0)
            {
                Environment.Exit(-101);
            }
            if (sizeX < 0 || sizeY < 0)
            {
                Environment.Exit(-101);
            }

            Random rng = new Random(seed);

            sizeX = 1 + sizeX / 20;
            sizeY = 1 + sizeY / 20;

            values = new Vector2[sizeX,sizeY];
            Vector2 vec = new Vector2();
            for (int x = sizeX - 1; x > -1; --x)
            {
                for (int y = sizeY - 1; y > -1; --y)
                {
                    vec.X = RandValue(rng);
                    vec.Y = RandValue(rng);
                    values[x, y] = vec;
                }
            }
        }

        public float GetValue(Vector2 pos)
        {
            float toReturn =  Value(pos, 8);
            toReturn += Value(pos, 4);
            toReturn += Value(pos, 2);
            toReturn += Value(pos, 1);
            toReturn += Value(pos, 16);


            return toReturn;
        }

        private float Value(Vector2 pos, float divider = 1)
        {
            pos *= divider;

            pos.X %= sizeX- 1;
            pos.Y %= sizeY - 1;

            if (pos.X < 0 || sizeX < pos.X)
            {
                Environment.Exit(-102);
            }
            if (pos.Y < 0 || sizeY < pos.Y)
            {
                Environment.Exit(-102);
            }

            int left = (int)pos.X;
            int up = (int)pos.Y;

            float x = pos.X - left;
            float y = pos.Y - up;
            Vector2 v00 = values[left, up];
            Vector2 v10 = values[left + 1, up];

            Vector2 v01 = values[left, up + 1];
            Vector2 v11 = values[left + 1, up + 1];



            /*
            float n0 = Mix(DotProduct(v00, pos - v00), 1 - x) + Mix(DotProduct(v10, pos - v10), x);

            float n1 = Mix(DotProduct(v01, pos - v01), 1 - x) + Mix(DotProduct(v11, pos - v11), x);
            */
            
            float n0 = Mix(DotProduct(v00, new Vector2(x, y)), 1 - x) + Mix(DotProduct(v10, new Vector2(x - 1, y)), x);

            float n1 = Mix(DotProduct(v01, new Vector2(x,  y - 1)), 1 - x) + Mix(DotProduct(v11, new Vector2(x - 1, y - 1)), x);
            
            return (Mix(n0, 1 - y) + Mix(n1, y)) / divider;
        }

        private float DotProduct(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.X + v2.Y * v1.Y;
        }

        private float Mix(float value, float distance)
        {
            // 6x^5 - 15x^4 + 10x^3 x = distance
            float toReturn = 6 * distance * distance * distance * distance * distance;
            toReturn -= 15 * distance * distance * distance * distance;
            toReturn += 10 * distance * distance * distance;
            return toReturn * value;
        }

        private float RandValue(Random rng)
        {
            float value = rng.Next(-100, 100);
            return value/100;
        }

    }
}
