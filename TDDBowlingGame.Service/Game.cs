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

        public int FrameScore()
        {
            int index = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (rolls[index] == 10)
                {
                    score += 10 + rolls[index + 1] + rolls[index + 2];
                    index++;
                }
                else if (rolls[index] + rolls[index + 1] == 10)
                {
                    score += 10 + rolls[index + 2];
                    index += 2;
                }
                else
                {
                    score += rolls[index] + rolls[index + 1];
                    index += 2;
                }
            }
            return score;
        }
    }
}
