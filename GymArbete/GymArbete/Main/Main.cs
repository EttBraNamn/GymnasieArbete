using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GymArbete.Blocks;
using System;

namespace GymArbete
{
    class Main
    {

        Dictionary<Vector2, Block> blocks;
        Player player;
        KeyboardState lastKey, key;

        public Main()
        {
            player = new Player(new Vector2(1, 1));
            blocks = new Dictionary<Vector2, Block>();
            Vector2 pos = new Vector2(0, 0);
            for (int x = 0; x < 20; )
            {
                pos.X = ++x;
                for (int y = 0; y < 12;)
                {
                    pos.Y = ++y;
                    blocks[pos] = new Floor(pos);
                }
            }

        }

        public void Update(GameTime gameTime)
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

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {


            spriteBatch.Begin();
            foreach(KeyValuePair<Vector2, Block> block in blocks)
            {
                block.Value.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
            spriteBatch.End();
        }

        private bool PlayerMoveable(Vector2 position)
        {
           
            if (!blocks.ContainsKey(position))
                return false;

            if (blocks[position].Type() == BlockType.Floor)
                return true;

            return false;
        }




        //Moves the player if it's allowed
        private void PlayerMove(Vector2 position)
        {
            position += player.GetPosition();
            if (PlayerMoveable(position) && !player.hasMoved)
            {
                player.Move(position);
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
