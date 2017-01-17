using System;
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
        [TestCase("1-|1-|1-|1-|1-|1-|1-|1-|1-|X||23", 24)]
        [TestCase("1-|1-|1-|1-|1-|1-|1-|1-|1-|X||3/", 29)]
        [TestCase("1-|1-|1-|1-|1-|1-|1-|1-|1-|X||XX", 39)]
        [TestCase("1-|1-|1-|1-|1-|1-|1-|1-|X|X||XX", 68)]
        [TestCase("X|X|X|X|X|X|X|X|X|X||XX", 300)]
        [TestCase("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||", 90)]
        [TestCase("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5", 150)]
        [TestCase("X|7/|9-|X|-8|8/|-6|X|X|X||81", 167)]
        public void ScoreGame(string gameScore, int expectedScore)
        {
            var game = new BowlingGame();
            var score = game.ScoreGame(gameScore);

            Assert.That(score, Is.EqualTo(expectedScore));
        }

        [Test]
        public void ErrorThrownIfInvalidCharacterPresent()
        {
            var game = new BowlingGame();
            Assert.Throws<InvalidOperationException>(() => game.ScoreGame("X|23|A1"));
        }
    }
}
