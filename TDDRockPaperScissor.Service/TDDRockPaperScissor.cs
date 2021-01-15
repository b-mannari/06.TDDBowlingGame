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

        public GameResult GetTheRoundWinner(GameResult outCome1, GameResult outCome2, GameResult outCome3)
        {
            if (outCome1.Equals(GameResult.Player1_Wins) && outCome2.Equals(GameResult.Player1_Wins)
                && (outCome3.Equals(GameResult.Player1_Wins) || outCome3.Equals(GameResult.Player2_Wins)))
            {
                return GameResult.Player1_Wins;
            }
            if (outCome1.Equals(GameResult.Player1_Wins) && outCome2.Equals(GameResult.Tie) && outCome3.Equals(GameResult.Tie))
            {
                return GameResult.Player1_Wins;
            }


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
    }
}