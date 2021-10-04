using System;
using FloppyBird2.Game;

/*TODO : GAME MENU
 *TODO : FIX SCORE SCALE
 *TODO : SOUND
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