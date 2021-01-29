using System.Collections.Generic;

namespace TDDBowlingGame.Service
{
    public class Game
    {
        private readonly int[] rolls = new int[24];
        public List<int> frameScore = new List<int>();
        private int CurrentRoll = 0; 
        private int score = 0;
        int rollNo = 0; 
        public int CummulativeScore { get; set; }

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
            rollNo = 0; score = 0; frameScore = new List<int>();
            for (int x = 0; x < 10; x++)
            {
                bool doubleStrike = false; int framePinsCount;
                if (rolls[rollNo] == 10) // Strike
                {
                    if (rolls[rollNo] + rolls[rollNo + 2] == 20) doubleStrike = true;

                    framePinsCount = rolls[rollNo + 1] + rolls[rollNo + 2] + rolls[rollNo + 3];

                    if (doubleStrike)
                    { score += 10 + rolls[rollNo + 2] + rolls[rollNo + 3] + rolls[rollNo + 4]; }
                    else
                    { score += 10 + rolls[rollNo + 2] + rolls[rollNo + 3]; }

                }
                else if (rolls[rollNo] + rolls[rollNo + 1] == 10) // Spare
                {
                    framePinsCount = rolls[rollNo + 1] + rolls[rollNo + 2];
                    score += 10 + rolls[rollNo + 2];
                }
                else // Normal
                {
                    framePinsCount = rolls[rollNo] + rolls[rollNo + 1];
                    score += rolls[rollNo] + rolls[rollNo + 1];
                }
                if (framePinsCount > 0) frameScore.Add(score);
                rollNo += 2;
            }
            CummulativeScore = score;

            return score;
        }
    }
}
