using Microsoft.Xna.Framework.Graphics;
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
        int seed;
        public Main(int tSeed = 25)
        {
            seed = tSeed;
            gameState = GameState.Floor;
            player = new Player(new Vector2(1, 1));
            map = new WorldMap(6400, 3200, seed);
            worldBlocks = new Dictionary<Vector2, Block>();
            Vector2 pos = new Vector2(0, 0);
            for (int x = 0; x < 640; ++x)
            {
                pos.X = x;
                for (int y = 0; y < 320; ++y)
                {
                    pos.Y = y;
                    worldBlocks[pos] = new Ground(pos, map.GetValue(pos / 10));
                }
            }
            FloorSetup(seed, 6, new Vector2());

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
            floors = new Floors(seed, height, pos);
            floorNum = 0;
            //Player always starts on the first floor
            floor = floors.GetFloor(floorNum);
            player.NewFloor();
        }


        //Moves the character up or down a floor depending on what button is pressed
        //The player must also stand on the right kind of staitile for this to work
        private void ChangeFloor(Orientation orientation)
        {
            if (!player.hasMoved)
            {
                if (orientation == Orientation.Up)
                {
                    if (floor.ContainsKey(player.GetFloorPosition()) && floor[player.GetFloorPosition()].Type() == BlockType.Up)
                    {
                        ++floorNum;
                        NewFloor();
                    }
                }
                else
                {
                    if (floor.ContainsKey(player.GetFloorPosition()) && floor[player.GetFloorPosition()].Type() == BlockType.Down)
                    {
                        --floorNum;
                        NewFloor(false);
                    }
                }
            }
        }

        
        private void NewFloor(bool atExit = true)
        {
            if (floorNum < 0)
            {
                gameState = GameState.WorldMap;
                return;
            }
            if (!player.hasMoved)
            {
                floor = floors.GetFloor(floorNum);
                if (atExit)
                {
                    player.NewFloor();
                }
                else
                {
                    foreach (KeyValuePair<Vector2, Block> block in floor)
                    {
                        if (block.Value.Type() == BlockType.Up)
                        {
                            player.NewFloor(block.Key.X, block.Key.Y);
                            break;
                        }
                    }
                }
                player.hasMoved = true;
            }
            
        }

        public void FloorUpdate(GameTime gameTime)
        {
            key = Keyboard.GetState();

            player.Update(gameTime);


            Keys[] pressed = key.GetPressedKeys();

            for (int i = 0; i != pressed.Length; ++i)
            {
                if (pressed[i] == Keys.Add)
                {
                    ChangeFloor(Orientation.Up);
                    break;
                }
                else if (pressed[i] == Keys.Subtract)
                {
                    ChangeFloor(Orientation.Down);
                    break;
                }
                CheckAndMove(pressed[i]);
            }
            lastKey = Keyboard.GetState();
        }
        public void FloorDraw(SpriteBatch spriteBatch, GraphicsDevice graphics,GameTime gameTime)
        {
            Vector2 temp = player.GetFloorPosition() * 16;
            temp.X *= -1;
            temp.Y *= -1;
            temp.Y += graphics.DisplayMode.Height/3;
            temp.X += graphics.DisplayMode.Width/3;

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, 
                Camera.GetMatrix(temp));
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
                if (pressed[i] == Keys.Add)
                {
                    FloorSetup(seed, worldBlocks[player.GetWorldPosition()].GetValue(), player.GetWorldPosition());
                    gameState = GameState.Floor;
                }
                CheckAndMove(pressed[i]);
            }
            lastKey = Keyboard.GetState();
        }

        public void WorldDraw(SpriteBatch spriteBatch, GraphicsDevice graphics, GameTime gameTime)
        {
            Vector2 temp = player.GetWorldPosition() * 16;
            temp.X *= -1;
            temp.Y *= -1;
            temp.Y += graphics.DisplayMode.Height / 3;
            temp.X += graphics.DisplayMode.Width / 3;

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null,
                Camera.GetMatrix(temp, true));
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
                   else
                        return true;
                case GameState.Floor:
                    if (!floor.ContainsKey(pos))
                        return true;
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
