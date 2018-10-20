﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GymArbete.Blocks;
using System;
using GymArbete.WorldLoading;

namespace GymArbete
{
    class Main
    {

        Player player;
        KeyboardState lastKey, key;
        public GameState gameState;

        public Main()
        {
            gameState = GameState.Floor;
            player = new Player(new Vector2(1, 1));
            /*
            map = new WorldMap(80, 40, 43);
            worldBlocks = new Dictionary<Vector2, Block>();
            Vector2 pos = new Vector2(0, 0);
            for (int x = 0; x < 80; ++x)
            {
                pos.X = x;
                for (int y = 0; y < 40; ++y)
                {
                    pos.Y = y;
                    worldBlocks[pos] = new Ground(pos, map.GetValue(pos / 10));
                }
            }
            */
            FloorSetup(9, 6, new Vector2());

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {



        }


        public void Update(GameTime gameTime)
        {

        }


        /*<summary>
        ##############################################
        EVERYTHING RELATED TO THE FLOORS STARTS HERE
        ##############################################
        </summary*/

        int floorNum;
        Dictionary<Vector2, Block> floor;
        Floors floors;
        //Setup for a floor
        private void FloorSetup(int seed, int height, Vector2 pos)
        {
            Floors floors = new Floors(seed, height, pos);
            floorNum = height;
            //Player always starts on the first floor
            floor = floors.GetFloor(3);
        }

        public void FloorUpdate(GameTime gameTime)
        {
            key = Keyboard.GetState();

            player.Update(gameTime);


            Keys[] pressed = key.GetPressedKeys();

            for (int i = 0; i != pressed.Length; ++i)
            {

                CheckAndMove(pressed[i]);
            }
            lastKey = Keyboard.GetState();
        }
        public void FloorDraw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (KeyValuePair<Vector2, Block> block in floor)
            {
                block.Value.Draw(spriteBatch);
            }
            player.FloorDraw(spriteBatch);
            spriteBatch.End();
        }

        /*<summary>
        ##############################################
        EVERYTHING RELATED TO THE WORLDMAP STARTS HERE
        ##############################################
        </summary*/
        Dictionary<Vector2, Block> worldBlocks;
        WorldMap map;


        public void WorldUpdate(GameTime gameTime)
        {
            key = Keyboard.GetState();

            player.Update(gameTime);


            Keys[] pressed = key.GetPressedKeys();

            for (int i = 0; i != pressed.Length; ++i)
            {

                CheckAndMove(pressed[i]);
            }
            lastKey = Keyboard.GetState();
        }

        public void WorldDraw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (KeyValuePair<Vector2, Block> block in worldBlocks)
            {
                block.Value.Draw(spriteBatch);
            }
            player.WorldDraw(spriteBatch);
            spriteBatch.DrawString(Textures.Font(), Convert.ToString(map.GetValue(player.GetWorldPosition() / 10)), new Vector2(25, 25), Color.White);
            spriteBatch.End();
        }



        /*<summary>
        ##############################################
        EVERYTHING RELATED TO MOVING THE PLAYER STARTS HERE
        ##############################################
        </summary*/

        private bool PlayerMoveable(Vector2 pos)
        {
            switch (gameState)
            {
                case GameState.WorldMap:
                    if (!worldBlocks.ContainsKey(pos))
                        return false;
                    if (worldBlocks[pos].Type() == BlockType.Staircase)
                        return true;
                    break;
                case GameState.Floor:
                    if (!floor.ContainsKey(pos))
                        return false;
                    if (floor[pos].Type() != BlockType.Wall)
                        return true;
                    break;

            }

            return false;
        }




        //Moves the player if it's allowed
        private void PlayerMove(Vector2 pos)
        {
            switch (gameState)
            {
                case GameState.WorldMap:
                    pos += player.GetWorldPosition();
                    if (PlayerMoveable(pos) && !player.hasMoved)
                    {
                        player.WorldMove(pos);
                    }
                    break;
                case GameState.Floor:
                    pos += player.GetFloorPosition();
                    if (PlayerMoveable(pos) && !player.hasMoved)
                    {
                        player.FloorMove(pos);
                    }
                    break;
            }

        }

        //Checking if any of the movement keys have been pressed moves if it has
        private void CheckAndMove(Keys key)
        {
            switch (key)
            {
                case Keys.NumPad1:
                    PlayerMove(new Vector2(-1, 1));
                    break;
                case Keys.NumPad2:
                    PlayerMove(new Vector2(0, 1));
                    break;
                case Keys.NumPad3:
                    PlayerMove(new Vector2(1, 1));
                    break;
                case Keys.NumPad4:
                    PlayerMove(new Vector2(-1, 0));
                    break;
                case Keys.NumPad7:
                    PlayerMove(new Vector2(-1, -1));
                    break;
                case Keys.NumPad8:
                    PlayerMove(new Vector2(0, -1));
                    break;
                case Keys.NumPad9:
                    PlayerMove(new Vector2(1, -1));
                    break;
                case Keys.NumPad6:
                    PlayerMove(new Vector2(1, 0));
                    break;
            }
        }
    }
}
