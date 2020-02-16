using System;

namespace MasterMind.Classes
{
    class UI
    {
        static public void Title()
        {
            string title = @" 
              __  __           _            __  __ _           _ 
             |  \/  |         | |          |  \/  (_)         | |
             | \  / | __ _ ___| |_ ___ _ __| \  / |_ _ __   __| |
             | |\/| |/ _` / __| __/ _ \ '__| |\/| | | '_ \ / _` |
             | |  | | (_| \__ \ ||  __/ |  | |  | | | | | | (_| |
             |_|  |_|\__,_|___/\__\___|_|  |_|  |_|_|_| |_|\__,_|";
            Console.WriteLine(title);
        }
        static public void PrintInstructions()
        {
            Console.WriteLine("\nInstructions:\nI'm thinking of a 4 digit number.\nEach number is between 1 and 6.\nYou have 10 tries to guess the correct number.\n");
            Console.WriteLine("(+) indicates that both the digit and position are correct.\n(-) indicates that a digit is correct, but in the wrong position.\n");

        }

        static public void PrintWinLose(int matches, int tries)
        {
            if (matches == 4) //Player guess matches answer
            {
                Console.WriteLine($"You win! You did it in {10 - tries} tries.");
            }

            if (tries == 0) //Out of guesses
            {
                Console.WriteLine($"\nNice try but you lose!");
            }
        }

        static public void PrintFeedback(string feedback)
        {
            Console.WriteLine(feedback);
        }

        static public int[] GetGuess()
        {

            int[] inputArr = new int[4];

            Console.Write("\nWhat's your guess? ");
            string input = Console.ReadLine();


            if (input.Length != 4) //Wrong length
            {
                Console.WriteLine("Try again. It's 4 digits long. (Example guess: 1234)");
                GetGuess();
            }
            else if (!Int32.TryParse(input, out _)) //Not integers
            {
                Console.WriteLine("Try again. This is not a number. (Example guess: 1234)");
                GetGuess();
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
                        GetGuess();
                        break;
                    }
                }
            }
            return inputArr;
        }
    }
}
