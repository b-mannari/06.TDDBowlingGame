namespace TDDBowlingGame.Service
{
    public class Game
    {
        private readonly int[] rolls = new int[20];
        private int CurrentRoll = 0;
        private int score = 0;

        public int[] Roll(int PinsDown)
        {
            rolls[CurrentRoll++] = PinsDown;
            return rolls;
        }

        public int Score()
        {
            int rollNo = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (rolls[rollNo] == 10) // Strike
                {
                    score += 10 + rolls[rollNo + 1] + rolls[rollNo + 2];
                    rollNo++;
                }
                else if (rolls[rollNo] + rolls[rollNo + 1] == 10) // Spare
                {
                    score += 10 + rolls[rollNo + 2];
                    rollNo += 2;
                }
                else
                {
                    score += rolls[rollNo] + rolls[rollNo + 1];
                    rollNo += 2;
                }
            }
            return score;
        }
    }
}
