using TDDBowlingGame.Service;
using NUnit.Framework;
using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
//using Moq;  

namespace TDDBowlingGame.Tests
{
    [TestFixture] 
    public class GameTests
    {
        private Game g;

        [SetUp]
        public void Setup()
        {
            g = new Game(); 
        }

        [Test]
        public void ShouldReturnGameOver_WhenThePlayerBolwsMoreThanExpetedRolls()
        {
            RollMany(24, 1);

            var exp = Assert.Throws<IndexOutOfRangeException>(() => g.Roll(25));
            Assert.AreEqual("Game Over!!", exp.Message);
        }
        
        [Test]
        public void ShouldReturnScore_When2FramesAreRolled()
        {
            RollMany(new int[] { 1, 2, 3, 4 });

            int result = g.FrameScore[g.FrameNo];
            Assert.AreEqual(10, result);
        }

        [Test]
        public void ShouldReturnScoreZero_WhenWeRollTheBall_And_NoPinsAreDown_InAllRoll()
        {
            RollMany(20, 0);

            int result = g.FrameScore[g.FrameNo];
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ShouldReturnScoreWithBonus_PerfectGame10PinsDownInAll10Frames()
        {
            RollMany(12, 10);

            int result = g.FrameScore[g.FrameNo];
            Assert.AreEqual(300, result);
        }

        [Test]
        public void ShouldReturnScoreWithBonus_When10thFrameHasSpare()
        {
            RollMany(18, 0); //end of 9th frame
            RollMany(new int[] { 7, 3, 3, 7 });

            int result = g.FrameScore[g.FrameNo];
            Assert.AreEqual(13, result);
        }

        [Test]
        public void ShouldReturnScoreWithBonus_When10thFrameHasStrike()
        {
            RollMany(18, 1); //end of 9th frame
            RollMany(new int[] { 10, 3, 3 });

            int result = g.FrameScore[g.FrameNo];
            Assert.AreEqual(34, result);
        }

        [Test]
        public void ShouldReturnScore_WhenOneRollHasSomePinsAreDown()
        {
            g.Roll(1);
           
            int result = g.FrameScore[g.FrameNo];
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ShouldReturnScore_WhenTwoRollHaveSomePinsAreDown()
        {
            RollMany(new int[] { 1, 4 });
            int result = g.FrameScore[g.FrameNo];
            Assert.AreEqual(5, result);
        }

        [Test]
        public void ShouldReturnScore_WhenThreeRollsHaveSomePinsAreDown()
        {
            RollMany(new int[] { 1, 2, 10, 6, 3 });
            int result = g.FrameScore[g.FrameNo];
            Assert.AreEqual(31, result);
        }

        [Test]
        public void ShouldReturnScoreWithBonus_WithOneSpare()
        {
            RollMany(new int[] { 5, 5, 3 });
            int result = g.FrameScore[g.FrameNo];
            Assert.AreEqual(16, result);
        }

        [Test]
        public void ShouldReturnScoreWithBonus_WithOneStrike()
        {
            RollMany(new int[] { 10, 4, 5 });
            int result = g.FrameScore[g.FrameNo];
            Assert.AreEqual(28, result);
        }

        [Test]
        public void ShouldReturnScoreWithBonus_WithOneStrike_2ndTest()
        {
            RollMany(new int[] { 0, 3, 10, 0, 4 });
            int result = g.FrameScore[g.FrameNo];
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

            int result = g.FrameScore[g.FrameNo];
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

            int result = g.FrameScore[g.FrameNo];
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

            int result = g.FrameScore[g.FrameNo];
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

            int result = g.FrameScore[g.FrameNo];
            Assert.AreEqual(117, result);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        private void RollMany(int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                g.Roll(pins[i]);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            g = null;
        }
    }
}
