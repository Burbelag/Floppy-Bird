using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Floppy_Bird
{


    public class Game1 : Game
    {
        GraphicsDeviceManager _graphicsDeviceManager;

        private SpriteBatch _spriteBatch;
        private Texture2D _background;
        private Texture2D _floppyDriver;

//        
        private Vector2 _floppyDriverDownPos = new(300, 0f);
        private Vector2 _floppyDriverUpPos = new(300, 0f);

        private Vector3 _gameCamera;

        private KeyboardState _oldKeyboardState;

        private readonly List<Vector2> _listUpperDriver = new();
        private readonly List<Vector2> _listDownDriver = new();



        private int _pipeBetweenPosition = 0;
        private double _screenResolution;
        private float _backgroundScale;
        private float _floppyDriverScale;
        private float _cameraPos = 0;
        private bool _menu = true;
        private readonly Floppy _floppy;

        private const float DefaultXSpeed = 1.8f;

        public Game1()
        {
            IsMouseVisible = false;
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _floppy = new Floppy();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //_floppy._floppy = Content.Load<Texture2D>("floppy");
            //_background = Content.Load<Texture2D>("background");
            Scales scales = new Scales(_graphicsDeviceManager);
            //_floppyDriver = Content.Load<Texture2D>("floppy_driver");

            //нахождение как скалировать через теоремы пифагора

            //_screenResolution = _graphicsDeviceManager.PreferredBackBufferHeight ^
            //                    2 / _graphicsDeviceManager.PreferredBackBufferWidth ^ 2;

            //_backgroundScale = _background.Height ^ 2 / _background.Width ^ 2;

            //end

            _backgroundScale = (float) (_screenResolution / _backgroundScale);

            //Скейл драйвера в 2 раза меньше, вроде нормально

            //_floppyDriverScale = _backgroundScale / 2;
            //_floppyScale = (float) (_backgroundScale * 1.5);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState newState = Keyboard.GetState();

            if (_menu)
            {
                KeyboardState state = Keyboard.GetState();

                if (state.IsKeyDown(Keys.Space)) _menu = false;
            }
            else
            {
                if (_oldKeyboardState.IsKeyUp(Keys.Space) && newState.IsKeyDown(Keys.Space))
                {
                    _velocity = -5f;
                }

                /*  COLLISION STUFF */

                Rectangle floppy = new Rectangle((int) _floppyPos.X, (int) _floppyPos.Y,
                    (int) (_floppy._floppy.Width * _floppyScale),
                    (int) (_floppy._floppy.Height * _floppyScale));

                //        if (_floppyPos.X < 0 || _floppyPos.X > _graphicsDeviceManager.PreferredBackBufferWidth) Console.WriteLine("didthth");
                if (_floppyPos.Y < 0 || _floppyPos.Y > _graphicsDeviceManager.PreferredBackBufferHeight)
                    Console.WriteLine("Height");
                // Rectangle drive = new Rectangle((int) _driverDownPos0.X, (int) _driverDownPos0.Y,
                //     (int) (_floppyDriver.Width * _floppyDriverScale),
                //     (int) (_floppyDriver.Height * _floppyDriverScale));
                // Rectangle driveUp = new Rectangle((int) _driverUpPos0.X, (int) _driverUpPos0.Y,
                //     (int) (_floppyDriver.Width * _floppyDriverScale),
                //     (int) (_floppyDriver.Height * _floppyDriverScale));


                foreach (Vector2 pipe in _listUpperDriver)
                {
                    //неправильно расчитывается верхняя труба
                    //надо расстояние от 0 до _floppyDriver.Width
                    //например 0 - 150
                    //госпаде я такой тупой
                    float floppyDriverScaleCollision = pipe.Y * 2 + _floppyDriver.Width * _floppyDriverScale;

                    if (Collision(floppy, new Rectangle((int) pipe.X, 0,
                        (int) (_floppyDriver.Width * _floppyDriverScale),
                        (int) (floppyDriverScaleCollision))))
                    {
                        Console.WriteLine("upper pipe is detected !");
                    }
                }

                foreach (Vector2 pipe in _listDownDriver)
                {
                    float floppyDriverScaleCollision = pipe.Y * 2 + _floppyDriver.Height;
                    if (Collision(floppy, new Rectangle((int) pipe.X, (int) pipe.Y,
                        (int) (_floppyDriver.Width * _floppyDriverScale),
                        (int) (floppyDriverScaleCollision * _floppyDriverScale))))
                    {
                        Console.WriteLine("down pipe is detected !");
                    }
                }

                if (_pipeBetweenPosition > 200)
                {
                    Random random = new Random();
                    float randDriverPosY = random.Next(0,
                        _graphicsDeviceManager.PreferredBackBufferHeight / 4);

                    _listUpperDriver.Add(Draw_pipe(_floppyDriverDownPos.X += _pipeBetweenPosition,
                        randDriverPosY));

                    //select x4 floppys height space
<<<<<<< HEAD
                    float spaceForFloppy = randDriverPosY + _floppy.Height * 4;
=======
                    float spaceForFloppy = randDriverPosY + _floppy._floppy.Height * 4;
>>>>>>> 369bd3566b25f9683e1f8b6e67cf9a6f645900e8

                    _listDownDriver.Add(Draw_pipe(_floppyDriverUpPos.X += _pipeBetweenPosition,
                        spaceForFloppy + _floppyDriver.Height * _floppyDriverScale));
                    _pipeBetweenPosition = 0;
                }

                _pipeBetweenPosition += 2;

                _oldKeyboardState = newState;
<<<<<<< HEAD
                _velocity += _acceleration;
                _floppyPos.Y += _velocity;
                _floppyPos.X += DefaultXSpeed;
=======
                //_velocity += _acceleration;
                //_floppyPos.Y += _velocity;
                //_floppyPos.X += DefaultXSpeed;
>>>>>>> 369bd3566b25f9683e1f8b6e67cf9a6f645900e8

                _gameCamera = new Vector3(_cameraPos -= DefaultXSpeed, 0, 0.0f);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Purple);

            //draw static background
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);

            _spriteBatch.Draw(_background, Vector2.Zero, null, Color.White, 0.0f,
                Vector2.Zero, _backgroundScale, SpriteEffects.None, 0.0f);

            _spriteBatch.End();

            if (_menu)
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(_floppy, new Rectangle(_graphicsDeviceManager.PreferredBackBufferWidth / 2,
                    _graphicsDeviceManager.PreferredBackBufferHeight / 2, _floppy._floppy.Width, _floppy._floppy.Height), Color.White);
                _spriteBatch.End();
            }
            else
            {
                _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp,
                    null, null, null, Matrix.CreateTranslation(_gameCamera));

<<<<<<< HEAD
                _spriteBatch.Draw(_floppy, _floppyPos,
                    null, Color.White, 0.0f,
                    Vector2.Zero, _floppyScale, SpriteEffects.None, 0.0f);
=======
            //    _spriteBatch.Draw(_floppy._floppy, _floppyPos,
            //        null, Color.White, 0.0f,
            //        Vector2.Zero, _floppyScale, SpriteEffects.None, 0.0f);
>>>>>>> 369bd3566b25f9683e1f8b6e67cf9a6f645900e8

                foreach (Vector2 drawPipes in _listUpperDriver)
                {
                    _spriteBatch.Draw(_floppyDriver, new Rectangle((int) drawPipes.X, (int) drawPipes.Y,
                            (int) (_floppyDriver.Width * _floppyDriverScale),
                            (int) (_floppyDriver.Height * _floppyDriverScale)),
                        Color.White);
                }

                foreach (Vector2 drawPipes in _listDownDriver)
                {
                    _spriteBatch.Draw(_floppyDriver, new Rectangle((int) drawPipes.X, (int) drawPipes.Y,
                            (int) (_floppyDriver.Width * _floppyDriverScale),
                            (int) (_floppyDriver.Height * _floppyDriverScale)),
                        Color.White);
                }
                
                _spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        private Vector2 Draw_pipe(float driverPosX)
        {
            driverPosX += _graphicsDeviceManager.PreferredBackBufferWidth;
            return new Vector2(driverPosX, 0);
        }

        private Vector2 Draw_pipe(float driverPosX, float driverPosY)
        {
            driverPosX += _graphicsDeviceManager.PreferredBackBufferWidth;
            return new Vector2(driverPosX, driverPosY);
        }


        private static bool Collision(Rectangle a, Rectangle b)
        {
            return a.X < b.X + b.Width &&
                   a.X + a.Width > b.X &&
                   a.Y < b.Y + b.Height &&
                   a.Y + a.Height > b.Y;
        }
    }
}