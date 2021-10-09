using System;

namespace FloppyBird2.Game
{
    public class  DisposeGame : IDisposable
    {
        private bool _disposed;
        public virtual void Dispose()
        {
            if (_disposed)
            {
                return;
            }

        }
    }
}