using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Floppy_Bird
{
    public static class Scales
    {
        public enum ScaleObject
        {
            Background,
            Floppy,
            Driver
        }
        public static float Scale(GraphicsDevice graphicsDevice, Rectangle obj, ScaleObject scaleObject)
        {
            float screenResolution = graphicsDevice.Adapter.CurrentDisplayMode.Height ^ 2 /
                graphicsDevice.Adapter.CurrentDisplayMode.Width ^ 2;
            float answer = obj.Height ^ 2 / obj.Width;

            answer = screenResolution / answer;
            switch (scaleObject)
            {
                case ScaleObject.Background :
                    return answer;
                case ScaleObject.Floppy :
                    answer = (float) (answer * 1.5);
                    return answer;
                case ScaleObject.Driver :
                    answer = answer / 2;
                    return answer;
            }

            throw new InvalidOperationException();
        }
    }
}