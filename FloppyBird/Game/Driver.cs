using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird2.Game
{
    public class Driver
    {
        private readonly Texture2D _driverTexture;

        public readonly List<Rectangle> ListUpperDriver;
        private List<Rectangle> _listDownDriver;

        private Vector2 _floppyDriverDownPos;
        private Vector2 _floppyDriverUpPos;

        private float _pipeBetweenPosition;
        private float _driverScale;

        private readonly GraphicsDevice _graphicsDevice;

        public void Update(GameTime gameTime, Rectangle floppy)
        {
            PipeGeneration(floppy);
            DriverCollision(floppy);
            DeleteDriver(floppy);
            IsGameOver(Game1.GameOver);
        }

        public Driver(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _driverTexture = contentManager.Load<Texture2D>("floppy_driver");
            _graphicsDevice = graphicsDevice;
            _driverScale = GetDriverScale(_graphicsDevice);

            ListUpperDriver = new();
            _listDownDriver = new();

            _floppyDriverDownPos = new(300.0f, 0.0f);
            _floppyDriverUpPos = new(300.0f, 0.0f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Rectangle drawPipes in ListUpperDriver)
            {
                spriteBatch.Draw(_driverTexture, drawPipes, Color.White);
            }

            foreach (Rectangle drawPipes in _listDownDriver)
            {
                spriteBatch.Draw(_driverTexture, drawPipes, Color.White);
            }
        }

        private Rectangle Add_Pipe(int driverPosX, int driverPosY, int driverWidth, int driverHeight)
        {
            if (driverHeight <= 0)
                throw new ArgumentOutOfRangeException(nameof(driverHeight));

            driverPosX += _graphicsDevice.Viewport.Bounds.Width;
            return new Rectangle(driverPosX, driverPosY, driverWidth, driverHeight);
        }

        private void PipeGeneration(Rectangle floppy)
        {
            if (_pipeBetweenPosition > 200)
            {
                Random random = new();

                float holePosition = random.Next((int) (_graphicsDevice.Viewport.Bounds.Height * 0.20),
                    (int) (_graphicsDevice.Viewport.Bounds.Height * 0.70));
                /* hole size with x5 floppy's height*/
                int holeSize = floppy.Height * 5;

                ListUpperDriver.Add(Add_Pipe((int) (_floppyDriverDownPos.X += _pipeBetweenPosition), 0,
                    (int) (_driverTexture.Width * _driverScale), (int) holePosition));

                _listDownDriver.Add(Add_Pipe((int) (_floppyDriverUpPos.X += _pipeBetweenPosition),
                    (int) holePosition + holeSize,
                    (int) (_driverTexture.Width * _driverScale),
                    _graphicsDevice.Viewport.Bounds.Height - (int) holePosition - holeSize));

                _pipeBetweenPosition = 0;
            }

            _pipeBetweenPosition += 2;
        }


        private float GetDriverScale(GraphicsDevice graphicsDevice)
        {
            const Helpers.ScaleObject scale = Helpers.ScaleObject.Driver;
            return _driverScale = Helpers.Scale(graphicsDevice, _driverTexture, scale);
        }

        private void DeleteDriver(Rectangle floppy)
        {
            foreach (Rectangle rectangle in ListUpperDriver)
            {
                if (floppy.X <= rectangle.X + rectangle.Width + 300)
                    continue;

                ListUpperDriver.RemoveAt(0);
                break;
            }

            foreach (Rectangle rectangle in _listDownDriver)
            {
                if (floppy.X <= rectangle.X + rectangle.Width + 300)
                    continue;

                _listDownDriver.RemoveAt(0);
                break;
            }
        }


        private void DriverCollision(Rectangle floppy)
        {
            foreach (Rectangle driverRectangle in ListUpperDriver)
            {
                if (Helpers.Collision(floppy, driverRectangle))
                {
                    Game1.Menu = true;
                    Game1.GameOver = true;
                }
            }

            foreach (Rectangle driverRectangle in _listDownDriver)
            {
                if (Helpers.Collision(floppy, driverRectangle))
                {
                    Game1.Menu = true;
                    Game1.GameOver = true;
                }
            }
        }

        private void IsGameOver(bool gameOver)
        {
            if (gameOver)
            {
                ListUpperDriver.Clear();
                _listDownDriver.Clear();

                _floppyDriverDownPos = new(300.0f, 0.0f);
                _floppyDriverUpPos = new(300.0f, 0.0f);
            }
        }
    }
}