using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Floppy_Bird.Game
{
    public class Sprite
    {
        public virtual bool Collision(Rectangle a, Rectangle b)
        {
            return a.X < b.X + b.Width &&
                   a.X + a.Width > b.X &&
                   a.Y < b.Y + b.Height &&
                   a.Y + a.Height > b.Y;
        }
        
        public virtual void LoadContent(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }

        protected void LoadContent(ContentManager contentManager)
        {
            throw new System.NotImplementedException();
        }
    }
}