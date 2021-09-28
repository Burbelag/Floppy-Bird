using System;
using Floppy_Bird.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FloppyBird.Game
{
    public class Playground : Sprite
    {
         private Floppy _floppy;
         private Driver _driver;
         private Background _background;

        private ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;

        private float _cameraPos;
        private KeyboardState _oldKeyboardState;

        private const float DefaultXSpeed = 1.8f;

        private Vector3 _gameCamera;
        private Rectangle _floppyRectangle;

        public Playground(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _contentManager = contentManager;
            
        }

        public override void LoadContent(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {

            _background = new Background(contentManager, graphicsDevice);
            _floppy = new Floppy(contentManager, graphicsDevice);
            _driver = new Driver(contentManager, graphicsDevice);

            base.LoadContent(contentManager, graphicsDevice);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _background.Draw(spriteBatch);
            _driver.Draw(spriteBatch);
            _floppy.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();

            _floppyRectangle = new Rectangle((int) _floppy.Position.X, (int) _floppy.Position.Y,
                (int) (_floppy.FloppyTexture.Width * _floppy.FloppyScale),
                (int) (_floppy.FloppyTexture.Height * _floppy.FloppyScale));
            
            if (_floppy.Position.Y < 0 || _floppy.Position.Y > _graphicsDevice.Adapter.CurrentDisplayMode.Height)
                Console.WriteLine("Height collision");

            _oldKeyboardState = newState;

            _gameCamera = new Vector3(_cameraPos -= DefaultXSpeed, 0, 0.0f);
            //protected DriverCollision()

            foreach (Vector2 pipe in _driver.ListUpperDriver)
            {
                //неправильно расчитывается верхняя труба
                //надо расстояние от 0 до _floppyDriver.Width
                //например 0 - 150
                //госпаде я такой тупой 
                float floppyDriverScaleCollision = pipe.Y * 2 + _driver.DriverTexture.Width * _driver.DriverScale;
                if (Collision(_floppyRectangle, new Rectangle((int) pipe.X, 0,
                    (int) (_driver.DriverTexture.Width * _driver.DriverScale),
                    (int) (floppyDriverScaleCollision))))
                {
                    Console.WriteLine("upper pipe is detected !");
                }
            }

            foreach (Vector2 pipe in _driver.ListDownDriver)
            {
                float floppyDriverScaleCollision = pipe.Y * 2 + _driver.DriverTexture.Height;
                if (Collision(_floppyRectangle, new Rectangle((int) pipe.X, (int) pipe.Y,
                    (int) (_driver.DriverTexture.Width * _driver.DriverScale),
                    (int) (floppyDriverScaleCollision * _driver.DriverScale))))
                {
                    Console.WriteLine("down pipe is detected !");
                }
            }

            base.Update(gameTime);
        }
    }
}