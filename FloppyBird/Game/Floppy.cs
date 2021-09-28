using System;
using Floppy_Bird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird.Game
{
    public class Floppy : Sprite
    {
        public Texture2D FloppyTexture { get; set; }
        public readonly float FloppyScale;
        private float _velocity;
        private readonly float _acceleration = 0.15f;

        private const float DefaultXSpeed = 1.8f;

        private GraphicsDevice _graphicsDevice;


        public Floppy(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            FloppyTexture = contentManager.Load<Texture2D>("floppy");
            _graphicsDevice = graphicsDevice;

            Scales.ScaleObject scale = Scales.ScaleObject.Floppy;
            FloppyScale = Scales.Scale(_graphicsDevice, FloppyTexture, scale);
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle floppy = new Rectangle((int) Playground.FloppyPos.X, (int) Playground.FloppyPos.Y,
                (int) (FloppyTexture.Width * FloppyScale),
                (int) (FloppyTexture.Height * FloppyScale));
            //should in 'b' be drivers(pipes)
            if (Collision(floppy, new Rectangle()))
            {
            }
            Move();
            FloppyScreenCollision(_graphicsDevice);
            base.Update(gameTime);
        }

        public override bool Collision(Rectangle a, Rectangle b)
        {
            return base.Collision(a, b);
        }

        private void FloppyScreenCollision(GraphicsDevice graphicsDevice)
        {
            if (Playground.FloppyPos.Y < 0 || Playground.FloppyPos.Y > graphicsDevice.Adapter.CurrentDisplayMode.Height)
                Console.WriteLine("Height");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(FloppyTexture, Playground.FloppyPos,
                null, Color.White, 0.0f,
                Vector2.Zero, FloppyScale, SpriteEffects.None, 0.0f);
            base.Draw(spriteBatch);
        }

        public void Move()
        {
            _velocity += _acceleration;
            Playground.FloppyPos.Y += _velocity;
            Playground.FloppyPos.X += DefaultXSpeed;
        }
    }
}