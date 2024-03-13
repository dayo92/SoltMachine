using System;

namespace SoltMachine
{
    public class Logic
    {
        
       
            public static int[,] GenerateRandomNumbers(int NUMBER_OF_ROWS, int NUMBER_OF_COLUMNS, int MIN_RANDOM_NUMBER, int MAX_RANDOM_NUMBER)
            {
                int[,] numbers = new int[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];
                    
                Random random = new Random();
                for (int i = 0; i < NUMBER_OF_ROWS; i++)
                {
                    for (int j = 0; j < NUMBER_OF_COLUMNS; j++)
                    {
                        numbers[i, j] = random.Next(MIN_RANDOM_NUMBER, MAX_RANDOM_NUMBER);
                    }
                }
                
                return numbers;
            }
            
            public static char GetPlayerChar(char ROW_CHAR, char COLUMN_CHAR, char Diagonal_CHAR)
            {
                UIMethods.text(ROW_CHAR, COLUMN_CHAR, Diagonal_CHAR);
            
                char gameChar = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (gameChar != ROW_CHAR && gameChar != COLUMN_CHAR && gameChar != Diagonal_CHAR)
                {
                    UIMethods.InvalidChar(ROW_CHAR, COLUMN_CHAR, Diagonal_CHAR);
                }

                return gameChar;
            }
            
            
            public static void DisplayGrid(int[,] numbers, int NUMBER_OF_ROWS, int NUMBER_OF_COLUMNS)
            {
                for (int i = 0; i < NUMBER_OF_ROWS; i++)
                {
                    for (int j = 0; j < NUMBER_OF_COLUMNS; j++)
                    {
                        UIMethods.Grid(numbers, i, j);
                    }

                    Console.WriteLine();
                }
            }
            
            public static bool CheckRowMatch(int[,] numbers, int selectedRow,int NUMBER_OF_COLUMNS, string ROW, int WINNINGS)
            {
                
                for (int col = 1; col < NUMBER_OF_COLUMNS; col++)
                {
                    if (numbers[selectedRow - 1, col] != numbers[selectedRow - 1, 0])
                    {
                        UIMethods.NoMatchfound(selectedRow);
                        return false;
                    }
                }
                
                UIMethods.Matchfound(ROW,WINNINGS);
                
                return true;
                
            }
            
            public static bool CheckColumnMatch(int[,] numbers, int selectedCol, int NUMBER_OF_ROWS, string COLUMN, int WINNINGS)
            {
                for (int row = 1; row < NUMBER_OF_ROWS; row++)
                {
                    if (numbers[row, selectedCol - 1] != numbers[0, selectedCol - 1])
                    {
                        UIMethods.NoMatchfound(selectedCol);

                        return false;
                    }
                }


                UIMethods.Matchfound(COLUMN, WINNINGS);

                return true;
            }
            
            public static bool CheckDiagonalMatch1(int[,] numbers, int NUMBER_OF_ROWS, string DIAGONAL, int WINNINGS)
            {
                for (int diagonal = 1; diagonal < NUMBER_OF_ROWS; diagonal++)
                {
                    if (numbers[diagonal, diagonal] != numbers[0, 0])
                    {
                        return false;
                    }
                }

                UIMethods.Matchfound(DIAGONAL, WINNINGS);


                return true;
            }

            public static bool CheckDiagonalMatch2(int[,] numbers, int NUMBER_OF_ROWS, int NUMBER_OF_COLUMNS, string DIAGONAL2, int WINNINGS)
            {
                for (int diagonal = 0; diagonal < NUMBER_OF_ROWS; diagonal++)
                {
                    if (numbers[diagonal, NUMBER_OF_COLUMNS - 1 - diagonal] != numbers[0, NUMBER_OF_COLUMNS - 1])
                    {
                        return false;
                    }
                }

                UIMethods.Matchfound(DIAGONAL2, WINNINGS);

                return true;
            }
            
    }
}