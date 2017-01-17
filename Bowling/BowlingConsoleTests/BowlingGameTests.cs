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
        [TestCase("X|34", 24)]
        [TestCase("63|X|34", 33)]
        [TestCase("X|X|3-", 39)]
        [TestCase("X|X|X|3-", 69)]
        [TestCase("X|3/|3-", 36)]
        [TestCase("3/|4-", 18)]
        [TestCase("3/|4/|5-", 34)]
        [TestCase("3/|X|5-", 40)]
        [TestCase("1-|1-|1-|1-|1-|1-|1-|1-|1-|1-||", 10)]
        [TestCase("1-|1-|1-|1-|1-|1-|1-|1-|1-|1/||2", 21)]
        public void ScoreGame(string gameScore, int expectedScore)
        {
            var game = new BowlingGame();
            var score = game.ScoreGame(gameScore);

            Assert.That(score, Is.EqualTo(expectedScore));
        }
    }
}
