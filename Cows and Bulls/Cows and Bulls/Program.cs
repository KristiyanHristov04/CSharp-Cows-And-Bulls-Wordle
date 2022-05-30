using System;
using System.Collections.Generic;

namespace Cows_and_Bulls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[] { "pizza", "movie", "horse", "agent", "adult", "apple", "basis", "beach", "cycle", "crown", "doubt", "donut", "mouse", "plate" };
            Random random = new Random();
            int randomWordGenerator = random.Next(0, words.Length);
            int leftAttempts = 5;
            string currentWordToBeFound = words[randomWordGenerator];

            int cows = 0;
            int bulls = 0;

            Console.Write("Do you want to show all characters that are on right place(bulls)?\nPress [y] or [n]: ");
            char difficulty = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();

            if (Convert.ToString(difficulty).ToLower() == "n")
            {
                while (leftAttempts > 0)
                {
                    Console.Write("Please enter a word: ");
                    string input = Console.ReadLine();
                    while (input.Length != 5)
                    {
                        Console.WriteLine("Please insert a word that is 5 characters long!");
                        input = Console.ReadLine();
                    }

                    if (input == currentWordToBeFound)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Congratulations, you found the word!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < input.Length; i++)
                        {
                            for (int j = 0; j < currentWordToBeFound.Length; j++)
                            {
                                if (Convert.ToString(input[i]).ToLower() == Convert.ToString(currentWordToBeFound[j]).ToLower() && i == j)//If statement that checks if there is a bull
                                {
                                    bulls++;
                                }
                                if (Convert.ToString(input[i]).ToLower() == Convert.ToString(currentWordToBeFound[j]).ToLower() && i != j)//If statement that checks if there is a cow
                                {
                                    cows++;
                                }
                            }
                        }
                        Console.WriteLine($"Cows {cows} Bulls {bulls}");
                        bulls = 0;
                        cows = 0;
                        leftAttempts--;
                        Console.WriteLine($"You have {leftAttempts} attempts left.");
                        Console.WriteLine();
                    }
                }
            }
            else if (Convert.ToString(difficulty).ToLower() == "y")
            {
                while (leftAttempts > 0)
                {
                    List<char> bullsInWord = new List<char>();
                    Console.Write("Please enter a word: ");
                    string input = Console.ReadLine();
                    while (input.Length != 5)
                    {
                        Console.WriteLine("Please insert a word that is 5 characters long!");
                        input = Console.ReadLine();
                    }

                    if (input == currentWordToBeFound)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Congratulations, you found the word!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < input.Length; i++)
                        {
                            for (int j = 0; j < currentWordToBeFound.Length; j++)
                            {
                                if (Convert.ToString(input[i]).ToLower() == Convert.ToString(currentWordToBeFound[j]).ToLower() && i == j)//If statement that checks if there is a bull
                                {
                                    bulls++;
                                    bullsInWord.Add(input[i]);
                                }
                                if (Convert.ToString(input[i]).ToLower() == Convert.ToString(currentWordToBeFound[j]).ToLower() && i != j)//If statement that checks if there is a cow
                                {
                                    cows++;
                                }
                            }
                        }
                        Console.WriteLine($"Cows {cows} Bulls {bulls}");
                        foreach (var bull in bullsInWord)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(bull + " ");
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine();
                        bulls = 0;
                        cows = 0;
                        leftAttempts--;
                        Console.WriteLine($"You have {leftAttempts} attempts left.");
                        bullsInWord = null;
                        Console.WriteLine();
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The word was [{currentWordToBeFound}]");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
