using System;
using FloppyBird2.Game;
        /*TODO : FIX SCREEN RESOLUTION CHANGES
         *TODO : GAME MENU
         *TODO : SCORE COUNTER
         * 
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