using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingConsole
{
    public class BowlingGame
    {
        private string[] _frames;
        private int _frameIdx = 0;

        public int ScoreGame(string gameScore)
        {
            var score = 0;
            
            _frames = gameScore.Split('|');
            foreach(var frame in _frames)
            {
                score += FrameScore(frame);
                _frameIdx++;
            }

            return score;
        }

        private int FrameScore(string frame)
        {
            if (IsSpare(frame))
            {
                var nextRoll = RollValue(_frames[_frameIdx + 1][0]);
                return 10 + nextRoll;
            }

            if (IsStrike(frame))
            {
                var next2Rolls = 0;
                var nextFrame = _frames[_frameIdx + 1];

                next2Rolls = FrameScore(nextFrame);

                return 10 + next2Rolls;
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
            
            return roll - 48;
        }

        private bool IsSpare(string frame)
        {
            return frame.Length > 1 && frame[1] == 47;
        }

        private bool IsStrike(string frame)
        {
            return frame.Length == 1 && frame[0] == 88;
        }
    }
}
