using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GymArbete.Blocks;

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

            Vector2 temp = new Vector2(1, 1);

            blocks[temp] = new Floor(temp);


            ++temp.X;

            blocks[temp] = new Wall(temp);
        }

        public void Update(GameTime gameTime)
        {
            key = Keyboard.GetState();

            player.Update(gameTime);

            if (key == lastKey)
            {
                return;
            }

            Keys[] pressed = key.GetPressedKeys();

            for (int i = 0; i != pressed.Length; ++i)
            {
                switch (pressed[i])
                {
                    case Keys.NumPad1 :
                        PlayerMove(new Vector2(-1, 1));
                        break;
                    case Keys.NumPad2:
                        PlayerMove(new Vector2(0, 1));
                        break;
                    case Keys.NumPad3:
                        PlayerMove(new Vector2(1, 1));
                        break;

                }
               

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

        private void PlayerMove(Vector2 position)
        {
            position += player.GetPosition();
            if (PlayerMoveable(position) && !player.hasMoved)
            {
                player.Move(position);
            }
        }
       
    }
}
