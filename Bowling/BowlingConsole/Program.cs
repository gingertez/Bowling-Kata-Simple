using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
