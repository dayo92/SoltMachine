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
            const int MIN_RANDOM_NUMBER = 1;
            const int MAX_RANDOM_NUMBER = 10;
            
            Random random = new Random();

            int availableBalance = PLAYER_BALANCE;

            bool gameIsOn = true;
            bool matchFound = false;
            

            while (gameIsOn)
            {
                Console.WriteLine($"Your available balance is £{availableBalance}.");
                Console.Write("How much would you like to bet? ");
                
                string bet = Console.ReadLine();
                
                if (!int.TryParse(bet, out int playerBet))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }
                
                if (playerBet > availableBalance)
                {
                    Console.WriteLine("Not enough cash. Please try again,");
                    continue;
                }
                

                    Console.WriteLine($"£{playerBet} bet locked in.");

                    availableBalance -= playerBet;

                    int[,] numbers = new int[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];


                    for (int i = 0; i < numbers.GetLength(0); i++)
                    {
                        for (int j = 0; j < numbers.GetLength(1); j++)
                        {
                            numbers[i, j] = random.Next(MIN_RANDOM_NUMBER, MAX_RANDOM_NUMBER);
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
                    

                    //Row
                    for (int row = 0; row < NUMBER_OF_ROWS; row++)
                    {
                        bool rowMatch = true;

                        for (int col = 1; col < NUMBER_OF_COLUMNS; col++)
                        {
                            if (numbers[row, col] != numbers[row, 0])
                            {
                                rowMatch = false;
                                break;
                            }
                        }
                        
                        if (rowMatch)
                        {
                            availableBalance += WINNINGS;
                            Console.WriteLine($"Row match you won £{WINNINGS}.");
                            matchFound = true;
                        }
                    }
                    
                    //Column
                    for (int col = 0; col < NUMBER_OF_COLUMNS; col++)
                    {
                        bool columnMatch = true;

                        for (int row = 1; row < NUMBER_OF_ROWS; row++)
                        {
                            if (numbers[row, col] != numbers[0, col])
                            {
                                columnMatch = false;
                                break;
                            }
                        }

                        if (columnMatch)
                        {
                            availableBalance += WINNINGS;
                            Console.WriteLine($"Column match you won £{WINNINGS}.");
                            matchFound = true;
                        }
                    }
                    
                    
                    //Diagonal 
                    bool diagonalMatch1 = true;
                    for (int row = 1; row < NUMBER_OF_ROWS; row++)
                    {
                        if (numbers[row, row] != numbers[0, 0])
                        {
                            diagonalMatch1 = false;
                            break;
                        }
                    }

                    if (diagonalMatch1)
                    {
                        availableBalance += WINNINGS;
                        Console.WriteLine($"Diagonal Match1 you won £{WINNINGS}.");
                        matchFound = true;
                    }


                    bool diagonalMatch2 = true;
                    for (int row = 1; row < NUMBER_OF_ROWS; row++)
                    {
                        if (numbers[row, NUMBER_OF_ROWS - 1 - row] != numbers[0, NUMBER_OF_ROWS - 1])
                        {
                            diagonalMatch2 = false;
                            break;
                        }
                    }

                    if (diagonalMatch2)
                    {
                        availableBalance += WINNINGS;
                        Console.WriteLine($"Diagonal Match you won £{WINNINGS}.");
                        matchFound = true;
                    }

                    
                    if (matchFound)
                    {
                        availableBalance +=  playerBet;
                        matchFound = false;
                    }
                    if (availableBalance == 0 )
                    {
                        Console.WriteLine("No funds left you lose.");
                        break;
                    }
                  
                    Console.WriteLine($"Your remaining balance is £{availableBalance}");
                    
                    

                
            }
        }
    }
}