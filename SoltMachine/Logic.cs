using System;

namespace SoltMachine
{
    public class Logic
    {
        
            public static int[,] GenerateRandomNumbers()
            {
                int[,] numbers = new int[Program.NUMBER_OF_ROWS, Program.NUMBER_OF_COLUMNS];
                    
                Random random = new Random();
                for (int i = 0; i < Program.NUMBER_OF_ROWS; i++)
                {
                    for (int j = 0; j < Program.NUMBER_OF_COLUMNS; j++)
                    {
                        numbers[i, j] = random.Next(Program.MIN_RANDOM_NUMBER, Program.MAX_RANDOM_NUMBER);
                    }
                }
                
                return numbers;
            }
            
            public static char GetPlayerChar()
            {
                UIMethods.text(Program.ROW_CHAR, Program.COLUMN_CHAR, Program.Diagonal_CHAR);
            
                char gameChar = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (gameChar != Program.ROW_CHAR && gameChar != Program.COLUMN_CHAR && gameChar != Program.Diagonal_CHAR)
                {
                    UIMethods.InvalidChar(Program.ROW_CHAR, Program.COLUMN_CHAR, Program.Diagonal_CHAR);
                }

                return gameChar;
            }
            
            
            public static void DisplayGrid(int[,] numbers)
            {
             
                for (int i = 0; i < Program.NUMBER_OF_ROWS; i++)
                {
                    for (int j = 0; j < Program.NUMBER_OF_COLUMNS; j++)
                    {
                        UIMethods.Grid(numbers, i, j);
                    }

                    Console.WriteLine();
                }
            }
            
            public static bool CheckRowMatch(int[,] numbers, int selectedRow)
            {
                
                for (int col = 1; col < Program.NUMBER_OF_COLUMNS; col++)
                {
                    if (numbers[selectedRow - 1, col] != numbers[selectedRow - 1, 0])
                    {
                        //UIMethods.NoMatchfound(selectedRow);
                        return false;
                    }
                }
                
                //UIMethods.Matchfound(Program.ROW,Program.WINNINGS);
                
                return true;
                
            }
            
            public static bool CheckColumnMatch(int[,] numbers, int selectedCol)
            {
                Console.WriteLine("CHECKING COLUMNS");
                for (int row = 1; row < Program.NUMBER_OF_ROWS; row++)
                {
                    if (numbers[row, selectedCol - 1] != numbers[0, selectedCol - 1])
                    {
                        //UIMethods.NoMatchfound(selectedCol);

                        return false;
                    }
                }


                //UIMethods.Matchfound(Program.COLUMN, Program.WINNINGS);

                return true;
            }
            
            public static bool CheckDiagonalMatch1(int[,] numbers)
            {
                for (int diagonal = 1; diagonal < Program.NUMBER_OF_ROWS; diagonal++)
                {
                    if (numbers[diagonal, diagonal] != numbers[0, 0])
                    {
                        return false;
                    }
                }

                //UIMethods.Matchfound(Program.DIAGONAL, Program.WINNINGS);


                return true;
            }

            public static bool CheckDiagonalMatch2(int[,] numbers)
            {
                for (int diagonal = 0; diagonal < Program.NUMBER_OF_ROWS; diagonal++)
                {
                    if (numbers[diagonal, Program.NUMBER_OF_COLUMNS - 1 - diagonal] != numbers[0, Program.NUMBER_OF_COLUMNS - 1])
                    {
                        return false;
                    }
                }

                //UIMethods.Matchfound(Program.DIAGONAL2, Program.WINNINGS);

                return true;
            }
            
    }
}