using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZeEngine;

namespace Frogger
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;
        Camera2d camera;
        SpriteFont spriteFont;

        public Level level;

        Texture2D pixel;
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            graphics.PreferredBackBufferWidth = Globals.screenWidth;
            graphics.PreferredBackBufferHeight = Globals.screenHeight;

            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);


            Globals.keyboard = new McKeyboard();
            Globals.mouse = new McMouseControl();

            level = new Level();
            camera = new Camera2d();
            spriteFont = Globals.content.Load<SpriteFont>("Arial16");

            pixel = new Texture2D(GraphicsDevice, 1, 1);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.gameTime = gameTime;
            Globals.keyboard.Update();
            Globals.mouse.Update();

            level.Update(Vector2.Zero);
            camera.Follow(level.frog.pos);

            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();
            base.Update(gameTime);
        }
            
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(transformMatrix: camera.transform);

            level.Draw(pixel);
        
            Globals.spriteBatch.End();

            Globals.spriteBatch.Begin();
            Globals.spriteBatch.DrawString(spriteFont, level.frog.currentTile.ToString(), new Vector2(50, 50), Color.White);
            Globals.spriteBatch.DrawString(spriteFont, level.frog.nextTile.ToString(), new Vector2(50, 70), Color.White);
            Globals.spriteBatch.DrawString(spriteFont, level.frog.onLog.ToString(), new Vector2(50, 90), Color.White);
            Globals.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            using(var game = new Main())
                game.Run();
        }
    }
}
