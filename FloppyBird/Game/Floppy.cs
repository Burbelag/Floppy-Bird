using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FloppyBird.Game
{
    public class Floppy
    {
        private readonly Texture2D _floppyTexture;
        private float _floppyScale;
        private Vector2 _position;

        /* MOVEMENT */
        private readonly float _acceleration = 0.15f;
        private float _velocity;

        public Rectangle FloppyRectangle;

        private readonly GraphicsDevice _graphicsDevice;

        private KeyboardState _oldState;

        private int TEMPCOUNTER = 0;

        public Floppy(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _floppyTexture = contentManager.Load<Texture2D>("floppy");
            _graphicsDevice = graphicsDevice;

            _position = new Vector2(300.0f, graphicsDevice.Adapter.CurrentDisplayMode.Height / 2);

            _floppyScale = GetFloppyScale(graphicsDevice);
        }

        public void Update(GameTime gameTime)
        {
            FRectangle();
            HeightCollision();
            Jump();
            Move();
        }

        private void FRectangle()
        {
            FloppyRectangle = new Rectangle((int) _position.X, (int) _position.Y,
                (int) (_floppyTexture.Width * _floppyScale),
                (int) (_floppyTexture.Height * _floppyScale));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_floppyTexture, _position, null, Color.White, 0.0f,
                Vector2.Zero, _floppyScale, SpriteEffects.None, 0.0f);
        }

        private void Jump()
        {
            KeyboardState newState = Keyboard.GetState();

            if (_oldState.IsKeyUp(Keys.Space) && newState.IsKeyDown(Keys.Space))
            {
                _velocity = -5f;
            }

            _oldState = newState;
        }

        private void Move()
        {
            _velocity += _acceleration;
            _position.Y += _velocity;
            _position.X += Helpers.DefaultXSpeed;
        }

        private void HeightCollision()
        {
            if (_position.Y < 0 || _position.Y > _graphicsDevice.Adapter.CurrentDisplayMode.Height)
                Console.WriteLine("Height collision" + TEMPCOUNTER++);
        }

        protected float GetFloppyScale(GraphicsDevice graphicsDevice)
        {
            Helpers.ScaleObject scale = Helpers.ScaleObject.Floppy;
            return _floppyScale = Helpers.Scale(graphicsDevice, _floppyTexture, scale);
        }
    }
}