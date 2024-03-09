using System;
using System.Text.RegularExpressions;
using SoltMachine;



namespace SoltMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            UIMethods.GameTittle();

            const int NUMBER_OF_ROWS = 3;
            const int NUMBER_OF_COLUMNS = 3;
            const int WINNINGS = 1;
            const int PLAYER_BALANCE = 100;
            const int MIN_RANDOM_NUMBER = 1;
            const int MAX_RANDOM_NUMBER = 3;
            
            const char ROW_CHAR = 'R';
            const char COLUMN_CHAR = 'C';
            const char Diagonal_CHAR = 'D';

            const string ROW = "Row";
            const string COLUMN = "Column";
            const string DIAGONAL = "Diagonal";
            const string DIAGONAL2 = "Diagonal 2";
            
           
            bool columnMatch = true;
            bool diagonalMatch1 = true;
            bool diagonalMatch2 = true;
            
            Random random = new Random();

            int availableBalance = PLAYER_BALANCE;

            
            bool matchFound = false;
            

            while (true)
            {
                
                char gameChar = GetPlayerChar();
                
                UIMethods.AvailableBalance(availableBalance);
            

                int playerBet = 0;
                bool isValid = false;
                
                while (!isValid)
                {
                    UIMethods.BettingQuestion();
                    string bet = Console.ReadLine();

                    isValid = int.TryParse(bet, out playerBet);
    
                    if (!isValid)
                    {
                        UIMethods.InvalidNumber();
                    }
                }
                
                
                if (playerBet > availableBalance)
                {
                    UIMethods.LowBalance();
                    continue;
                }
                

                UIMethods.LockedBet(playerBet);

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
                    UIMethods.EnterNumber(ROW);
                    
                    if (!int.TryParse(Console.ReadLine(), out int selectedRow) || selectedRow < 1 || selectedRow > NUMBER_OF_ROWS)
                    {
                        UIMethods.InvalidNumber();
                        continue;
                    }
                    
                    //Row
                    
                    matchFound = CheckRowMatch(numbers, selectedRow);
                    
                }
                
                

                if (gameChar == COLUMN_CHAR)
                {
                    UIMethods.EnterNumber(COLUMN);  
                    
                    if (!int.TryParse(Console.ReadLine(), out int selectedCol) || selectedCol < 1 || selectedCol > NUMBER_OF_COLUMNS)
                    {
                        UIMethods.InvalidNumber();
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
                    UIMethods.NoFunds();
                    break;
                }
                  
                UIMethods.RemainingBalance(availableBalance);
                    
                UIMethods.SlotNumberTitle();
                    
                for (int i = 0; i < NUMBER_OF_ROWS; i++)
                {
                    for (int j = 0; j < NUMBER_OF_COLUMNS; j++)
                    {
                        UIMethods.Grid(numbers, i, j);
                    }

                    Console.WriteLine();
                }
                
            }
            
            char GetPlayerChar()
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
            
            bool CheckRowMatch(int[,] numbers, int selectedRow)
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
            
            bool CheckColumnMatch(int[,] numbers, int selectedCol)
            {
                for (int row = 1; row < NUMBER_OF_ROWS; row++)
                {
                    if (numbers[row, selectedCol - 1] != numbers[0, selectedCol - 1])
                    { 
                        UIMethods.NoMatchfound(selectedCol);

                        return false;
                    }
                }

            
                UIMethods.Matchfound(COLUMN,WINNINGS);
                
                return true;

            }
            
            bool CheckDiagonalMatch1(int[,]numbers)
            {
                for (int diagonal = 1; diagonal < NUMBER_OF_ROWS; diagonal++)
                {
                    if (numbers[diagonal, diagonal] != numbers[0, 0])
                    {
                        return false;
                      
                    }
                }

                UIMethods.Matchfound(DIAGONAL,WINNINGS);
             

                return true;

            }
            
            bool CheckDiagonalMatch2(int[,]numbers)
            {
                for (int diagonal = 0; diagonal < NUMBER_OF_ROWS; diagonal++)
                {
                    if (numbers[diagonal, NUMBER_OF_COLUMNS - 1 - diagonal] != numbers[0, NUMBER_OF_COLUMNS - 1])
                    {
                       return false;
                       
                    }
                }

                UIMethods.Matchfound(DIAGONAL2,WINNINGS);

                return true;

            }
        }
    }
}