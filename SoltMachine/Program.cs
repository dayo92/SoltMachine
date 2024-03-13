using System;


namespace SoltMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            UIMethods.PrintGameTitle();

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


            int availableBalance = PLAYER_BALANCE;


            while (true)
            {
                char gameChar = Logic.GetPlayerChar(ROW_CHAR, COLUMN_CHAR, Diagonal_CHAR);

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

                int[,] numbers = Logic.GenerateRandomNumbers(NUMBER_OF_ROWS, NUMBER_OF_COLUMNS, MIN_RANDOM_NUMBER,
                    MAX_RANDOM_NUMBER);

                if (gameChar == ROW_CHAR)
                {
                    if (!int.TryParse(UIMethods.EnterNumber(ROW), out int selectedRow) || selectedRow < 1 ||
                        selectedRow > NUMBER_OF_ROWS)
                    {
                        UIMethods.InvalidNumber();
                        continue;
                    }

                    //Row

                    matchFound = Logic.CheckRowMatch(numbers, selectedRow, NUMBER_OF_COLUMNS, ROW, WINNINGS);
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

                    matchFound = Logic.CheckColumnMatch(numbers, selectedCol, NUMBER_OF_ROWS, COLUMN, WINNINGS);
                }


                if (gameChar == Diagonal_CHAR)
                {
                    // Diagonal 1

                    bool diagonalMatch1 = Logic.CheckDiagonalMatch1(numbers, NUMBER_OF_ROWS, DIAGONAL, WINNINGS);

                    // Diagonal 2
                    bool diagonalMatch2 = diagonalMatch1 ? false : Logic.CheckDiagonalMatch2(numbers, NUMBER_OF_ROWS, NUMBER_OF_COLUMNS, DIAGONAL2, WINNINGS);


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

                Logic.DisplayGrid(numbers, NUMBER_OF_ROWS, NUMBER_OF_COLUMNS);
            }
            
            
        }
    }
}