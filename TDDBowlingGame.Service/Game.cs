using System;
using System.Collections.Generic;

namespace TDDBowlingGame.Service
{
    public class Game
    {
        public List<int> FrameScore = new List<int>();
        //public int CummulativeScore { get; set; }
        public string IsLastGame = "";
        private readonly int[] Rolls = new int[24];
        private int RollIdx = 0;
        private int Idx = 0;
        private int Score = 0;
        public int FrameNo = 0;

        public void Roll(int PinsDown)
        {
            Rolls[RollIdx] = PinsDown;

            if (PinsDown == 10)
            { Rolls[RollIdx + 1] = 0; RollIdx++; }

            CalculateScore();

            RollIdx++;
        }

        public int CalculateScore()
        {
            Idx = 0; Score = 0; FrameScore = new List<int>();
            for (int Frame = 0; Frame < 10; Frame++)
            {
                bool DoubleStrike = false; int PinsInFrame;
                if (IsStrike()) // Strike
                {
                    if (IsDoubleStrike()) DoubleStrike = true;

                    PinsInFrame = Rolls[Idx + 1] + Rolls[Idx + 2] + Rolls[Idx + 3];

                    if (DoubleStrike)
                    { Score += 10 + Rolls[Idx + 2] + Rolls[Idx + 3] + Rolls[Idx + 4]; }
                    else
                    { Score += 10 + Rolls[Idx + 2] + Rolls[Idx + 3]; }

                }
                else if (IsSpare()) // Spare
                {
                    PinsInFrame = Rolls[Idx + 1] + Rolls[Idx + 2];
                    Score += 10 + Rolls[Idx + 2];
                }
                else // Normal
                {
                    PinsInFrame = Rolls[Idx] + Rolls[Idx + 1];
                    Score += Rolls[Idx] + Rolls[Idx + 1];
                }

                if (PinsInFrame > 0 || Frame == 0) { FrameScore.Add(Score); }

                Idx += 2;
            }
            //CummulativeScore = score;
            FrameNo = FrameScore.Count - 1;

            return Score;
        }

        private bool IsStrike()
        {
            return (Rolls[Idx] == 10);
        }
        private bool IsSpare()
        {
            return Rolls[Idx] + Rolls[Idx + 1] == 10;
        }
        private bool IsDoubleStrike()
        {
            return Rolls[Idx] + Rolls[Idx + 2] == 20;
        }
    }
}
