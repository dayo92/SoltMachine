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
            
            const char ROW_CHAR = 'R';
            const char COLUMN_CHAR = 'C';
            const char Diagonal_CHAR = 'D';
            
            bool rowMatch = true;
            bool columnMatch = true;
            bool diagonalMatch1 = true;
            bool diagonalMatch2 = true;
            
            Random random = new Random();

            int availableBalance = PLAYER_BALANCE;

            
            bool matchFound = false;
            

            while (true)
            {
                
                char gameChar = GetPlayerChar();
                
                Console.WriteLine($"Your available balance is £{availableBalance}.");
            

                int playerBet = 0;
                bool isValid = false;
                
                while (!isValid)
                {
                    Console.Write("How much would you like to bet? ");
                    string bet = Console.ReadLine();

                    isValid = int.TryParse(bet, out playerBet);
    
                    if (!isValid)
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                }
                
                
                if (playerBet > availableBalance)
                {
                    Console.WriteLine("Not enough cash. Please try again,");
                    continue;
                }
                

                Console.WriteLine($"£{playerBet} bet locked in.");

                availableBalance -= playerBet;

                int[,] numbers = new int[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];

                    
                for (int i = 0; i < NUMBER_OF_ROWS; i++)
                {
                    for (int j = 0; j < NUMBER_OF_COLUMNS; j++)
                    {
                        numbers[i, j] = random.Next(MIN_RANDOM_NUMBER, MAX_RANDOM_NUMBER);
                    }
                }
                    

                if (gameChar == ROW_CHAR)
                {
                    Console.WriteLine("Enter the row number (1, 2, or 3) you want to check:");
                    
                    if (!int.TryParse(Console.ReadLine(), out int selectedRow) || selectedRow < 1 || selectedRow > NUMBER_OF_ROWS)
                    {
                        Console.WriteLine("Invalid row number. Please try again.");
                        continue;
                    }
                    
                    //Row
                    
                    Console.WriteLine(1+" here");
                    matchFound = CheckRowMatch(numbers, selectedRow);
                    
                }
                
                

                if (gameChar == COLUMN_CHAR)
                {
                    Console.WriteLine("Enter the column number (1, 2, or 3) you want to check:");
                    
                    if (!int.TryParse(Console.ReadLine(), out int selectedCol) || selectedCol < 1 || selectedCol > NUMBER_OF_COLUMNS)
                    {
                        Console.WriteLine("Invalid row number. Please try again.");
                        continue;
                    }
                    
                    //Column

                    matchFound = CheckColumnMatch(numbers, selectedCol);

                }


                if (gameChar == Diagonal_CHAR)
                {
                    // Diagonal 1
                    
                    matchFound = CheckDiagonalMatch1(numbers);
               

                    // Diagonal 2
                    
                    matchFound = CheckDiagonalMatch2(numbers);
                    
                }
                    
                    
                if (matchFound)
                {
                    availableBalance += playerBet + WINNINGS;
                    matchFound = false;
                } 
                    
                if (availableBalance == 0 )
                {
                    Console.WriteLine("No funds left you lose.");
                    break;
                }
                  
                Console.WriteLine($"Your remaining balance is £{availableBalance}");
                    
                Console.WriteLine("Slot Numbers:");
                    
                for (int i = 0; i < NUMBER_OF_ROWS; i++)
                {
                    for (int j = 0; j < NUMBER_OF_COLUMNS; j++)
                    {
                        Console.Write(numbers[i, j] + " ");
                    }

                    Console.WriteLine();
                }
                
            }
            
            char GetPlayerChar()
            {
                Console.WriteLine($"Please type in what position you want to match. (R) for Row Match, (C) for Column Match, and (D) for Diagonal Match.");
                char gameChar = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (gameChar != ROW_CHAR && gameChar != COLUMN_CHAR && gameChar != Diagonal_CHAR)
                {
                    Console.WriteLine($"Please enter only characters available {ROW_CHAR}, {COLUMN_CHAR}, or {Diagonal_CHAR}");
                     
                }

                return gameChar;
            }
            
            bool CheckRowMatch(int[,] numbers, int selectedRow)
            {
                
                for (int col = 1; col < NUMBER_OF_COLUMNS; col++)
                {
                    if (numbers[selectedRow - 1, col] != numbers[selectedRow - 1, 0])
                    {
                        return rowMatch = true;
                    }
                    if (rowMatch)
                    {
                        Console.WriteLine($"Row match found you won £{WINNINGS}.");
                        matchFound = true;
                    }
                    else
                    {
                        Console.WriteLine($"No match found in row {selectedRow}.");
                    }
                }
                return true;
                
            }
            
            bool CheckColumnMatch(int[,] numbers, int selectedCol)
            {
                for (int row = 1; row < NUMBER_OF_ROWS; row++)
                {
                    if (numbers[row, selectedCol - 1] != numbers[0, selectedCol - 1])
                    {
                      return columnMatch = false;
                    }
                }

                if (columnMatch)
                {
                    Console.WriteLine($"Column match found you won £{WINNINGS}.");
                    matchFound = true;
                            
                }
                else
                {
                    Console.WriteLine($"No match found in column {selectedCol}.");
                }

                return true;

            }
            
            bool CheckDiagonalMatch1(int[,]numbers)
            {
                for (int diagonal = 1; diagonal < NUMBER_OF_ROWS; diagonal++)
                {
                    if (numbers[diagonal, diagonal] != numbers[0, 0])
                    {
                        diagonalMatch1 = false;
                      
                    }
                }

                if (diagonalMatch1)
                {
                    Console.WriteLine($"Diagonal Match1 you won £{WINNINGS}.");
                    matchFound = true;
                }

                return true;

            }
            
            bool CheckDiagonalMatch2(int[,]numbers)
            {
                for (int diagonal = 0; diagonal < NUMBER_OF_ROWS; diagonal++)
                {
                    if (numbers[diagonal, NUMBER_OF_COLUMNS - 1 - diagonal] != numbers[0, NUMBER_OF_COLUMNS - 1])
                    {
                        diagonalMatch2 = false;
                        break;
                    }
                }

                if (diagonalMatch2)
                {
                    Console.WriteLine($"Diagonal Match2 you won £{WINNINGS}.");
                    matchFound = true;
                }

                return true;

            }
        }
    }
}