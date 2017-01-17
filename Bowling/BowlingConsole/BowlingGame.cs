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

            frameScore += GetRollValue(frame[0]);
            frameScore += GetRollValue(frame[1]);

            return frameScore;
        }

        private int GetRollValue(char roll)
        {
            return roll == '-' ? 0 : int.Parse(roll.ToString());
        }
    }
}
