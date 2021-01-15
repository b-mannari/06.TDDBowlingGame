using NUnit.Framework;
using TDDRockPaperScissor.Service;
using static TDDRockPaperScissor.Service.Shapes;

namespace TDDRockPaperScissor.Tests
{
    public class TDDRockPaperScissorTest
    {
        RockPaperScissor rps; Choices p1Choice; Choices p2Choice;
        [SetUp]
        public void Setup()
        {
            rps = new RockPaperScissor();
        }


        [Test]
        public void ShouldReturnTie_WhenPlayer1ChooseRockAndPlayer2ChooseRock()
        {
            p1Choice = Choices.Rock; p2Choice = Choices.Rock; GameResult expectedResult = GameResult.Tie;
            GameResult actualResult = rps.GetTheWinner(p1Choice, p2Choice);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer1Wins_WhenPlayer1ChooseRockAndPlayer2ChooseScissors()
        {
            p1Choice = Choices.Rock; p2Choice = Choices.Scissor; GameResult expectedResult = GameResult.Player1_Wins;
            GameResult actualResult = rps.GetTheWinner(p1Choice, p2Choice);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer2Wins_WhenPlayer1ChooseRockAndPlayer2ChoosePaper()
        {
            p1Choice = Choices.Rock; p2Choice = Choices.Paper; GameResult expectedResult = GameResult.Player2_Wins;
            GameResult actualResult = rps.GetTheWinner(p1Choice, p2Choice);
            Assert.AreEqual(expectedResult, actualResult);
        }



        [Test]
        public void ShouldReturnTie_WhenPlayer1ChoosePaperAndPlayer2ChoosePaper()
        {
            p1Choice = Choices.Paper; p2Choice = Choices.Paper; GameResult expectedResult = GameResult.Tie;
            GameResult actualResult = rps.GetTheWinner(p1Choice, p2Choice);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer1Wins_WhenPlayer1ChoosePaperAndPlayer2ChooseRock()
        {
            p1Choice = Choices.Paper; p2Choice = Choices.Rock; GameResult expectedResult = GameResult.Player1_Wins;
            GameResult actualResult = rps.GetTheWinner(p1Choice, p2Choice);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer2Wins_WhenPlayer1ChoosePaperAndPlayer2ChooseScissors()
        {
            p1Choice = Choices.Paper; p2Choice = Choices.Scissor; GameResult expectedResult = GameResult.Player2_Wins;
            GameResult actualResult = rps.GetTheWinner(p1Choice, p2Choice);
            Assert.AreEqual(expectedResult, actualResult);
        }




        [Test]
        public void ShouldReturnTie_WhenPlayer1ChooseScissorsAndPlayer2ChooseScissors()
        {
            p1Choice = Choices.Scissor; p2Choice = Choices.Scissor; GameResult expectedResult = GameResult.Tie;
            GameResult actualResult = rps.GetTheWinner(p1Choice, p2Choice);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer1Wins_WhenPlayer1ChooseScissorsAndPlayer2ChoosePaper()
        {
            p1Choice = Choices.Scissor; p2Choice = Choices.Paper; GameResult expectedResult = GameResult.Player1_Wins;
            GameResult actualResult = rps.GetTheWinner(p1Choice, p2Choice);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer2Wins_WhenPlayer1ChooseScissorsAndPlayer2ChooseRock()
        {
            p1Choice = Choices.Scissor; p2Choice = Choices.Rock; GameResult expectedResult = GameResult.Player2_Wins;
            GameResult actualResult = rps.GetTheWinner(p1Choice, p2Choice);
            Assert.AreEqual(expectedResult, actualResult);
        }





        // //
        [Test]
        public void ShouldReturnTie_WhenResultsAreTieForAll3Rounds()
        {
            GameResult result = rps.GetTheRoundWinner(GameResult.Tie, GameResult.Tie, GameResult.Tie);
            Assert.AreEqual(GameResult.Tie, result);
        }

        [Test]
        public void ShouldReturnPlayer1Wins_WhenPlayer1IstheWinnerForAll3Rounds()
        {
            GameResult result = rps.GetTheRoundWinner(GameResult.Player1_Wins, GameResult.Player1_Wins, GameResult.Player1_Wins);
            Assert.AreEqual(GameResult.Player1_Wins, result);
        }
        [Test]
        public void ShouldReturnPlayer1Wins_WhenPlayer1IstheWinnerFor2RoundsOutOf3()
        {
            GameResult result = rps.GetTheRoundWinner(GameResult.Player1_Wins, GameResult.Player1_Wins, GameResult.Player2_Wins);
            Assert.AreEqual(GameResult.Player1_Wins, result);
        }
        [Test]
        public void ShouldReturnPlayer1Wins_WhenPlayer1IstheWinnerFor1RoundAndOther2AreTie()
        {
            GameResult result = rps.GetTheRoundWinner(GameResult.Player1_Wins, GameResult.Tie, GameResult.Tie);
            Assert.AreEqual(GameResult.Player1_Wins, result);
        }



        [Test]
        public void ShouldReturnPlayer2Wins_WhenPlayer2IstheWinnerForAll3Rounds()
        {
            GameResult result = rps.GetTheRoundWinner(GameResult.Player2_Wins, GameResult.Player2_Wins, GameResult.Player2_Wins);
            Assert.AreEqual(GameResult.Player2_Wins, result);
        }
        [Test]
        public void ShouldReturnPlayer2Wins_WhenPlayer2IstheWinnerFor2RoundsOutOf3()
        {
            GameResult result = rps.GetTheRoundWinner(GameResult.Player2_Wins, GameResult.Player2_Wins, GameResult.Player1_Wins);
            Assert.AreEqual(GameResult.Player2_Wins, result);
        }
        [Test]
        public void ShouldReturnPlayer2Wins_WhenPlayer2IstheWinnerFor1RoundAndOther2AreTie()
        {
            GameResult result = rps.GetTheRoundWinner(GameResult.Player2_Wins, GameResult.Tie, GameResult.Tie);
            Assert.AreEqual(GameResult.Player2_Wins, result);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            rps = null;
        }
    }
}