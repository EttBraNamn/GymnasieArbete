using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GymArbete
{
    class Player
    {

        Vector2 worldPosition;
        public bool hasMoved;
        int moveTimer;
        public Player(Vector2 pos)
        {
            worldPosition = pos;
            moveTimer = 0;
            hasMoved = false;
        }

        public Vector2 GetWorldPosition()
        {
            return worldPosition;
        }

        private Vector2 Position()
        {
            return worldPosition * 16;
        }

        public void WorldMove(Vector2 pos)
        {
            worldPosition = pos;
            hasMoved = true;
        }

        public void WorldDraw(SpriteBatch spriteBatch)
        {
            Texture2D texture = Textures.Player();
            spriteBatch.Draw(texture, Position(), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //Responsible for keeping track of the movement
            if (hasMoved)
            {
                if (moveTimer < 0)
                {
                    hasMoved = false;
                    moveTimer = 100;
                }
                else
                    moveTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }

        }

    }
}
