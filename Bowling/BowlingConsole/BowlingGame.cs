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

            var frames = gameScore.Split('|');
            foreach(var frame in frames)
            {
                score += ScoreFrame(frame);
            }

            return score;
        }

        private int ScoreFrame(string frame)
        {
            var frameScore = 0;

            frameScore += int.Parse(frame[0].ToString());
            frameScore += int.Parse(frame[1].ToString());

            return frameScore;
        }
    }
}
