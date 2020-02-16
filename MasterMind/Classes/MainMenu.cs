using System;

namespace MasterMind.Classes
{
    public class MainMenu
    {
        public void DisplayMainMenu()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Clear();
                Title();
                Console.WriteLine("\n1) Instructions");
                Console.WriteLine("2) Let's Play"); 
                Console.WriteLine("3) Exit");
                Console.Write("Please Enter Selection: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear(); 
                        Title();
                        PrintInstructions();
                        break;
                    case "2":
                        Console.Clear(); 
                        Title();
                        Console.WriteLine("\nI have a number in mind...");
                        Game game = new Game(new GameInterface());
                        game.Play();
                        break;
                    case "3":
                        keepGoing = false;
                        break;
                        //TODO: Doesn't exit after a win or 10 loses
                    //TODO: Case 4: View stats (plays, wins losses)
                    default:
                        Console.WriteLine("Invalid Menu Option. Please try again.");
                        break;
                }
                Console.ReadLine();
            }
        }

        public void Title()
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
        public void PrintInstructions()
        {
            Console.WriteLine("\nHow to play:\n");
            Console.WriteLine("I'm thinking of a 4 digit number.\nEach number is between 1 and 6.\nYou have 10 tries to guess the correct number.\n");
            Console.WriteLine("(+) indicates that both the digit and position are correct.\n(-) indicates that a digit is correct, but in the wrong position.\n");
            Console.WriteLine("Have fun and good luck!");

        }
    }
}
