using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymArbete.WorldLoading
{
    class Perlin1D
    {
        float[] values;
        public Perlin1D(int size, Random rng)
        {
            values = new float[size];

            for (int i = 0; i < size; ++i)
            {
                int curr = rng.Next(-100, 100);
                values[i] = curr / 100;
            }
        }

        public float Calculate(int pos)
        {
            float position = pos / 10;

            if (pos < 0 || pos > values.Length - 1)
            {
                Environment.Exit(-100);
            }

            int left = Convert.ToInt32(position);
            int right = left + 1;
        }
    }
}
