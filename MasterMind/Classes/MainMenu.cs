﻿using System;

namespace Game.Classes
{
    public class MainMenu
    {
        public void DisplayMainMenu()
        {
            // Create the menu loop
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
                        //Display instructions
                        Console.Clear(); 
                        Title();
                        PrintInstructions();
                        break;
                    case "2":
                        //Play game
                        Console.Clear(); 
                        Title();
                        Console.WriteLine("\nI have a number in mind...");
                        MasterMind game = new MasterMind(new GameInterface());
                        game.Play();
                        break;
                    case "3":
                        //Exit
                        keepGoing = false;
                        continue;
                    //TODO: Case 4: View stats (plays, wins losses)
                    default:
                        Console.WriteLine("Invalid Menu Option. Please try again.");
                        break;
                }

                //Wait for user to press enter before continuing
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
