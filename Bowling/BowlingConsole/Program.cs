using System;

namespace BowlingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new BowlingGame();
            try
            {
                Console.WriteLine($"Score is {game.ScoreGame(args[0])}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error calculating score: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
