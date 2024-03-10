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
            
         
            
            
            
            
            
            
            
            
            
            
            
            
            
        
       
            
            
    }
}