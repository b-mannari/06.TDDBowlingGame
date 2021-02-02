using System;
using System.Collections.Generic;

namespace TDDBowlingGame.Service
{
    public class Game
    {
        public int FrameNo = 0;
        public List<int> FrameScore = new List<int>();
        private readonly int[] Rolls = new int[24];
        private int CurrentRollNo = 0;

        public void Roll(int PinsDown)
        {
            if (CurrentRollNo >= 24)
            {
                throw new IndexOutOfRangeException("Game Over!!");
            }
            else
            {
                Rolls[CurrentRollNo] = PinsDown;

                if (PinsDown == 10)
                { Rolls[CurrentRollNo + 1] = 0; CurrentRollNo++; }

                CalculateScore();

                CurrentRollNo++;
            }
        } 

        public int CalculateScore()
        {
            int Index = 0; int Score = 0; FrameScore = new List<int>();
            for (int Frame = 0; Frame < 10; Frame++)
            {
                bool DoubleStrike = false; int PinsInFrame;
                if (IsStrike(Index)) // Strike
                {
                    if (IsDoubleStrike(Index)) DoubleStrike = true;

                    PinsInFrame = Rolls[Index + 1] + Rolls[Index + 2] + Rolls[Index + 3];

                    if (DoubleStrike)
                    { Score += 10 + Rolls[Index + 2] + Rolls[Index + 3] + Rolls[Index + 4]; }
                    else
                    { Score += 10 + Rolls[Index + 2] + Rolls[Index + 3]; }

                }
                else if (IsSpare(Index)) // Spare
                {
                    PinsInFrame = Rolls[Index + 1] + Rolls[Index + 2];
                    Score += 10 + Rolls[Index + 2];
                }
                else // Normal
                {
                    PinsInFrame = Rolls[Index] + Rolls[Index + 1];
                    Score += Rolls[Index] + Rolls[Index + 1];
                }

                if (PinsInFrame > 0 || Frame == 0) { FrameScore.Add(Score); }

                Index += 2;
            }
            FrameNo = FrameScore.Count - 1;

            return Score;
        }

        private bool IsStrike(int Index)
        {
            return (Rolls[Index] == 10);
        }
        private bool IsSpare(int Index)
        {
            return Rolls[Index] + Rolls[Index + 1] == 10;
        }
        private bool IsDoubleStrike(int Index)
        {
            return Rolls[Index] + Rolls[Index + 2] == 20;
        }
    }
}
