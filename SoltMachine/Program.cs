using System;
using System.Text.RegularExpressions;

namespace SoltMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Slot Machine Game");

            const int NUMBER_OF_ROWS = 3;
            const int NUMBER_OF_COLUMNS = 3;
            const int WINNINGS = 1;
            const int PLAYER_BALANCE = 100;
            
            Random random = new Random();

            int availableBalance = PLAYER_BALANCE;

            bool gameIsOn = true;
            bool matchFound = false;
            

            while (gameIsOn)
            {
                Console.WriteLine($"Your available balance is £{availableBalance}.");
                
                Console.Write("How much would you like to bet? ");
                string bet = Console.ReadLine();
                
                if (!Regex.IsMatch(bet, @"^\d+$"))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }
                int playerBet = int.Parse(bet);
                
                if (playerBet > availableBalance)
                {
                    Console.WriteLine("Not enough cash ");
                   
                }
                else
                {

                    Console.WriteLine($"£{playerBet} bet locked in.");

                    availableBalance -= playerBet;

                    int[,] numbers = new int[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];


                    for (int i = 0; i < numbers.GetLength(0); i++)
                    {
                        for (int j = 0; j < numbers.GetLength(1); j++)
                        {
                            numbers[i, j] = random.Next(1, 10);
                        }
                    }

                    Console.WriteLine("Slot Numbers:");
                    
                    for (int i = 0; i < numbers.GetLength(0); i++)
                    {
                        for (int j = 0; j < numbers.GetLength(1); j++)
                        {
                            Console.Write(numbers[i, j] + " ");
                        }

                        Console.WriteLine();
                    }

                    if (availableBalance == 0)
                    {
                        Console.WriteLine("No funds left you lose.");
                        break;
                    }


                    for (int i = 0; i < NUMBER_OF_ROWS; i++)
                    {
                       
                        if (numbers[i, 0] == numbers[i, 1] && numbers[i, 1] == numbers[i, 2])
                        {
                            availableBalance += WINNINGS;
                            Console.WriteLine($"Matching numbers found you won £1.");
                            matchFound = true;
                        }

                    }

                    // vertical
                    for (int j = 0; j < NUMBER_OF_COLUMNS; j++)
                    {
                        if (numbers[0, j] == numbers[1, j] && numbers[1, j] == numbers[2, j])
                        {
                            availableBalance += WINNINGS;
                            Console.WriteLine($"Matching numbers found you won £1.");
                            matchFound = true;
                        }

                    }

                    // diagonal
                    if (numbers[0, 0] == numbers[1, 1] && numbers[1, 1] == numbers[2, 2])
                    {
                        Console.WriteLine($"Matching numbers found you won £1.");
                        availableBalance += WINNINGS;
                        matchFound = true;
                    }

                    if (numbers[0, 2] == numbers[1, 1] && numbers[1, 1] == numbers[2, 0])
                    {
                        Console.WriteLine($"Matching numbers found you won £1.");
                        availableBalance += WINNINGS;
                        matchFound = true;
                    }
                    
                    if (matchFound)
                    {
                        availableBalance +=  playerBet;
                    }
                    
                    Console.WriteLine($"Your remaining balance is £{availableBalance}");

                }
            }
        }
    }
}