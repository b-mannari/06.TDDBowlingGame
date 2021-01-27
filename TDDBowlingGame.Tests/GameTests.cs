using TDDBowlingGame.Service;
using NUnit.Framework;

namespace TDDBowlingGame.Tests 
{
    public class GameTests
    {
        private Game g;
        [SetUp]
        public void Setup()
        {
            g = new Game();
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        [Test]
        public void Should_be_able_to_score_a_game_with_all_Zeros_in_AllEachRoll()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, g.Score());
        }

        [Test]
        public void ShouldReturnTrue_When1FrameHas1_Rolls()
        {
            g.Roll(1);

            int result = g.Score();

            Assert.AreEqual(1, result);
        }

        [Test]
        public void ShouldReturnTrue_When1FrameHas2_Rolls()
        {
            g.Roll(1);
            g.Roll(4);

            int result = g.Score();

            Assert.AreEqual(5, result);
        }

        [Test]
        public void Should_be_able_to_score_a_game_with_One_Spare()
        {
            g.Roll(5);
            g.Roll(5);
            g.Roll(3);   // Spare from the next Frame
            //RollMany(17, 0);
            Assert.AreEqual(16, g.Score());
        }

        [Test]
        public void Should_be_able_to_score_a_game_with_One_Strike_1stTest()
        {
            g.Roll(10);
            //g.Roll(0); //** should not roll **
            g.Roll(4);
            g.Roll(5);   // Strike from the next Frame
            //RollMany(16, 0);
            Assert.AreEqual(28, g.Score());
        }

        [Test]
        public void Should_be_able_to_score_a_game_with_One_Strike_2ndTest()
        {
            g.Roll(10);
            //g.Roll(0); //** should not roll **
            g.Roll(3);
            g.Roll(4); // Strike from the next Frame
            //RollMany(16, 0);
            Assert.AreEqual(24, g.Score());
        }

        //[Test]
        //public void Should_be_a_PerfectGame_10PinsDown_InAll10Frames()
        //{
        //    RollMany(12, 10);  //12 is number of rolls and 10 is the number of pins

        //    Assert.AreEqual(300, g.FrameScore());
        //}


        [Test]
        public void Should_be_SumOf_2ConsecutiveStrikesin7th8thFrames_FollowedBy2RollsKnockDowninthe9thFrame()
        {
            RollMany(11, 4);
            RollMany(1, 7);       // Score 51
            g.Roll(10);    // 1st Strike from Frame 7
            g.Roll(10);    // 2nd Strike from Frame 8 
            g.Roll(5);     // Normal pinsdown of next Frame 9
            g.Roll(3);     // Normal pinsdown of next Frame 9
            g.Roll(4);     // Normal pinsdown of next Frame 10
            g.Roll(5);     // Normal pinsdown of next Frame 10
            Assert.AreEqual(111, g.Score());   //Expected is sum of above
        }

        [Test]
        public void Should_be_SumOf_3ConsecutiveStrikes()
        {
            RollMany(11, 4);
            RollMany(1, 7);       // Score 51
            g.Roll(10);    // 2nd Strike from Frame 6
            g.Roll(10);    // 1st Strike from Frame 7
            g.Roll(10);    // 2nd Strike from Frame 8 
            g.Roll(3);     // Normal pinsdown of next Frame 9
            g.Roll(4);     // Normal pinsdown of next Frame 9
            Assert.AreEqual(128, g.Score());   //Expected is sum of above
        }


        [Test]
        public void Should_be_SumOf_4ConsecutiveStrikes()
        {
            g.Roll(5);    // 2nd Strike from Frame 6
            g.Roll(5);    // 1st Strike from Frame 7

            g.Roll(10);    // 2nd Strike from Frame 8 
            g.Roll(10);    // 2nd Strike from Frame 8 
            g.Roll(10);     // Normal pinsdown of next Frame 9
            g.Roll(10);    // 2nd Strike from Frame 8 

            g.Roll(4);     // Normal pinsdown of next Frame 9
            g.Roll(3);    // 2nd Strike from Frame 8 

            g.Roll(1);     // Normal pinsdown of next Frame 9
            g.Roll(2);    // 2nd Strike from Frame 8 

            g.Roll(4);     // Normal pinsdown of next Frame 9
            g.Roll(6);    // 2nd Strike from Frame 8 

            g.Roll(4);     // Normal pinsdown of next Frame 9
            g.Roll(4);    // 2nd Strike from Frame 8 

            g.Roll(1);     // Normal pinsdown of next Frame 9
            g.Roll(2);    // 2nd Strike from Frame 8 

            Assert.AreEqual(156, g.Score());   //Expected is sum of above
        }

        [Test]
        public void ShouldReturnTrue_When10FrameHave2_Rolls()
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
            //g.Roll(0);

            g.Roll(0);
            g.Roll(1);

            g.Roll(7);
            g.Roll(3);

            g.Roll(6);
            g.Roll(4);

            g.Roll(10);
            //g.Roll(0);

            g.Roll(2);
            g.Roll(3);

            int result = g.Score();
            Assert.AreEqual(117, result);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            g = null;
        }
    }
}
