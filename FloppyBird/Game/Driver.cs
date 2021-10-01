using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird.Game
{
    public class Driver
    {
        private readonly Texture2D _driverTexture;

        private readonly List<Rectangle> _listUpperDriver = new();
        private readonly List<Rectangle> _listDownDriver = new();

        private Vector2 _floppyDriverDownPos = new(300, 0f);
        private Vector2 _floppyDriverUpPos = new(300, 0f);

        private float _pipeBetweenPosition;
        private float _driverScale;

        private readonly GraphicsDevice _graphicsDevice;

        public Driver(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _driverTexture = contentManager.Load<Texture2D>("floppy_driver");
            _graphicsDevice = graphicsDevice;
            _driverScale = GetDriverScale(_graphicsDevice);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Rectangle drawPipes in _listUpperDriver)
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
            if (driverHeight <= 0) throw new ArgumentOutOfRangeException(nameof(driverHeight));
            driverPosX += _graphicsDevice.Adapter.CurrentDisplayMode.Width;
            driverWidth = (int) (driverWidth * _driverScale);
            driverHeight = (int) (driverHeight * _driverScale);
            return new Rectangle(driverPosX, driverPosY, driverWidth, driverHeight);
        }

        public void PipeGeneration(GraphicsDevice graphicsDevice, Rectangle floppy)
        {
            if (_pipeBetweenPosition > 200)
            {
                Random random = new Random();

                float targetHeight = random.Next(0, graphicsDevice.Adapter.CurrentDisplayMode.Height / 4);
                
                
                _listUpperDriver.Add(Add_Pipe((int) (_floppyDriverDownPos.X += _pipeBetweenPosition),
                    0, _driverTexture.Width, (int) (_driverTexture.Height + targetHeight)));

                /* SPACE FOR X4 FLOPPYS HEIGHT*/

                float spaceForFloppy = floppy.Height * 4 + targetHeight +
                                       _driverTexture.Height * GetDriverScale(graphicsDevice);
                
                _listDownDriver.Add(Add_Pipe((int) (_floppyDriverUpPos.X += _pipeBetweenPosition),
                    (int) spaceForFloppy, _driverTexture.Width, _graphicsDevice.Adapter.CurrentDisplayMode.Height));

                _pipeBetweenPosition = 0;
            }

            _pipeBetweenPosition += 2;
        }

        private float GetDriverScale(GraphicsDevice graphicsDevice)
        {
            Helpers.ScaleObject scale = Helpers.ScaleObject.Driver;
            return _driverScale = Helpers.Scale(graphicsDevice, _driverTexture, scale);
        }

        public void DriverCollision(Rectangle floppy)
        {
            foreach (Rectangle driverRectangle in _listUpperDriver)
            {
                if (Helpers.Collision(floppy, driverRectangle))
                {
                    Console.WriteLine("upper pipe is detected !");
                }
            }

            foreach (var driverRectangle in _listDownDriver)
            {
                if (Helpers.Collision(floppy, driverRectangle))
                {
                    Console.WriteLine("down pipe is detected !");
                }
            }
        }
    }
}