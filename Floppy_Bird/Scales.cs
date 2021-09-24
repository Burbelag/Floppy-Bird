using Microsoft.Xna.Framework;

namespace Floppy_Bird
{
    public class Scales
    {
        private Floppy _floppyScale = new Floppy();
        private Background _backgroundScale = new Background(contentManager);

        public Scales(GraphicsDeviceManager graphicsDeviceManager)
        {
            
            float screenResolution = graphicsDeviceManager.PreferredBackBufferHeight ^
                                2 / graphicsDeviceManager.PreferredBackBufferWidth ^ 2;

            float backgroundScale = _backgroundScale.Height ^ 2 / _backgroundScale.Width ^ 2;

            //end

            backgroundScale = (float) (screenResolution / backgroundScale);

            _driverScale = backgroundScale / 2;
            _floppyScale = (float) (_backgroundScale * 1.5));
        }

    }
}