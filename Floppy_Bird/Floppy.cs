using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
<<<<<<< HEAD
using Microsoft.Xna.Framework.Input;
=======
>>>>>>> 369bd3566b25f9683e1f8b6e67cf9a6f645900e8

namespace Floppy_Bird
{
    public class Floppy
    {
<<<<<<< HEAD
        private const float DefaultXSpeed = 1.8f;
        private const float Acceleration = 0.15f;
        
        private readonly Texture2D _texture;
        
        private float _velocity;
        private Vector2 _position;
        private KeyboardState _oldState;
        
        public Floppy(ContentManager contentManager)
        {
            _texture = contentManager.Load<Texture2D>("floppy");
            _velocity = 0;
            _position = new Vector2(0.0f, 0.0f);
=======
        private Texture2D _floppy;
        private float _floppyScale;
        private float _velocity;
        private float _acceleration = 0.15f;
        private const float DefaultXSpeed = 1.8f;
        private Vector2 _floppyPos = new(200.0f, 200.0f);

        public Floppy(ContentManager contentManager)
        {
            _floppy = contentManager.Load<Texture2D>("floppy");
>>>>>>> 369bd3566b25f9683e1f8b6e67cf9a6f645900e8
        }

        public Floppy()
        {
        }

<<<<<<< HEAD
        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (_oldState.IsKeyUp(Keys.Space) && state.IsKeyDown(Keys.Space))
                _velocity = -5.0f;
            
            _velocity += Acceleration;
            
            _position.X += DefaultXSpeed;
            _position.Y += _velocity;

            _oldState = state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White,
                0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
=======
        protected void Draw(SpriteBatch spriteBatch)
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
>>>>>>> 369bd3566b25f9683e1f8b6e67cf9a6f645900e8
        }
    }
}