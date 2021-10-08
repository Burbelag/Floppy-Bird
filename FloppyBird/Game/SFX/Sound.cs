using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FloppyBird2.Game.SFX
{
    public class Sound
    {
        private SoundEffect _jump1;
        private SoundEffect _jump2;
        private SoundEffect _jump3;
        private SoundEffectInstance _jumpSoundInstance;

        private int randSound;

        public Sound(ContentManager contentManager)
        {
            _jump1 = contentManager.Load<SoundEffect>("SFX/jump_1");
            _jump2 = contentManager.Load<SoundEffect>("SFX/jump_2");
            _jump3 = contentManager.Load<SoundEffect>("SFX/jump_3");
            _jumpSoundInstance = _jump1.CreateInstance();
        }

        public void Play()
        {
            Random random = new();
            randSound = random.Next(0, 2);

            switch (randSound)
            {
                case 0:
                {
                    _jump1.Play();
                    break;
                }
                case 1:
                    _jump2.Play();
                    break;
                case 2:
                    _jump3.Play();
                    break;
            }
        }
    }
}