using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird2.Game
{
    public class Background
    {
        private static Texture2D _texture;
        private readonly float _backgroundScale;

        public Background(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            const Helpers.ScaleObject scale = Helpers.ScaleObject.Background;
            _texture = contentManager.Load<Texture2D>("background");
            _backgroundScale = Helpers.Scale(graphicsDevice, _texture, scale);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Vector2.Zero, null, Color.White,
                0.0f, Vector2.Zero, _backgroundScale, SpriteEffects.None, 0.0f);
        }
    }
}