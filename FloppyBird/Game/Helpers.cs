using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird.Game
{
    public static class Helpers
    {
        private static readonly Vector2 ScreenSize = new Vector2(1280.0f, 720.0f);
        public static readonly float DefaultXSpeed = 1.8f;

        public enum ScaleObject
        {
            Background,
            Floppy,
            Driver
        }

        public static float Scale(GraphicsDevice graphicsDevice, Texture2D obj, ScaleObject scaleObject)
        {
            float screenResolution = graphicsDevice.Adapter.CurrentDisplayMode.Height ^ 2 /
                graphicsDevice.Adapter.CurrentDisplayMode.Width ^ 2;
            float answer = obj.Height ^ 2 / obj.Width;

            answer = screenResolution / answer;
            switch (scaleObject)
            {
                case ScaleObject.Background:
                    return answer;
                case ScaleObject.Floppy:
                    answer =  answer / 20;
                    return answer;
                case ScaleObject.Driver:
                    answer = answer / 2;
                    return answer;
            }

            throw new InvalidOperationException();
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