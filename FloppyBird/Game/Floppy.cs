using System;
using FloppyBird2.Game;
using FloppyBird2.Game.SFX;
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
        private const float Acceleration = 0.15f;
        private float _velocity;
        public static bool FloppyReload;

        public Rectangle FloppyRectangle;

        private readonly GraphicsDevice _graphicsDevice;

        private KeyboardState _oldState;

        private readonly Sound _sound;

        public Floppy(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _floppyTexture = contentManager.Load<Texture2D>("floppy");
            _graphicsDevice = graphicsDevice;

            _sound = new Sound(contentManager);

            _position = new Vector2((float) graphicsDevice.Viewport.Width / 4,
                (float) graphicsDevice.Viewport.Height / 2);

            _floppyScale = GetFloppyScale(graphicsDevice);
        }

        public void Update(GameTime gameTime)
        {
            FloppyReload = false;
            FRectangle();
            HeightCollision();
            IsGameOver(Game1.GameOver);
            Jump();
            Move();
            
            Console.WriteLine(_position);
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
                _velocity = -_floppyTexture.Height * _floppyScale / 5;
                _sound.Play();
            }

            _oldState = newState;
        }

        private void Move()
        {
            _velocity += Acceleration;
            _position.Y += _velocity;
            _position.X += Helpers.DefaultXSpeed;
        }

        private void HeightCollision()
        {
            if (_position.Y < 0 || _position.Y > _graphicsDevice.Viewport.Bounds.Height)
            {
                Game1.Menu = true;
                Game1.GameOver = true;
            }
        }

        private float GetFloppyScale(GraphicsDevice graphicsDevice)
        {
            const Helpers.ScaleObject scale = Helpers.ScaleObject.Floppy;
            return _floppyScale = Helpers.Scale(graphicsDevice, _floppyTexture, scale);
        }

        private void IsGameOver(bool gameOver)
        {
            if (gameOver || Driver.DriverReload)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!");
                _position.X = (float) _graphicsDevice.Viewport.Bounds.Width / 4;
                _position.Y = (float) _graphicsDevice.Viewport.Bounds.Height / 2;
                FloppyReload = true;
            }

            FloppyReload = false;
            return;
        }
    }
}