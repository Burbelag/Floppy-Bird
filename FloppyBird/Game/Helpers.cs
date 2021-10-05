using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

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
            Driver,
            ScoreText
        }

        public static float Scale(GraphicsDevice graphicsDevice, Texture2D texture, ScaleObject scaleObject)
        {
            float screenResolution = graphicsDevice.Viewport.Bounds.Height ^
                                     2 / graphicsDevice.Viewport.Bounds.Height ^ 2;
            float answer = texture.Height ^ 2 / texture.Width ^ 2;

            answer = screenResolution / answer;
            switch (scaleObject)
            {
                case ScaleObject.Background:
                    return answer;
                case ScaleObject.Floppy:
                    return answer / 20;
                case ScaleObject.Driver:
                    return answer / 3;
                case ScaleObject.ScoreText:
                    return answer / 100;
                default:
                    return 1.0f;
            }
        }
        public static float Scale(GraphicsDevice graphicsDevice, SpriteFont font, ScaleObject scaleObject)
        {
            Texture2D fontTexture = font.Texture;
            float screenResolution = graphicsDevice.Viewport.Bounds.Height ^
                                     2 / graphicsDevice.Viewport.Bounds.Height ^ 2;
            float answer = fontTexture.Height ^ 2 / fontTexture.Width ^ 2;

            
            answer = screenResolution / answer;
            Console.WriteLine(answer);
            switch (scaleObject)
            {
                case ScaleObject.ScoreText:
                    return answer / 3;
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