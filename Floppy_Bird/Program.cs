using System;
using Floppy_Bird.Game;

namespace Floppy_Bird
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}