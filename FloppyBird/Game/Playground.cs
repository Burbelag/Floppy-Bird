using FloppyBird.Game;
using FloppyBird2.Game.SFX;
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

        private Sound _sound;

        public void LoadContent(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _floppy = new Floppy(contentManager, graphicsDevice);
            _driver = new Driver(contentManager, graphicsDevice);
            _text = new Text(contentManager, graphicsDevice);
            _sound = new Sound(contentManager);
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