using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymArbete
{
    static class Camera
    {


        public static Matrix GetMatrix(Vector2 pos)
        {
            Matrix toReturn = Matrix.CreateTranslation(pos.X - 16, pos.Y - 16, 0);
            return toReturn;
        }
    }
}
