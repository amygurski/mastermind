using System;

namespace Game.Classes
{
    public class GameInterface
    {
        /// <summary>
        /// Prompts user on how they are doing. If they have won or lost, let the game know so it can end.
        /// </summary>
        /// <param name="matches">How many positions the user has correct</param>
        /// <param name="tries">Number of tries the user has left</param>
        /// <returns>bool isWinLose</returns>
        public void PrintWinLose(int matches, int tries)
        {
            switch (matches)
            {
                case 0:
                    Console.WriteLine("Couldn't be further from the answer!");
                    break;
                case 2:
                    Console.WriteLine("Getting close...");
                    break;
                case 3:
                    Console.WriteLine("So close, but no cigar!");
                    break;
                case 4:
                    Console.WriteLine($"You win! You did it in {10 - tries} tries.");
                    break;
            }

            //Out of guesses
            if (tries == 0) 
            {
                Console.WriteLine($"\nNice try but you lose!");
            }
        }

        /// <summary>
        /// Show + and - for how well the guess matches the solution
        /// </summary>
        public void PrintFeedback(string feedback)
        {
            Console.WriteLine("Code: " + feedback);
        }

        /// <summary>
        /// Get guess from the user. Includes validation.
        /// </summary>
        public int[] GetGuess()
        {

            int[] inputArr = new int[4];

            // Start validation loop
            // Keep prompting for guess until 4 numbers between 1-6 are entered 
            bool invalidInput = true;
            while (invalidInput)
            {
                Console.Write("\nWhat's your guess? ");
                string input = Console.ReadLine();

                if (input.Length != 4) //Wrong length
                {
                    Console.WriteLine("Try again. It's 4 digits long. (Example guess: 1234)");
                    invalidInput = true;
                }
                else if (!Int32.TryParse(input, out _)) //Not integers
                {
                    Console.WriteLine("Try again. This is not a number. (Example guess: 1234)");
                    invalidInput = true;
                }
                else
                {
                    char[] charNums = input.ToCharArray();
                    for (int i = 0; i < charNums.Length; i++)
                    {
                        inputArr[i] = int.Parse(charNums[i].ToString());
                        if (inputArr[i] < 1 || inputArr[i] > 6) //Out of bounds
                        {
                            Console.WriteLine("Try again. All digits must be from 1 to 6. (Example guess: 1234)");
                            invalidInput = true;
                            break;
                        }
                        invalidInput = false;
                    }
                }
            }
            return inputArr;
        }
    }
}
