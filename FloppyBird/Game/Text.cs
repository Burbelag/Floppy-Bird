using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird2.Game
{
    public class Text
    {
        private static SpriteFont _scoreFont;
        private GraphicsDevice _graphicsDevice;
        private Vector2 _position;
        
        private int Score { get; set; }
        private float _scoreScale;
        
        public Text(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _scoreFont = contentManager.Load<SpriteFont>("score");
            _position = new Vector2(0, 0);
            _graphicsDevice = graphicsDevice;
            _scoreScale = ScoreScale(graphicsDevice);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_scoreFont, "Score: " + Score, _position, Color.LightSkyBlue, 
                0.0f, Vector2.Zero, _scoreScale, SpriteEffects.None, 0.0f);
        }

        public void Update(Rectangle floppy, List<Rectangle> listDriver)
        {
            IncrementCounter(floppy, listDriver);
            _oneTime = false;
            Move();
        }

        private void Move()
        {
            _position.X += Helpers.DefaultXSpeed;
        }

        private Rectangle _tempRectangle;
        private bool _oneTime;

        private void IncrementCounter(Rectangle floppy, List<Rectangle> driverList)
        {
            foreach (Rectangle driver in driverList)
            {
                _tempRectangle = new Rectangle(driver.X + driver.Width, 0, (int) Helpers.WidthForCounter,
                    _graphicsDevice.Viewport.Bounds.Height);

                if (Helpers.Collision(new Rectangle(floppy.X, floppy.Y, (int) Helpers.WidthForCounter,
                    floppy.Height), _tempRectangle) && !_oneTime)
                {
                    ++Score;
                    _oneTime = true;
                }
            }
        }

        private float ScoreScale(GraphicsDevice graphicsDevice)
        {
            const Helpers.ScaleObject scale = Helpers.ScaleObject.ScoreText;
            return _scoreScale = Helpers.Scale(graphicsDevice, _scoreFont, scale);
        }
    }
}