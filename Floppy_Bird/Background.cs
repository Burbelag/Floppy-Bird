using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Floppy_Bird
{
    public class Background
    {
        public Texture2D _background;
        private float _backgroundScale;
        public Background(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            Scales.ScaleObject scale = Scales.ScaleObject.Background;
            _background = contentManager.Load<Texture2D>("background");
            _backgroundScale = Scales.Scale(graphicsDevice, _background, scale);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, Vector2.Zero, null, Color.White, 0.0f,
                Vector2.Zero, _backgroundScale, SpriteEffects.None, 0.0f);

        }
    }
}