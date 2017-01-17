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
                if (frame == "")
                {
                    break;
                }
                score += FrameScore(frame);
                _frameIdx++;
            }

            return score;
        }

        private int FrameScore(string frame)
        {
            if (IsSpare(frame))
            {
                return 10 + FirstRollOfFrame(_frameIdx + 1);
            }
            else if (IsStrike(frame))
            {
                return 10 + NextTwoRolls();
            }
            else
            {
                var frameScore = 0;
                foreach (var roll in frame)
                {
                    frameScore += RollValue(roll);
                }
                return frameScore;
            }
        }

        private int RollValue(char roll)
        {
            if (roll == 45)
            {
                return 0;
            }
            
            return roll - 48;
        }

        private int FirstRollOfFrame(int frameIndex)
        {
            var nextFrame = _frames[frameIndex];
            if (nextFrame == "")
            {
                return 0;
            }
            return IsStrike(nextFrame) ? 10 : RollValue(nextFrame[0]);
        }

        private int NextTwoRolls()
        {
            var nextFrame = _frames[_frameIdx + 1];
            if (nextFrame == "")
            {
                return 0;
            }
            if (IsSpare(nextFrame))
            {
                return 10;
            }
            else if (IsStrike(nextFrame))
            {
                return 10 + FirstRollOfFrame(_frameIdx + 2);
            }
            else
            {
                return FrameScore(nextFrame);
            }
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
