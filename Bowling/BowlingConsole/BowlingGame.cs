using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingConsole
{
    public class BowlingGame
    {
        public int ScoreGame(string gameScore)
        {
            var score = 0;

            score += int.Parse(gameScore[0].ToString());
            score += int.Parse(gameScore[1].ToString());

            return score;
        }
    }
}
