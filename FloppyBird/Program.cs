using System;
using Floppy_Bird.Game;
using FloppyBird.Game;

namespace FloppyBird
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