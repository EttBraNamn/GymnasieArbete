using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GymArbete
{
    class Player
    {

        Vector2 position;
        public bool hasMoved;
        int moveTimer;
        public Player(Vector2 pos)
        {
            position = pos;
            moveTimer = 0;
        }
        public Vector2 GetPosition()
        {
            return position;
        }
        private Vector2 Position()
        {
            return position * 16;
        }

        public void Move(Vector2 pos)
        {
            position = pos;
            hasMoved = true;
        }

        public void Update(GameTime gameTime)
        {
            if (hasMoved)
            {
                if (moveTimer < 0)
                {
                    hasMoved = false;
                    moveTimer = 250;
                }
                else
                    moveTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }
            
        }

    }
}
