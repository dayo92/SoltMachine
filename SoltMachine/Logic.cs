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
            
            
            public static bool IsInputCharValid(char gameChar, char rowChar, char columnChar, char diagonalChar)
            {
                return gameChar == rowChar || gameChar == columnChar || gameChar == diagonalChar;
            }
         
  
       
            public static bool CheckMatchInRows(int[,] numbers, int row)
            {
                for (int col = 1; col < Program.NUMBER_OF_COLUMNS; col++)
                {
                    if (numbers[row - 1, col] != numbers[row - 1, 0])
                    {
                        return false;
                    }
                }
                return true;
            }
            
            public static bool CheckMatchInColumn(int[,] numbers, int selectedCol)
            {
                for (int row = 1; row < Program.NUMBER_OF_ROWS; row++)
                {
                    if (numbers[row, selectedCol - 1] != numbers[0, selectedCol - 1])
                    {

                        return false;
                    }
                }
                

                return true;
            }
            
            public static bool CheckMatchInDiagonal1(int[,] numbers)
            {
                for (int diagonal = 1; diagonal < Program.NUMBER_OF_ROWS; diagonal++)
                {
                    if (numbers[diagonal, diagonal] != numbers[0, 0])
                    {
                        return false;
                    }
                }

                return true;
            }

            public static bool CheckMatchInDiagonal2(int[,] numbers)
            {
                for (int diagonal = 0; diagonal < Program.NUMBER_OF_ROWS; diagonal++)
                {
                    if (numbers[diagonal, Program.NUMBER_OF_COLUMNS - 1 - diagonal] != numbers[0, Program.NUMBER_OF_COLUMNS - 1])
                    {
                        return false;
                    }
                }

                return true;
            }
            
    }
}