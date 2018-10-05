using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymArbete.WorldLoading
{
    class WorldMap
    {
        /*
        Perlin1D x;
        Perlin1D y;
        */

        private int sizeY, sizeX;
        Vector2[,] values;

        public WorldMap(int sX, int sY,int seed = 0)
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

            /*
            Randon rng = new Random(seed);

            x = new Perlin1D(sizeX, rng);
            y = new Perlin1D(sizeY, rng);
            */
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

            int left = Convert.ToInt32(pos.X);
            int up = Convert.ToInt32(pos.Y);

            float x = pos.X % 1;
            float y = pos.Y % 1;


            Vector2 v00 = values[left, up] * new Vector2(x, y);
            Vector2 v10 = values[left + 1, up] * new Vector2(1 - x, y);

            Vector2 v01 = values[left, 1 + up] * new Vector2(x, 1- y);
            Vector2 v11 = values[left + 1, 1+ up] * new Vector2(1 - x, 1 - y);

            float n0 = Mix(CalcFunction(v00), x) + Mix(CalcFunction(v10), 1 - x);

            return CalcFunction(v00);
            float n1 = Mix(CalcFunction(v01), x) + Mix(CalcFunction(v11), 1 - x);

            return Mix(n0, y) + Mix(n0, 1 - y);
        }

        private float CalcFunction(Vector2 value)
        {
            return value.X * value.Y;
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
            int value = rng.Next(-100, 100);
            return value / 100;
        }

        /*
        public float GetValue(Vector2 position)
        {
            if (position.X < 0 || x.Size() < position.X)
            {
                Environment.Exit(-102);
            }
            if (position.Y < 0 || y.Size() < position.Y)
            {
                Environment.Exit(-102);
            }

            float xAxis = x.Calculate(position.X);
            float yAxis = y.Calculate(position.Y);



            float toReturn = Mix(xAxis, )
            
        }

        private float Mix(float value, float distance)
        {
            // 6x^5 - 15x^4 + 10x^3 x = distance
            float toReturn = 6 * distance * distance * distance * distance * distance;
            toReturn -= 15 * distance * distance * distance * distance;
            toReturn += 10 * distance * distance * distance;
            return toReturn * value;
        }
        */
    }
}
