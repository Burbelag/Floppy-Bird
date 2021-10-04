using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird2.Game
{
    public static class Helpers
    {
        public const float DefaultXSpeed = 2.0f;
        public const float WidthForCounter = DefaultXSpeed;

        public enum ScaleObject
        {
            Background,
            Floppy,
            Driver
        }

        public static float Scale(GraphicsDevice graphicsDevice, Texture2D texture, ScaleObject scaleObject)
        {
            float screenResolution = graphicsDevice.Viewport.Bounds.Height ^
                                     2 / graphicsDevice.Viewport.Bounds.Height ^ 2;
            float answer = texture.Height ^ 2 / texture.Width ^ 2 ;

            answer = screenResolution / answer;
            switch (scaleObject)
            {
                case ScaleObject.Background:
                    return answer;
                case ScaleObject.Floppy:
                    answer /= 20;
                    return answer;
                case ScaleObject.Driver:
                    answer /= 3;
                    return answer;
                default:
                    return 1.0f;
            }
        }

        public static bool Collision(Rectangle a, Rectangle b)
        {
            return a.X < b.X + b.Width &&
                   a.X + a.Width > b.X &&
                   a.Y < b.Y + b.Height &&
                   a.Y + a.Height > b.Y;
        }
    }
}