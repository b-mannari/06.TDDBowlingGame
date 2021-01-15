using NUnit.Framework;
using TDDRockPaperScissor.Service;
using static TDDRockPaperScissor.Service.Shapes;

namespace TDDRockPaperScissor.Tests
{
    public class TDDRockPaperScissorTest
    {
        RockPaperScissor rps;
        [SetUp]
        public void Setup()
        {
            rps = new RockPaperScissor();
        }


        [Test]
        public void ShouldReturnTie_WhenPlayer1ChooseRockAndPlayer2ChooseRock()
        {
            GameResult actualResult = rps.GetTheWinner(Choices.Rock, Choices.Rock);
            Assert.AreEqual(GameResult.Tie, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer1Wins_WhenPlayer1ChooseRockAndPlayer2ChooseScissors()
        {
            GameResult actualResult = rps.GetTheWinner(Choices.Rock, Choices.Scissor);
            Assert.AreEqual(GameResult.Player1_Wins, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer2Wins_WhenPlayer1ChooseRockAndPlayer2ChoosePaper()
        {
            GameResult actualResult = rps.GetTheWinner(Choices.Rock, Choices.Paper);
            Assert.AreEqual(GameResult.Player2_Wins, actualResult);
        }



        [Test]
        public void ShouldReturnTie_WhenPlayer1ChoosePaperAndPlayer2ChoosePaper()
        {
            GameResult actualResult = rps.GetTheWinner(Choices.Paper, Choices.Paper);
            Assert.AreEqual(GameResult.Tie, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer1Wins_WhenPlayer1ChoosePaperAndPlayer2ChooseRock()
        {
            GameResult actualResult = rps.GetTheWinner(Choices.Paper, Choices.Rock);
            Assert.AreEqual(GameResult.Player1_Wins, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer2Wins_WhenPlayer1ChoosePaperAndPlayer2ChooseScissors()
        {
            GameResult actualResult = rps.GetTheWinner(Choices.Paper, Choices.Scissor);
            Assert.AreEqual(GameResult.Player2_Wins, actualResult);
        }




        [Test]
        public void ShouldReturnTie_WhenPlayer1ChooseScissorsAndPlayer2ChooseScissors()
        {
            GameResult actualResult = rps.GetTheWinner(Choices.Scissor, Choices.Scissor);
            Assert.AreEqual(GameResult.Tie, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer1Wins_WhenPlayer1ChooseScissorsAndPlayer2ChoosePaper()
        {
            GameResult actualResult = rps.GetTheWinner(Choices.Scissor, Choices.Paper);
            Assert.AreEqual(GameResult.Player1_Wins, actualResult);
        }
        [Test]
        public void ShouldReturnPlayer2Wins_WhenPlayer1ChooseScissorsAndPlayer2ChooseRock()
        {
            GameResult actualResult = rps.GetTheWinner(Choices.Scissor, Choices.Rock);
            Assert.AreEqual(GameResult.Player2_Wins, actualResult);
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