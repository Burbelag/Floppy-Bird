using FloppyBird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FloppyBird2.Game
{
    public class Playground
    {
        /* sprites */
        private Floppy _floppy;
        private Driver _driver;
        private Text _text;
        private Texture2D _line;

        private Rectangle _rectangle;
        private bool _oneTime = false;

        public void LoadContent(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _floppy = new Floppy(contentManager, graphicsDevice);
            _driver = new Driver(contentManager, graphicsDevice);
            _text = new Text(contentManager, graphicsDevice);
            _line = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            int[] pixel = {169};
            _line.SetData<int>(pixel, 0, _line.Width * _line.Height);
            _rectangle = new Rectangle(1000, 0, 1, 1280);
        }

        public void Update(GameTime gameTime)
        {
            _floppy.Update(gameTime);
            _driver.Update(gameTime, _floppy.FloppyRectangle);
            _text.Update(_floppy.FloppyRectangle, _driver._listUpperDriver);

            if(Helpers.Collision(new Rectangle((int)_floppy.Position.X, (int)_floppy.Position.Y, _floppy.FloppyRectangle.Width, 
                _floppy.FloppyRectangle.Height), _rectangle) && !_oneTime)
            {
                ++_text.Score;
                _oneTime = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _driver.Draw(spriteBatch);
            _floppy.Draw(spriteBatch);
            _text.Draw(spriteBatch);

            spriteBatch.Draw(_line, _rectangle, Color.Red);
        }
    }
}