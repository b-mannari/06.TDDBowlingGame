using TDDBowlingGame.Service;
using NUnit.Framework;
using System.Collections.Generic;

namespace TDDBowlingGame.Tests
{
    public class GameTests
    {
        public List<int> frameScore = new List<int>();
        private Game g;

        [SetUp]
        public void Setup()
        {
            g = new Game();
        }

        [Test]
        public void ShouldReturnScoreZero_WhenWeRollTheBall_And_NoPinsAreDown_InAllRoll()
        {
            RollMany(20, 0);

            frameScore = g.frameScore;
            int result = g.CummulativeScore;
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ShouldReturnScore_WhenOneRollHasSomePinsAreDown()
        {
            g.Roll(1);

            frameScore = g.frameScore;
            int result = g.CummulativeScore;
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ShouldReturnScore_WhenTwoRollsHaveSomePinsAreDown()
        {
            g.Roll(1);
            g.Roll(2);
            g.Roll(10);
            g.Roll(6);
            g.Roll(3);
            frameScore = g.frameScore;
            int result = g.CummulativeScore;
            Assert.AreEqual(31, result);
        }

        [Test]
        public void ShouldReturnScoreWithBonus_WithOneSpare()
        {
            g.Roll(5);
            g.Roll(5);
            g.Roll(3);

            frameScore = g.frameScore;
            int result = g.CummulativeScore;
            Assert.AreEqual(16, result);
        }


        [Test]
        public void ShouldReturnScoreWithBonus_WithOneStrike()
        {
            g.Roll(10);
            g.Roll(4);
            g.Roll(5);

            frameScore = g.frameScore;
            int result = g.CummulativeScore;
            Assert.AreEqual(28, result);
        }


        [Test]
        public void ShouldReturnScoreWithBonus_PerfectGame10PinsDownInAll10Frames()
        {
            RollMany(12, 10);

            frameScore = g.frameScore;
            int result = g.CummulativeScore;
            Assert.AreEqual(300, result);
        }

        [Test]
        public void ShouldReturnScoreWithBonus_WithOneStrike_2ndTest()
        {
            g.Roll(0);
            g.Roll(3);
            g.Roll(10);
            g.Roll(0);
            g.Roll(4);

            frameScore = g.frameScore;
            int result = g.CummulativeScore;
            Assert.AreEqual(21, result);
        }

        [Test]
        public void ShouldReturnScoreWithBonus_With2ConsecutiveStrikes()
        {
            RollMany(11, 4);
            RollMany(1, 6);
            g.Roll(10);
            g.Roll(10);
            g.Roll(5);
            g.Roll(3);
            g.Roll(4);
            g.Roll(5);

            frameScore = g.frameScore;
            int result = g.CummulativeScore;
            Assert.AreEqual(120, result);
        }

        [Test]
        public void ShouldReturnScoreWithBonus_With3ConsecutiveStrikes()
        {
            RollMany(11, 4);
            RollMany(1, 7);
            g.Roll(10);
            g.Roll(10);
            g.Roll(10);
            g.Roll(3);
            g.Roll(4);

            frameScore = g.frameScore;
            int result = g.CummulativeScore;
            Assert.AreEqual(128, result);
        }


        [Test]
        public void ShouldReturnScoreWithBonus_With4ConsecutiveStrikes()
        {
            g.Roll(5);
            g.Roll(5);

            g.Roll(10);
            g.Roll(10);
            g.Roll(10);
            g.Roll(10);

            g.Roll(4);
            g.Roll(3);

            g.Roll(1);
            g.Roll(2);

            g.Roll(4);
            g.Roll(6);

            g.Roll(4);
            g.Roll(4);

            g.Roll(1);
            g.Roll(2);

            frameScore = g.frameScore;
            int result = g.CummulativeScore;
            Assert.AreEqual(156, result);
        }

        [Test]
        public void ShouldReturnScore_With10FrameHave2_Rolls()
        {
            g.Roll(1);
            g.Roll(4);

            g.Roll(4);
            g.Roll(5);

            g.Roll(6);
            g.Roll(4);

            g.Roll(5);
            g.Roll(5);

            g.Roll(10);

            g.Roll(0);
            g.Roll(1);

            g.Roll(7);
            g.Roll(3);

            g.Roll(6);
            g.Roll(4);

            g.Roll(10);

            g.Roll(2);
            g.Roll(3);

            frameScore = g.frameScore;
            int result = g.CummulativeScore;
            Assert.AreEqual(117, result);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            g = null;
        }
    }
}
