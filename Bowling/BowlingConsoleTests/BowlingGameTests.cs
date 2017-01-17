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
        [TestCase("12", 3)]
        [TestCase("12|34", 10)]
        [TestCase("--", 0)]
        [TestCase("-6", 6)]
        [TestCase("4-", 4)]
        [TestCase("X", 10)]
        [TestCase("63|X", 19)]
        public void ScoreGame(string gameScore, int expectedScore)
        {
            var game = new BowlingGame();
            var score = game.ScoreGame(gameScore);

            Assert.That(score, Is.EqualTo(expectedScore));
        }
    }
}
