using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Floppy_Bird.Game
{
    public class Floppy : Sprite
    {
        public Texture2D FloppyTexture { get; set; }
        public readonly float _floppyScale;
        private float _velocity;
        private readonly float _acceleration = 0.15f;

        private const float DefaultXSpeed = 1.8f;

        private GraphicsDevice _graphicsDevice;

        public Vector2 _floppyPos = new(200.0f, 200.0f);

        public Floppy(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            FloppyTexture = contentManager.Load<Texture2D>("floppy");
            _graphicsDevice = graphicsDevice;

            Scales.ScaleObject scale = Scales.ScaleObject.Floppy;
            _floppyScale = Scales.Scale(_graphicsDevice, FloppyTexture, scale);
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle floppy = new Rectangle((int) _floppyPos.X, (int) _floppyPos.Y,
                (int) (FloppyTexture.Width * _floppyScale),
                (int) (FloppyTexture.Height * _floppyScale));
            //should in 'b' be drivers(pipes)
            if (Collision(floppy, new Rectangle()))
            {
            }

            Move();

            base.Update(gameTime);
        }

        public override bool Collision(Rectangle a, Rectangle b)
        {
            return base.Collision(a, b);
        }

        private void FloppyScreenCollision(GraphicsDevice graphicsDevice)
        {
            if (_floppyPos.Y < 0 || _floppyPos.Y > graphicsDevice.Adapter.CurrentDisplayMode.Height)
                Console.WriteLine("Height");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(FloppyTexture, _floppyPos,
                null, Color.White, 0.0f,
                Vector2.Zero, _floppyScale, SpriteEffects.None, 0.0f);
            base.Draw(spriteBatch);
        }

        public void Move()
        {
            _velocity += _acceleration;
            _floppyPos.Y += _velocity;
            _floppyPos.X += DefaultXSpeed;
        }
    }
}