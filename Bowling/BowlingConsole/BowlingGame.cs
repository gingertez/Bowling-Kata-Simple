using System.Linq;

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

            if (_frames.Length > 10)
            {
                score += BonusRolls();
            }

            return score;
        }

        private int BonusRolls()
        {
            var frame = _frames.Last();
            
            if (IsSpare(frame))
            {
                return 10;
            }
            else
            {
                var bonus = 0;
                for(var rollIdx = 0; rollIdx < _frames[11].Length; rollIdx++)
                {
                    bonus += RollOfFrame(11, rollIdx);
                }
                return bonus;
            }
        }
        private int FrameScore(string frame)
        {
            if (IsSpare(frame))
            {
                return 10 + RollOfFrame(_frameIdx + 1);
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

        private int RollOfFrame(int frameIndex, int rollIndex = 0)
        {
            var nextFrame = _frames[frameIndex];
            if (nextFrame == "")
            {
                return 0;
            }
            return IsStrike(nextFrame[rollIndex].ToString()) ? 10 : RollValue(nextFrame[rollIndex]);
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
                return 10 + (_frameIdx == 8 ? RollOfFrame(_frameIdx + 3) : RollOfFrame(_frameIdx + 2));
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
