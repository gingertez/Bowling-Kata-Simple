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
                score += FrameScore(frame);
            }

            return score;
        }

        private int FrameScore(string frame)
        {
            if (IsSpare(frame))
            {
                return 10;
            }

            var frameScore = 0;

            foreach (var roll in frame)
            {
                frameScore += RollValue(roll);
            }

            return frameScore;
        }

        private int RollValue(char roll)
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

        private bool IsSpare(string frame)
        {
            return frame.Length > 1 && frame[1] == '/';
        }
    }
}
