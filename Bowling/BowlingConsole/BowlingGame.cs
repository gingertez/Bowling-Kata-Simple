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

            foreach(var roll in frame)
            {
                frameScore += GetRollValue(roll);
            }

            return frameScore;
        }

        private int GetRollValue(char roll)
        {
            if (roll == 45)
            {
                return 0;
            }

            if (roll == 88)
            {
                return 10;
            }
            
            return roll - 48;
        }
    }
}
