using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Floppy_Bird
{
    public class Background
    {
        private Texture2D _background;
        public Background(ContentManager contentManager)
        {
            //AAAAAAAAAAARHRRHRHRHRHRHR
            //SUKA !
            //EBANOE OOP
            //DAYTE MNE SVYTAOY C
            _background = contentManager.Load<Texture2D>("background");
        }
    }
}