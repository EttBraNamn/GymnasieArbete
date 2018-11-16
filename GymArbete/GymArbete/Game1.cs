using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GymArbete
{


    public enum GameState { WorldMap, Floor}
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Main main;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 640;
            graphics.PreferredBackBufferWidth = 1280;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            main = new Main();

            base.Initialize();
        }

  
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Textures.Init(Content);

        }

   
        protected override void UnloadContent()
        {
   
        }

     
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            switch (main.gameState)
            {
                case GameState.WorldMap:
                    main.WorldUpdate(gameTime);
                    break;
                case GameState.Floor:
                    main.FloorUpdate(gameTime);
                    break;
            }
            main.Update(gameTime);
            
            base.Update(gameTime);
        }

   
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            switch (main.gameState)
            {
                case GameState.WorldMap:
                    main.WorldDraw(spriteBatch,GraphicsDevice,  gameTime);
                    break;
                case GameState.Floor:
                    main.FloorDraw(spriteBatch, GraphicsDevice ,gameTime);
                    break;
            }

            
            base.Draw(gameTime);
        }
    }
}
