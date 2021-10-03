using FloppyBird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace FloppyBird2.Game
{
    public class Playground
    {
        /* sprites */
        private Floppy _floppy;
        private Background _background;
        private Driver _driver;
        private Text _text;
        private GraphicsDevice _graphicsDevice;

        public void LoadContent(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _background = new Background(contentManager, graphicsDevice);
            _floppy = new Floppy(contentManager, graphicsDevice);
            _driver = new Driver(contentManager, graphicsDevice);
            _text = new Text(contentManager, graphicsDevice);
            _graphicsDevice = graphicsDevice;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _driver.Draw(spriteBatch);
            _floppy.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            _floppy.Update(gameTime);
            _text.Update(gameTime);
            
            _driver.DriverCollision(_floppy.FloppyRectangle);
            _driver.PipeGeneration(_graphicsDevice, _floppy.FloppyRectangle);
            _driver.DeleteDriver(_floppy.FloppyRectangle);
        }
    }
}