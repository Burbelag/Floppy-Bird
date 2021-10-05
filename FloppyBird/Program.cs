using System;
using FloppyBird2.Game;

/* TODO : GAME OVER SCREEN
 * TODO : SOUND
 * TODO : FIX GAME OVER SCREEN 'SCORE'
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