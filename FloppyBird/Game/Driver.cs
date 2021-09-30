using System;
using System.Collections.Generic;
using System.Linq;
using Floppy_Bird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird.Game
{
    public class Driver
    {
        private readonly Texture2D DriverTexture;

        private readonly List<Vector2> _listUpperDriver = new();
        private readonly List<Vector2> _listDownDriver = new();
        private Vector2 _floppyDriverDownPos = new(300, 0f);
        private Vector2 _floppyDriverUpPos = new(300, 0f);

        private float _pipeBetweenPosition;
        private float _driverScale;

        private readonly GraphicsDevice _graphicsDevice;

        public Driver(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            DriverTexture = contentManager.Load<Texture2D>("floppy_driver");
            _graphicsDevice = graphicsDevice;
            _driverScale = GetDriverScale(_graphicsDevice);
        }

        public void Update(GameTime gameTime)
        {
            PipeGeneration(_graphicsDevice);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Vector2 drawPipes in _listUpperDriver)
            {
                spriteBatch.Draw(DriverTexture, new Rectangle((int) drawPipes.X, (int) drawPipes.Y,
                        (int) (DriverTexture.Width * _driverScale),
                        (int) (DriverTexture.Height * _driverScale)),
                    Color.White);
            }

            foreach (Vector2 drawPipes in _listDownDriver)
            {
                spriteBatch.Draw(DriverTexture, new Rectangle((int) drawPipes.X, (int) drawPipes.Y,
                        (int) (DriverTexture.Width * _driverScale),
                        (int) (DriverTexture.Height * _driverScale)),
                    Color.White);
            }
        }


        private void PipeGeneration(GraphicsDevice graphicsDevice)
        {
            if (_pipeBetweenPosition > 200)
            {
                Random random = new Random();

                float driverPosY = random.Next(graphicsDevice.Adapter.CurrentDisplayMode.Height / 3);
                
                _listUpperDriver.Add(Add_Pipe(_floppyDriverDownPos.X += _pipeBetweenPosition,
                    driverPosY));

                //select x4 floppys height space
                // 150 - is COSTIL'

                float spaceForFloppy = 150 + driverPosY;

                _listDownDriver.Add(Add_Pipe(_floppyDriverUpPos.X += _pipeBetweenPosition,
                    spaceForFloppy + DriverTexture.Height * _driverScale));
    
                _pipeBetweenPosition = 0;
            }

            _pipeBetweenPosition += 2;
        }

        private Vector2 Add_Pipe(float driverPosX, float driverPosY)
        {
            driverPosX += _graphicsDevice.Adapter.CurrentDisplayMode.Width;
            return new Vector2(driverPosX, driverPosY);
        }

        protected float GetDriverScale(GraphicsDevice graphicsDevice)
        {
            Helpers.ScaleObject scale = Helpers.ScaleObject.Driver;
            return _driverScale = Helpers.Scale(graphicsDevice, DriverTexture, scale);
        }

        
        //bug : Collision won't detected.
        public void DriverCollision(Rectangle floppy)
        {
            foreach (Vector2 pipe in _listUpperDriver)
            {
                //неправильно расчитывается верхняя труба
                //надо расстояние от 0 до _floppyDriver.Width
                //например 0 - 150
                //госпаде я такой тупой 

                if (Helpers.Collision(floppy, new Rectangle((int) pipe.X, (int) pipe.Y,
                    (int) (DriverTexture.Width * _driverScale),
                    (int) (DriverTexture.Height * _driverScale))))
                {
                    Console.WriteLine("upper pipe is detected !");
                }
            }

            int tempY = 150;
            foreach (var pipe in _listDownDriver)
            {
                if (Helpers.Collision(floppy, new Rectangle((int) pipe.X, (int) pipe.Y,
                    (int) (DriverTexture.Width * _driverScale),
                    (int) (DriverTexture.Height * _driverScale))))
                {
                    Console.WriteLine("down pipe is detected !");
                }
            }
        }
    }
}