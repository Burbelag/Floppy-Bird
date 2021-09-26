using System.Threading;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Floppy_Bird
{
    public class Playground : Interface
    {
        private Floppy _floppy;
        private Driver _driver;
        private Background _background;
        public Playground(ContentManager contentManager)
        {
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _background = new Background(contentManager);
            _floppy = new Floppy(contentManager);
            _driver = new Driver(contentManager);
            
            base.LoadContent(contentManager);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _background.Draw (spriteBatch);
            _driver.Draw(spriteBatch);
            _floppy.Draw(spriteBatch);
        }
    }
}