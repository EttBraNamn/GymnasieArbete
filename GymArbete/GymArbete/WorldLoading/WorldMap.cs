using Microsoft.Xna.Framework;
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

            int xLength = 1 + sizeX / 10;
            int yLength = 1 + sizeY / 10;

            values = new Vector2[xLength,yLength];

            for (int x = 0; x < xLength; ++x)
            {
                for (int y = 0; y < yLength; ++y)
                {
                    values[x, y] = new Vector2(RandValue(rng), RandValue(rng));
                }
            }
        }

        public float GetValue(Vector2 pos)
        {
           
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


            Vector2 v00 = values[left, up] * new Vector2(1 - x, 1 - y);
            Vector2 v10 = values[left + 1, up] * new Vector2(x, 1 - y);

            Vector2 v01 = values[left, 1 + up] * new Vector2(1 - x, y);
            Vector2 v11 = values[left + 1, 1+ up] * new Vector2(x, y);

            float n0 = Mix(CalcFunction(v00),1 - x) + Mix(CalcFunction(v10), x);

            float n1 = Mix(CalcFunction(v01),1 - x) + Mix(CalcFunction(v11), x);

            return (Mix(n0, 1 - y) + Mix(n1, y));
        }

        private float CalcFunction(Vector2 value)
        {
            return  value.X *value.Y;
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
            float value = rng.Next(-100, 101);
            return value / 100;
        }

    }
}
