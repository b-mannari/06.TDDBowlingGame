using static TDDRockPaperScissor.Service.Shapes;

namespace TDDRockPaperScissor.Service
{
    public class RockPaperScissor
    {
        public GameResult GetTheWinner(Choices p1Choice, Choices p2Choice)
        {
            if (p1Choice.Equals(p2Choice))
            {
                return GameResult.Tie;
            }

            if (p1Choice.Equals(Choices.Rock) && p2Choice.Equals(Choices.Paper) ||
                p1Choice.Equals(Choices.Paper) && p2Choice.Equals(Choices.Scissor) ||
                p1Choice.Equals(Choices.Scissor) && p2Choice.Equals(Choices.Rock))
            {
                return GameResult.Player2_Wins;
            }

            return GameResult.Player1_Wins;
        }

        public GameResult GetTheRoundWinner_old(GameResult outCome1, GameResult outCome2, GameResult outCome3)
        {
            //This code is for Player 1
            if (outCome1.Equals(GameResult.Player1_Wins) && outCome2.Equals(GameResult.Player1_Wins)
                && (outCome3.Equals(GameResult.Player1_Wins) || outCome3.Equals(GameResult.Player2_Wins)))
            {
                return GameResult.Player1_Wins;
            }
            if (outCome1.Equals(GameResult.Player1_Wins) && outCome2.Equals(GameResult.Tie) && outCome3.Equals(GameResult.Tie))
            {
                return GameResult.Player1_Wins;
            }

            //This code is for Player 2
            if (outCome1.Equals(GameResult.Player2_Wins) && outCome2.Equals(GameResult.Player2_Wins) &&
                (outCome3.Equals(GameResult.Player2_Wins) || outCome3.Equals(GameResult.Player1_Wins)))
            {
                return GameResult.Player2_Wins;
            }
            if (outCome1.Equals(GameResult.Player2_Wins) && outCome2.Equals(GameResult.Tie) && outCome3.Equals(GameResult.Tie))
            {
                return GameResult.Player2_Wins;
            }

            return GameResult.Tie;
        }

        public GameResult GetTheRoundWinner(GameResult Outcome1, GameResult Outcome2, GameResult Outcome3)
        {
            int Player1WinningCount = 0;
            int Player2WinningCount = 0;

            if (Outcome1.Equals(GameResult.Player1_Wins)) Player1WinningCount++;

            if (Outcome2.Equals(GameResult.Player1_Wins)) Player1WinningCount++;

            if (Outcome1.Equals(GameResult.Player2_Wins)) Player2WinningCount++;

            if (Outcome2.Equals(GameResult.Player2_Wins)) Player2WinningCount++;

            if (Player1WinningCount > Player2WinningCount)
            {
                return GameResult.Player1_Wins;
            }
            else if (Player2WinningCount > Player1WinningCount)
            {
                return GameResult.Player2_Wins;
            }
            return GameResult.Tie;
        }
    }
}