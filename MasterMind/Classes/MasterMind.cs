using System;

namespace Game.Classes
{
    public class MasterMind
    {
        public int NumberOfTries = 10;

        public GameInterface GI { get; }

        public MasterMind(GameInterface gi)
        {
            this.GI = gi;
        }

        public void Play()
        {
            int[] guess;
            int[] solution = GenerateSecretCode();

            while (NumberOfTries > 0) 
            {
                guess = GI.GetGuess();
                NumberOfTries--;
                int result = CheckGuess(guess, solution);
                GI.PrintWinLose(result, NumberOfTries);
            }
        }

        public int CheckGuess(int[] guess, int[] solution)
        {
            int fourToWin = 0;
            string feedback = "";

            //Copy solution to replace matched positions with 0's
            int[] modifiedSolution = new int[4];
            Array.Copy(solution, modifiedSolution, solution.Length);

            for (int i = 0; i < guess.Length; i++) //For each number in guess
            {

                if (guess[i] == modifiedSolution[i])
                {
                    feedback = feedback.Insert(0, "+"); //+'s get printed first
                    fourToWin++;
                    modifiedSolution[i] = 0;
                    continue;
                }
                else
                {
                    for (int j = 0; j < modifiedSolution.Length; j++) //For each number in solution
                    {
                        if (guess[i] == modifiedSolution[j] && guess[j] != modifiedSolution[j])
                        {
                            feedback += "-";
                            modifiedSolution[j] = 0;
                            break;
                        }
                    }
                }
            }

            GI.PrintFeedback(feedback);

            return fourToWin;
        }

        static int[] GenerateSecretCode()
        {
            int[] fourRandomNumbers = new int[4];
            for (int i = 0; i < 4; i++)
            {
                fourRandomNumbers[i] = RandomNumber(1, 7);
                //Console.Write(fourRandomNumbers[i]); //Just for debugging
            }
            return fourRandomNumbers;
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

    }
}