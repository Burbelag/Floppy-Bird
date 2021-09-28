using System.Collections.Generic;
using FloppyBird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Floppy_Bird.Game
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager _graphicsDeviceManager;
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;
        private Vector3 _gameCamera;
        private Playground _playground;
        
        public Game1()
        {
            IsMouseVisible = false;
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            _playground = new Playground(Content, GraphicsDevice);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _playground.LoadContent(Content, _graphicsDeviceManager);
        }

        protected override void Update(GameTime gameTime)
        {
            _playground.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp);

            _playground.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}