using System;
using System.Linq;
using Floppy_Bird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird.Game
{
    public class Playground
    {
        /* sprites */
        private Floppy _floppy;
        private Background _background;
        private Driver _driver;

        public void LoadContent(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _background = new Background(contentManager, graphicsDevice);
            _floppy = new Floppy(contentManager, graphicsDevice);
            _driver = new Driver(contentManager, graphicsDevice);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _driver.Draw(spriteBatch);
            _floppy.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            _floppy.Update(gameTime);
            _driver.Update(gameTime);
            _driver.DriverCollision(_floppy.FloppyRectangle);
        }
    }
}