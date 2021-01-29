using System.Collections.Generic;

namespace TDDBowlingGame.Service
{
    public class Game
    {
        public List<int> frameScore = new List<int>();
        public int CummulativeScore { get; set; }

        private readonly int[] rolls = new int[24];
        private int CurrentRoll = 0;
        private int idx = 0;
        private int score = 0;

        public void Roll(int PinsDown)
        {
            rolls[CurrentRoll] = PinsDown;

            if (PinsDown == 10)
            { rolls[CurrentRoll + 1] = 0; CurrentRoll++; }

            CummulativeScore = CalculateScore();
            CurrentRoll++;
        }

        public int CalculateScore()
        {
            idx = 0; score = 0; frameScore = new List<int>();
            for (int x = 0; x < 10; x++)
            {
                bool doubleStrike = false; int framePinsCount;
                if (rolls[idx] == 10) // Strike
                {
                    if (rolls[idx] + rolls[idx + 2] == 20) doubleStrike = true;

                    framePinsCount = rolls[idx + 1] + rolls[idx + 2] + rolls[idx + 3];

                    if (doubleStrike)
                    { score += 10 + rolls[idx + 2] + rolls[idx + 3] + rolls[idx + 4]; }
                    else
                    { score += 10 + rolls[idx + 2] + rolls[idx + 3]; }

                }
                else if (rolls[idx] + rolls[idx + 1] == 10) // Spare
                {
                    framePinsCount = rolls[idx + 1] + rolls[idx + 2];
                    score += 10 + rolls[idx + 2];
                }
                else // Normal
                {
                    framePinsCount = rolls[idx] + rolls[idx + 1];
                    score += rolls[idx] + rolls[idx + 1];
                }
                if (framePinsCount > 0) 
                    frameScore.Add(score);

                idx += 2;
            }
            CummulativeScore = score;

            return score;
        }
    }
}
