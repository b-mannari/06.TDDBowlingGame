using System;

namespace TDDRockPaperScissor.Service
{
    public class Shapes
    {
        public enum Choices
        {
            Rock, Paper, Scissor
        }

        public enum GameResult
        {
            Tie, Player1_Wins, Player2_Wins
        }
    }
}