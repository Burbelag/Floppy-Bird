using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Floppy_Bird.Game
{
    public class Background
    {
        public readonly Texture2D BackgroundTexture;
        private float _backgroundScale;
        private GraphicsDevice _graphicsDevice;
        public Background(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            Scales.ScaleObject scale = Scales.ScaleObject.Background;
            BackgroundTexture = contentManager.Load<Texture2D>("background");
            _graphicsDevice = graphicsDevice;
            _backgroundScale = Scales.Scale(_graphicsDevice, BackgroundTexture, scale);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundTexture, Vector2.Zero, null, Color.White, 0.0f,
                Vector2.Zero, _backgroundScale, SpriteEffects.None, 0.0f);

        }
    }
}