using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird2.Game
{
    public class Text
    {
        private Rectangle _tempRectangle;
        private static SpriteFont _scoreFont;
        private readonly GraphicsDevice _graphicsDevice;
        private Vector2 _position;

        private int Score { get; set; }
        private float _scoreScale;

        private bool _gameOver = false;

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

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, bool state)
        {
            Vector2 position = new((float) graphicsDevice.Viewport.Bounds.Height / 2,
                (float) graphicsDevice.Viewport.Bounds.Width / 2);

            if (state)
            {
                spriteBatch.DrawString(_scoreFont, "Game Over \n your score is \n" + Score, position,
                    Color.LightSkyBlue,
                    0.0f, Vector2.Zero, _scoreScale, SpriteEffects.None, 0.0f);
            }
            else
            {
                spriteBatch.DrawString(_scoreFont, "Press \"ENTER\" to start", position, Color.LightSkyBlue,
                    0.0f, Vector2.Zero, _scoreScale, SpriteEffects.None, 0.0f);                
            }
        }

        public void Update(Rectangle floppy, List<Rectangle> listDriver)
        {
            IncrementCounter(floppy, listDriver);
            Move();
        }

        private void Move()
        {
            _position.X += Helpers.DefaultXSpeed;
        }


        private void IncrementCounter(Rectangle floppy, List<Rectangle> driverList)
        {
            foreach (Rectangle driver in driverList)
            {
                _tempRectangle = new Rectangle(driver.X + driver.Width, 0, (int) Helpers.WidthForCounter,
                    _graphicsDevice.Viewport.Bounds.Height);

                if (Helpers.Collision(new Rectangle(floppy.X, floppy.Y, (int) Helpers.WidthForCounter,
                    floppy.Height), _tempRectangle))
                {
                    ++Score;
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