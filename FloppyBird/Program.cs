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
        private static void Main()
        {
            using (Game1 game = new())
                game.Run();
        }
    }
}