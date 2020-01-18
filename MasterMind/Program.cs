using System;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fourRandomNumbers = new int[4]; //The number to be guessed
            int[] guessArray = new int[4]; //guesses stored as array
            int fullGuess = 0;
            int numberOfGuessesRemaining = 10;

            PrintInstructions();
                        
            //Generate 4 random numbers between 1 and 6 inclusive for the player to guess
            for (int i = 0; i < fourRandomNumbers.Length; i++)
            {
                fourRandomNumbers[i] = RandomNumber(1, 7);
                Console.Write(fourRandomNumbers[i]); //Just for debugging
            }

            // Have a counter for 10 guesses, working out 1 guess first
            //while (numberOfGuessesRemaining > 0)
            //{
                string playerInput = PlayerGuess();

                //Make sure player input meets criteria (4 integers between 1 and 6)

                //makes sure it's an int. I don't like that I have to assign an output since not using
                while (!int.TryParse(playerInput, out fullGuess))
                {
                    Console.WriteLine("This is not a number.");
                    playerInput = PlayerGuess();
                }

                //if it's not a 4 digit int, error
                while (playerInput.Length != 4)
                {
                    Console.WriteLine("Please enter 4 digits.");
                    playerInput = PlayerGuess();
                }

            //Convert to an int array but if any digit isn't between 1 and 6, reprompt.
            //for (int i = 0; i < guessArray.Length; i++)
            //{
            //    guessArray[i] = int.Parse(playerInput[i]);
            //}

            numberOfGuessesRemaining--;
            //}

            //Print outcome:
            //if identical, win
            //Check if each digit exists in array and at same position = +
            //Exists in array but at different position = -
            //Blank if neither

            //If wrong after 10 tries, you lose.
        }

        static public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        static public void PrintInstructions()
        {
            Console.WriteLine("\nMasterMind Instructions:\nI'm thinking of a 4 digit number.\nEach number is between 1 and 6.\nYou will have 10 tries to solve it.\n");
            Console.WriteLine("(-) indicates that a digit is correct, but in the wrong position.\n(+) indicates that both the digit and position are correct.\n");

        }

        static public string PlayerGuess()
        {
            Console.WriteLine("\nWhat's your guess?");
            return Console.ReadLine();
        }
    }
}
