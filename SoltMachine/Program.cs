using System;


namespace SoltMachine
{
    internal class Program
    {
        public const int NUMBER_OF_ROWS = 3;
        public const int NUMBER_OF_COLUMNS = 3;
        public const int MIN_RANDOM_NUMBER = 1;
        public const int MAX_RANDOM_NUMBER = 3;
        
        public const char ROW_CHAR = 'R';
        public const char COLUMN_CHAR = 'C';
        public const char Diagonal_CHAR = 'D';
        
        public const string ROW = "Row";
        public const string COLUMN = "Column";
        public const string DIAGONAL = "Diagonal";
        public const string DIAGONAL2 = "Diagonal 2";
        
        public const int WINNINGS = 1;
        public const int PLAYER_BALANCE = 100;
        
        public static void Main(string[] args)
        {
            UIMethods.PrintGameTitle();
            

            int availableBalance = PLAYER_BALANCE;


            while (true)
            {
                char gameChar = Logic.GetPlayerChar();

                UIMethods.AvailableBalance(availableBalance);


                int playerBet = 0;
                bool isValid = false;
                bool matchFound = false;


                while (!isValid)
                {
                    string bet = UIMethods.BettingQuestion();

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

                int[,] numbers = Logic.GenerateRandomNumbers();

                if (gameChar == ROW_CHAR)
                {
                    if (!int.TryParse(UIMethods.EnterNumber(ROW), out int selectedRow) || selectedRow < 1 ||
                        selectedRow > NUMBER_OF_ROWS)
                    {
                        UIMethods.InvalidNumber();
                        continue;
                    }

                    //Row

                    matchFound = Logic.CheckRowMatch(numbers, selectedRow);
                }


                if (gameChar == COLUMN_CHAR)
                {
                    UIMethods.EnterNumber(COLUMN);

                    if (!int.TryParse(Console.ReadLine(), out int selectedCol) || selectedCol < 1 ||
                        selectedCol > NUMBER_OF_COLUMNS)
                    {
                        UIMethods.InvalidNumber();
                        continue;
                    }
                   

                    //Column

                    matchFound = Logic.CheckColumnMatch(numbers, selectedCol);
                }


                if (gameChar == Diagonal_CHAR)
                {
                    // Diagonal 1

                    bool diagonalMatch1 = Logic.CheckDiagonalMatch1(numbers);

                    // Diagonal 2
                    bool diagonalMatch2 = diagonalMatch1 ? false : Logic.CheckDiagonalMatch2(numbers);


                    matchFound = diagonalMatch1 || diagonalMatch2;
                }


                if (matchFound)
                {
                    availableBalance += playerBet + WINNINGS;
                }

                if (availableBalance == 0)
                {
                    UIMethods.NoFunds();
                    break;
                }

                UIMethods.RemainingBalance(availableBalance);

                UIMethods.SlotNumberTitle();

                Logic.DisplayGrid(numbers);
            }
            
            
        }
    }
}