using System;
using MasterMind.Classes;

namespace MasterMind
{
    public class Program
    {
        static void Main(string[] args)
        {

            /*
             * Create a C# console application that is a simple version of Mastermind. 
             * Criteria: 
             * 1. The randomly generated solution should be four (4) digits in length, with each digit ranging from 1 to 6.
             * 2. After the player enters a combination, a minus (-) sign should be printed for every digit that is correct but in the wrong position, 
             *    and a plus (+) sign should be printed for every digit that is both correct and in the correct position. 
             * 3. Print all plus signs first, all minus signs second, and nothing for incorrect digits. 
             * 4. The player has ten (10) attempts to guess the number correctly before receiving a message that they have lost.
            */

            MainMenu mm = new MainMenu();
            mm.DisplayMainMenu();
        }

        
    }
}
