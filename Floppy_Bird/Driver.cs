using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Floppy_Bird
{
    public class Driver
    {
        private Texture2D _driver;

        private float _driverScale;
        private readonly List<Vector2> _listUpperDriver = new();

        private readonly List<Vector2> _listDownDriver = new();


        public Driver(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            Scales.ScaleObject scale = Scales.ScaleObject.Driver;
            _driver = contentManager.Load<Texture2D>("floppy_driver");
            _driverScale = Scales.Scale(graphicsDevice, _driver, scale);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Vector2 drawPipes in _listUpperDriver)
            {
                spriteBatch.Draw(_driver, new Rectangle((int) drawPipes.X, (int) drawPipes.Y,
                        (int) (_driver.Width * _driverScale),
                        (int) (_driver.Height * _driverScale)),
                    Color.White);
            }

            foreach (Vector2 drawPipes in _listDownDriver)
            {
                spriteBatch.Draw(_driver, new Rectangle((int) drawPipes.X, (int) drawPipes.Y,
                        (int) (_driver.Width * _driverScale),
                        (int) (_driver.Height * _driverScale)),
                    Color.White);
            }
        }
    }
}