using System;
using System.Collections.Generic;

namespace TDDBowlingGame.Service
{
    public class Game
    {
        public int FrameNo = 0;
        public List<int> FrameScore = new List<int>();
        private readonly int[] Rolls = new int[24];
        private int CurrentRollNo = 0; private int Score = 0;

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
            int Index = 0; FrameScore = new List<int>(); Score = 0;
            for (int Frame = 0; Frame < 10; Frame++)
            {
                bool DoubleStrike = false; int PinsInFrame;
                if (IsStrike(Index)) 
                {
                    if (IsDoubleStrike(Index)) DoubleStrike = true;

                    PinsInFrame = Rolls[Index + 1] + Rolls[Index + 2] + Rolls[Index + 3];
                    AddScore(DoubleStrike, "strike", Index);
                }
                else if (IsSpare(Index)) 
                {
                    PinsInFrame = Rolls[Index + 1] + Rolls[Index + 2];
                    AddScore(DoubleStrike, "spare", Index);
                }
                else  
                {
                    PinsInFrame = Rolls[Index] + Rolls[Index + 1];
                    AddScore(DoubleStrike, "", Index);
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

        private int AddScore(bool doubleStrike, string type, int index)
        {
            if (type == "strike")
            {
                if (doubleStrike)
                { Score += 10 + Rolls[index + 2] + Rolls[index + 3] + Rolls[index + 4]; }
                else
                { Score += 10 + Rolls[index + 2] + Rolls[index + 3]; }
            }
            else if (type == "spare")
            {
                Score += 10 + Rolls[index + 2];
            }
            else
            {
                Score += Rolls[index] + Rolls[index + 1];
            }
            return Score;
        }
    }
}
