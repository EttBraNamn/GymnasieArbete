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

        public Main()
        {
            gameState = GameState.WorldMap;
            map = new WorldMap(1600, 900, 1789);
            player = new Player(new Vector2(1, 1));
            worldBlocks = new Dictionary<Vector2, Block>();
            Vector2 pos = new Vector2(0, 0);
            for (int x = 0; x < 1600; ++x)
            {
                pos.X = x;
                for (int y = 0; y < 900; ++y)
                {
                    pos.Y = y;
                    worldBlocks[pos] = new Floor(pos, map.GetValue(pos / 10));
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {



        }


        public void Update(GameTime gameTime)
        {
            
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

                CheckMovement(pressed[i]);
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
            spriteBatch.DrawString(Textures.Font(), Convert.ToString(map.GetValue(player.GetWorldPosition() / 100)), new Vector2(25, 25), Color.White);
            spriteBatch.End();
        }

        
        private bool WorldPlayerMoveable(Vector2 position)
        {
           
            if (!worldBlocks.ContainsKey(position))
                return false;

            if (worldBlocks[position].Type() == BlockType.Floor)
                return true;

            return false;
        }




        //Moves the player if it's allowed
        private void PlayerMove(Vector2 position)
        {
            switch (gameState)
            {
                case GameState.WorldMap:
                    position += player.GetWorldPosition();
                    if (WorldPlayerMoveable(position) && !player.hasMoved)
                    {
                        player.WorldMove(position);
                    }
                    break;
            
        }
            
        }

        //Checking if any of the movement keys have been pressed
        private void CheckMovement(Keys key)
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
