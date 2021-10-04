using FloppyBird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird2.Game
{
    public class Playground
    {
        /* sprites */
        private Floppy _floppy;
        private Driver _driver;
        private Text _text;

        public void LoadContent(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _floppy = new Floppy(contentManager, graphicsDevice);
            _driver = new Driver(contentManager, graphicsDevice);
            _text = new Text(contentManager, graphicsDevice);
        }

        public void Update(GameTime gameTime)
        {
            _floppy.Update(gameTime);
            _driver.Update(gameTime, _floppy.FloppyRectangle);
            _text.Update(_floppy.FloppyRectangle, _driver.ListUpperDriver);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _driver.Draw(spriteBatch);
            _floppy.Draw(spriteBatch);
            _text.Draw(spriteBatch);
        }
    }
}