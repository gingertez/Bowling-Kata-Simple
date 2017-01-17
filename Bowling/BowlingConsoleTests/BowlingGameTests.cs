using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BowlingConsole;

namespace BowlingConsoleTests
{
    [TestFixture]
    public class BowlingGameTests
    {
        [Test]
        public void ScoreSingleNumericFrame()
        {
            var game = new BowlingGame();

            var score = game.ScoreGame("12");

            Assert.That(score, Is.EqualTo(3));
        }

        [Test]
        public void ScoreMultipleNumericFrames()
        {
            var game = new BowlingGame();

            var score = game.ScoreGame("12|34");

            Assert.That(score, Is.EqualTo(10));
        }

        [Test]
        public void ScoreGutterBalls()
        {
            var game = new BowlingGame();

            var score = game.ScoreGame("--");

            Assert.That(score, Is.EqualTo(0));
        }

        [Test]
        public void ScoreGutterBallsWithNumericFrame()
        {
            var game = new BowlingGame();

            var score = game.ScoreGame("-6");

            Assert.That(score, Is.EqualTo(6));
        }
    }
}
