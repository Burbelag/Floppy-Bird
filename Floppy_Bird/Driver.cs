using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Floppy_Bird
{
    public class Driver
    {
        private Texture2D _driver;
        
        public Driver(ContentManager contentManager)
        {
            _driver = contentManager.Load<Texture2D>("floppy_driver");
        }
    }
}