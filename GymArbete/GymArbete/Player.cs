﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GymArbete
{
    class Player
    {

        Vector2 worldPosition;
        Vector2 floorPosition;
        public bool hasMoved;
        int moveTimer;
        public Player(Vector2 pos)
        {
            worldPosition = pos;
            moveTimer = 0;
            hasMoved = false;
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

        private Vector2 Position(Vector2 pos)
        {
            return pos * 16;
        }

        /*<summary>
       ##############################################
       EVERYTHING RELATED TO THE FLOORS STARTS HERE
       ##############################################
       </summary*/


        public void NewFloor(float x = 10, float y = 6)
        {
            floorPosition.X = x;
            floorPosition.Y = y;
        }

        public Vector2 GetFloorPosition()
        {
            return floorPosition;
        }

        public void FloorMove(Vector2 pos)
        {
            floorPosition = pos;
            hasMoved = true;
        }

        public void FloorDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Textures.Player(), Position(floorPosition), Color.White);
        }

        /*<summary>
        ##############################################
        EVERYTHING RELATED TO THE WORLD STARTS HERE
        ##############################################
        </summary*/

        public void WorldMove(Vector2 pos)
        {
            worldPosition = pos;
            hasMoved = true;
        }

        public Vector2 GetWorldPosition()
        {
            return worldPosition;
        }

        public void WorldDraw(SpriteBatch spriteBatch)
        {
            Texture2D texture = Textures.Player();
            spriteBatch.Draw(texture, Position(worldPosition), Color.White);
        }

       

    }
}
