using System;
using FloppyBird2.Game;
        /*TODO : FIX SCREEN RESOLUTION CHANGES
         *TODO : GAME MENU
         *TODO : FIX SCORE SCALE
         *TODO : SOUND
         * TODO : FIX FLOPPY'S JUMP SCALE
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