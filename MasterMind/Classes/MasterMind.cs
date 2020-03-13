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

        /// <summary>
        /// Play the game. 
        /// Gets the solution and gives the user NumberOfTries times to guess
        /// </summary>
        public void Play()
        {
            int[] guess;
            int[] solution = GenerateSecretCode();

            while (NumberOfTries > 0) 
            {
                guess = GI.GetGuess();
                NumberOfTries--;
                int result = CheckGuess(guess, solution); //Get how well the guess matches the solution
                GI.PrintWinLose(result, NumberOfTries); //Let the user know how they are doing
                //If all 4 numbers match, they win so break out of play loop
                if (result == 4)
                {
                    break;
                }
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
                //Check if guess has same position and value as solution
                if (guess[i] == modifiedSolution[i]) 
                {
                    feedback = feedback.Insert(0, "+"); //+'s get printed first
                    fourToWin++;
                    modifiedSolution[i] = 0;
                    continue;
                }
                else //check if guess has same value as a number in the solution, but in a different position
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

            GI.PrintFeedback(feedback); //Have game interface print the + and - code indicating how they did

            return fourToWin;
        }

        /// <summary>
        /// Generate the solution, which is a 4 digit random number
        /// Each number is 1-6
        /// </summary>
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

        //Get a random number
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}