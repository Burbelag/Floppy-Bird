using System;
using FloppyBird2.Game;

/* TODO : GAME OVER SCREEN
 * TODO : SOUND
 */
namespace FloppyBird2
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