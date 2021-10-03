using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace FloppyBird2.Game
{
    public class Text
    {
        public static SpriteFont ScoreFont;
        private readonly GraphicsDevice _graphicsDevice;
        public static Vector2 ScorePosition;

        private static int _counter;
        public static string ScoreText;

        public Text(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            ScoreFont = contentManager.Load<SpriteFont>("score");
            _graphicsDevice = graphicsDevice;
            SetScorePosition();
            ScoreText = SetText();
        }
        public void Update(GameTime gameTime)
        {
            ScoreText = ("score : " + _counter);
        }
        private void SetScorePosition()
        {
            ScorePosition.X = _graphicsDevice.Adapter.CurrentDisplayMode.Width -
                              _graphicsDevice.Adapter.CurrentDisplayMode.Width / 7;
            ScorePosition.Y = (float) _graphicsDevice.Adapter.CurrentDisplayMode.Height / 90;
        }
        
        /* SET TEXT AT THE INITIALIZATION*/
        private static string SetText()
        {
            return "score:  " + _counter;
        }

        
        public static void IncrementCounter(int scoreCounter)
        {
            _counter = scoreCounter;
        }
    }
}