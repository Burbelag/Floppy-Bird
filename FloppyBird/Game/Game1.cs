using FloppyBird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FloppyBird2.Game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private ContentManager _contentManager;
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private readonly Playground _playground;
        private Background _background;
        private readonly Floppy _floppy;

        private Vector3 _gameCamera;
        private float _cameraPos;

        public bool Menu = true;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1366;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _playground = new Playground();
            _floppy = new Floppy(Content, GraphicsDevice);
        }

        protected override void LoadContent()
        {
            _playground.LoadContent(Content, GraphicsDevice);
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _background = new Background(Content, GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Menu)
            {
                KeyboardState state = Keyboard.GetState();

                if (state.IsKeyDown(Keys.Space)) Menu = false;
            }
            else
            {
                _gameCamera = new Vector3(_cameraPos -= Helpers.DefaultXSpeed, 0, 0.0f);

                _playground.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (Menu)
            {
                _spriteBatch.Begin();

                _background.Draw(_spriteBatch);
                _floppy.Draw(_spriteBatch);

                _spriteBatch.End();
            }
            else
            {
                GraphicsDevice.Clear(Color.White);

                /* background */
                _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);

                _background.Draw(_spriteBatch);

                _spriteBatch.End();

                /* game itself */
                _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null,
                    null, Matrix.CreateTranslation(_gameCamera));

                _playground.Draw(_spriteBatch);

                _spriteBatch.End();

                base.Draw(gameTime);
            }
        }
    }
}