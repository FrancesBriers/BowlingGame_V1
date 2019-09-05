 using System;

namespace BowlingGame
{
    class Program
    {
        static void Mains(string[] args)
        {
           var bowlingGame = new BowlingGame();
        }

        public class BowlingGame
        {
            int[] _rolls = new int[21];
            private int _currentRoll = 0;

            public void Roll(int pins)
            {
                _rolls[_currentRoll++] = pins;
                //_score += pins;
            }

            public int Score()
            {
                int score = 0;
                int firstInFrame = 0;
                for (int frame = 0; frame <10; frame++)
                {
                    if (IsStrike(firstInFrame))
                    {
                        score += 10 + NextTwoBallsAfterStrike(firstInFrame);
                        firstInFrame++;
                    }

                    else if (IsSpare(firstInFrame))
                    {
                        score += 10 + NextBallAfterSpare(firstInFrame);
                        firstInFrame += 2;
                    }
                    else
                    {
                        score += TwoBallsInFrame(firstInFrame);
                        firstInFrame += 2;
                    }
                   
                }
                return score;
            }

            private int TwoBallsInFrame(int firstInFrame)
            {
                return _rolls[firstInFrame] + _rolls[firstInFrame + 1];
            }

            private int NextBallAfterSpare(int firstInFrame)
            {
                return _rolls[firstInFrame + 2];
            }

            private bool IsStrike(int firstInFrame)
            {
                return _rolls[firstInFrame] == 10;
            }

            private bool IsSpare(int firstInFrame)
            {
                return _rolls[firstInFrame] + _rolls[firstInFrame + 1] == 10;
            }

            private int NextTwoBallsAfterStrike(int firstInFrame)
            {
                return _rolls[firstInFrame + 1] + _rolls[firstInFrame + 2];
            }
        }

    }
}
