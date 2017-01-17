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
        public void ScoreSingleNumericFrameReturnsTotal()
        {
            var game = new BowlingGame();

            var score = game.ScoreGame("12");

            Assert.That(score, Is.EqualTo(3));
        }
    }
}
