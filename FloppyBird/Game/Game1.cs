using Floppy_Bird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FloppyBird.Game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private ContentManager _contentManager;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly Playground _playground;

        private Vector3 _gameCamera;
        private float _cameraPos;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _playground = new Playground();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _playground.LoadContent(Content, GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            /* EXIT THE GAME */
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _gameCamera = new Vector3(_cameraPos -= Helpers.DefaultXSpeed, 0, 0.0f);

            _playground.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            
            
            _spriteBatch.Draw(Background.BackgroundTexture, Vector2.Zero, null, Color.White, 0.0f,
                Vector2.Zero, Background.BackgroundScale, SpriteEffects.None, 0.0f);
            
            _spriteBatch.End();

            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp,
                null, null, null, Matrix.CreateTranslation(_gameCamera));

            _playground.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}