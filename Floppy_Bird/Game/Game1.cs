using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Floppy_Bird.Game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager _graphicsDeviceManager;
        private SpriteBatch _spriteBatch;
        private Vector3 _gameCamera;
        
        public Game1()
        {
            IsMouseVisible = false;
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            
            _stateChanger.Draw(_spriteBatch);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp);


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}