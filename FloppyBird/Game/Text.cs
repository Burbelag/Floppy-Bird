using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird2.Game
{
    public class Text
    {
        private static SpriteFont _scoreFont;
        private Vector2 _position;
        public int Score { get; set; }

        public Text(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _scoreFont = contentManager.Load<SpriteFont>("score");
            _position = new Vector2(0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_scoreFont, "score: " + Score, _position, Color.White);
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

        public void SetText(SpriteBatch spriteBatch, string text)
        {
            spriteBatch.DrawString(_scoreFont, text, _position, Color.Yellow);
        }

        private Rectangle _tempRectangle;
        private bool _oneTime;

        private void IncrementCounter(Rectangle floppy, List<Rectangle> driverList)
        {
            foreach (Rectangle driver in driverList)
            {
                _tempRectangle = new Rectangle(driver.X + driver.Width, 0, (int) Helpers.WidthForCounter, 10000);

                if (Helpers.Collision(new Rectangle(floppy.X, floppy.Y, (int) Helpers.WidthForCounter,
                    floppy.Height), _tempRectangle) && !_oneTime)
                {
                    ++Score;
                    _oneTime = true;
                }
            }
        }
    }
}