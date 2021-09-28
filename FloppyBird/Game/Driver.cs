using System;
using System.Collections.Generic;
using Floppy_Bird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird.Game
{
    public class Driver : Sprite
    {
        public readonly Texture2D DriverTexture;

        public readonly List<Vector2> ListUpperDriver = new();
        public readonly List<Vector2> ListDownDriver = new();
        private Vector2 _floppyDriverDownPos = new(300, 0f);
        private Vector2 _floppyDriverUpPos = new(300, 0f);
        
        private float _pipeBetweenPosition;
        public float DriverScale;

        private readonly GraphicsDevice _graphicsDevice;
        private Floppy _floppy;
        public Driver(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            DriverTexture = contentManager.Load<Texture2D>("floppy_driver");
            _graphicsDevice = graphicsDevice;
            DriverScale = GetDriverScale(_graphicsDevice);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Vector2 drawPipes in ListUpperDriver)
            {
                spriteBatch.Draw(DriverTexture, new Rectangle((int) drawPipes.X, (int) drawPipes.Y,
                        (int) (DriverTexture.Width * DriverScale),
                        (int) (DriverTexture.Height * DriverScale)),
                    Color.White);
            }

            foreach (Vector2 drawPipes in ListDownDriver)
            {
                spriteBatch.Draw(DriverTexture, new Rectangle((int) drawPipes.X, (int) drawPipes.Y,
                        (int) (DriverTexture.Width * DriverScale),
                        (int) (DriverTexture.Height * DriverScale)),
                    Color.White);
            }

            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            PipeGeneration(_graphicsDevice);
            base.Update(gameTime);
        }

        private void PipeGeneration(GraphicsDevice graphicsDevice)
        {
            if (_pipeBetweenPosition > 200)
            {
                Random random = new Random();
                float randDriverPosY = random.Next(0,
                    graphicsDevice.Adapter.CurrentDisplayMode.Height / 4);

                ListUpperDriver.Add(Draw_pipe(_floppyDriverDownPos.X += _pipeBetweenPosition,
                    randDriverPosY));

                //select x4 floppys height space
                // 150 - is COSTIL'
                float spaceForFloppy = randDriverPosY + 150;
                ListDownDriver.Add(Draw_pipe(_floppyDriverUpPos.X += _pipeBetweenPosition,
                    spaceForFloppy + DriverTexture.Height * DriverScale));
                _pipeBetweenPosition = 0;
            }

            _pipeBetweenPosition += 2;
        }

        private Vector2 Draw_pipe(float driverPosX, float driverPosY)
        {
            driverPosX += _graphicsDevice.Adapter.CurrentDisplayMode.Width;
            return new Vector2(driverPosX, driverPosY);
        }

        protected float GetDriverScale(GraphicsDevice graphicsDevice)
        {
            Scales.ScaleObject scale = Scales.ScaleObject.Driver;
            return DriverScale = Scales.Scale(graphicsDevice, DriverTexture, scale);
        }
    }
}