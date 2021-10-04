using System;
using System.Collections.Generic;
using FloppyBird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird2.Game
{
    public class Driver
    {
        private readonly Texture2D _driverTexture;

        public readonly List<Rectangle> ListUpperDriver;
        private readonly List<Rectangle> _listDownDriver;

        private Vector2 _floppyDriverDownPos;
        private Vector2 _floppyDriverUpPos;

        private float _pipeBetweenPosition;
        private float _driverScale;

        private readonly GraphicsDevice _graphicsDevice;

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

        public void Update(GameTime gameTime, Rectangle floppy)
        {
            PipeGeneration(floppy);
            DriverCollision(floppy);
            DeleteDriver(floppy);
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

            driverPosX += _graphicsDevice.Adapter.CurrentDisplayMode.Width;
            driverWidth = (int) (driverWidth * _driverScale);
            driverHeight = (int) (driverHeight * _driverScale);

            return new Rectangle(driverPosX, driverPosY, driverWidth, driverHeight);
        }

        private void PipeGeneration(Rectangle floppy)
        {
            if (_pipeBetweenPosition > 200)
            {
                Random random = new();

                float targetHeight = random.Next(_graphicsDevice.Adapter.CurrentDisplayMode.Height / 3,
                    _graphicsDevice.Adapter.CurrentDisplayMode.Height);

                ListUpperDriver.Add(Add_Pipe((int) (_floppyDriverDownPos.X += _pipeBetweenPosition), 0,
                    _driverTexture.Width, (int) (targetHeight)));

                float spaceForFloppy = targetHeight + 100;
                
                _listDownDriver.Add(Add_Pipe((int) (_floppyDriverUpPos.X += _pipeBetweenPosition), (int) spaceForFloppy,
                    _driverTexture.Width, _graphicsDevice.Adapter.CurrentDisplayMode.Height));

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
                    Console.WriteLine("upper pipe is detected !");
                }
            }

            foreach (Rectangle driverRectangle in _listDownDriver)
            {
                if (Helpers.Collision(floppy, driverRectangle))
                {
                    Console.WriteLine("down pipe is detected !");
                }
            }
        }
    }
}