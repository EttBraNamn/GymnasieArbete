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


        public static Matrix GetMatrix(Vector2 pos, bool zoom = false)
        {
            if (!zoom)
            {
                return Matrix.CreateTranslation(pos.X - 16, pos.Y - 16, 0);
            }
            else
            {
                return Matrix.CreateTranslation( pos.X + (0.9f * 16), pos.Y + (0.9f * 16), 0) * Matrix.CreateScale(0.9f,0.9f,1f);
            }

            
        }
    }
}
