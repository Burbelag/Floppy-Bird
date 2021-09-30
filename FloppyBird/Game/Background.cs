using FloppyBird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Floppy_Bird.Game
{
    public class Background
    {
        public static Texture2D BackgroundTexture;
        public  static float BackgroundScale;
        private GraphicsDevice _graphicsDevice;
        public Background(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            Helpers.ScaleObject scale = Helpers.ScaleObject.Background;
            BackgroundTexture = contentManager.Load<Texture2D>("background");
            _graphicsDevice = graphicsDevice;
            BackgroundScale = Helpers.Scale(_graphicsDevice, BackgroundTexture, scale);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundTexture, Vector2.Zero, null, Color.White, 0.0f,
                Vector2.Zero, BackgroundScale, SpriteEffects.None, 0.0f);

        }
    }
}