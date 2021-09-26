using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Floppy_Bird
{
    public class Floppy
    {
        private Texture2D _floppy;
        
        private float _floppyScale;
        private float _velocity;
        private float _acceleration = 0.15f;
        private const float DefaultXSpeed = 1.8f;
        
        private Vector2 _floppyPos = new(200.0f, 200.0f);

        public Floppy(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            Scales.ScaleObject scale = Scales.ScaleObject.Floppy;
            _floppy = contentManager.Load<Texture2D>("floppy");
            _floppyScale = Scales.Scale(graphicsDevice, _floppy, scale);
        }

        public Floppy()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_floppy, _floppyPos,
                null, Color.White, 0.0f,
                Vector2.Zero, _floppyScale, SpriteEffects.None, 0.0f);
        }

        public void Move()
        {
            _velocity += _acceleration;
            _floppyPos.Y += _velocity;
            _floppyPos.X += DefaultXSpeed;
        }
    }
}