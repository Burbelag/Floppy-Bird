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

        /* позицию задаешь здесь и получать в playground через _floppy.Position... */
        public Vector2 Position { get; set; }

        public Floppy(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            FloppyTexture = contentManager.Load<Texture2D>("floppy");
            _graphicsDevice = graphicsDevice;

            Scales.ScaleObject scale = Scales.ScaleObject.Floppy;
            FloppyScale = Scales.Scale(_graphicsDevice, FloppyTexture, scale);
            
            /* задаешь новые значения и далее работаешь с ними */
            Position = new Vector2(300.0f, 300.0f);
        }

        public override void Update(GameTime gameTime)
        {
            //should in 'b' be drivers(pipes)
            Move();
            
            base.Update(gameTime);
        }

        public override bool Collision(Rectangle a, Rectangle b)
        {
            return base.Collision(a, b);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(FloppyTexture, Position,
                null, Color.White, 0.0f,
                Vector2.Zero, FloppyScale, SpriteEffects.None, 0.0f);
            base.Draw(spriteBatch);
        }

        public void Move()
        {
            _velocity += _acceleration;
            //Position.Y += _velocity;
            //Position.X += DefaultXSpeed;
        }
    }
}