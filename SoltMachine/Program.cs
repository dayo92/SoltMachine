﻿using System;


namespace SoltMachine
{
    internal class Program
    {
        public const int NUMBER_OF_ROWS = 3;
        public const int NUMBER_OF_COLUMNS = 3;
        public const int MIN_RANDOM_NUMBER = 1;
        public const int MAX_RANDOM_NUMBER = 10;
        
        public const char ROW_CHAR = 'R';
        public const char COLUMN_CHAR = 'C';
        public const char DIAGONAL_CHAR = 'D';
        
        public const string ROW = "Row";
        public const string COLUMN = "Column";
      
        
        public const int PLAYER_BALANCE = 100;
        
        public static void Main(string[] args)
        {
            UIMethods.PrintGameTitle();
            

            const int WINNINGS = 1;
        
            int availableBalance = PLAYER_BALANCE;


            while (true)
            {
                char gameChar = GetPlayerChar();

                UIMethods.PrintAvailableBalance(availableBalance);


                int playerBet = 0;
                bool isValid = false;
                bool matchFound = false;


                while (!isValid)
                {
                    string bet = UIMethods.PrintBettingQuestion();

                    isValid = int.TryParse(bet, out playerBet);

                    if (!isValid)
                    {
                        UIMethods.PrintInvalidNumber();
                    }
                }


                if (playerBet > availableBalance)
                {
                    UIMethods.PrintLowBalanceMessage();
                    continue;
                }


                UIMethods.PrintLockedBet(playerBet);

                availableBalance -= playerBet;

                int[,] numbers = Logic.GenerateRandomNumbers();

                if (gameChar == ROW_CHAR)
                {
                    if (!int.TryParse(UIMethods.PrintEnterNumberOption(ROW), out int selectedRow) || selectedRow < 1 ||
                        selectedRow > NUMBER_OF_ROWS)
                    {
                        UIMethods.PrintInvalidNumber();
                        return;
                    }

                    //Row

                    matchFound = CheckRowMatch(numbers, selectedRow);
                }


                if (gameChar == COLUMN_CHAR)
                {

                    if (!int.TryParse(UIMethods.PrintEnterNumberOption(COLUMN), out int selectedCol) || selectedCol < 1 ||
                        selectedCol > NUMBER_OF_COLUMNS)
                    {
                        UIMethods.PrintInvalidNumber();
                        return;
                    }
                   

                    //Column

                    matchFound = CheckColumnMatch(numbers, selectedCol);
                }


                if (gameChar == DIAGONAL_CHAR)
                {
                    // Diagonal 1

                    bool diagonalMatch1 = CheckDiagonalMatch1(numbers);

                    // Diagonal 2
                    bool diagonalMatch2 = diagonalMatch1 ? false : CheckDiagonalMatch2(numbers);


                    matchFound = diagonalMatch1 || diagonalMatch2;
                }


                if (matchFound)
                {
                    availableBalance += playerBet + WINNINGS;
                    UIMethods.PrintMatchfoundMessage(WINNINGS);
                }
                else
                {
                    UIMethods.PrintNoMatchfoundMessage();
                }

                if (availableBalance == 0)
                {
                    UIMethods.PrintNoFundsMessage();
                    break;
                }

                UIMethods.PrintRemainingBalance(availableBalance);

                UIMethods.PrintSlotNumberTitle();

                DisplayGrid(numbers);
            }
            
            char GetPlayerChar()
            {
                char gameChar;
                bool isValidChar = false;

                do
                {
                    UIMethods.PrintPlayerPositionChoice(ROW_CHAR, COLUMN_CHAR, DIAGONAL_CHAR);
                    gameChar = char.ToUpper(Console.ReadKey(true).KeyChar);
                    UIMethods.WriteLine();

                    if (Logic.IsInputCharValid(gameChar, ROW_CHAR, COLUMN_CHAR, DIAGONAL_CHAR))
                    {
                        isValidChar = true;
                    }
                    else
                    {
                        UIMethods.PrintInvalidCharMessage(ROW_CHAR, COLUMN_CHAR, DIAGONAL_CHAR);
                    }
                } while (!isValidChar);

                return gameChar;
            }
            
            void DisplayGrid(int[,] numbers)
            {
             
                for (int i = 0; i < NUMBER_OF_ROWS; i++)
                {
                    for (int j = 0; j < NUMBER_OF_COLUMNS; j++)
                    {
                        UIMethods.PrintMachnieGrid(numbers, i, j);
                    }

                    UIMethods.WriteLine();
                }
            }
            
            bool CheckRowMatch(int[,] numbers, int selectedRow)
            {
                
                return Logic.CheckMatchInRows(numbers, selectedRow);
                
            }
            
            bool CheckColumnMatch(int[,] numbers, int selectedCol)
            {
                return Logic.CheckMatchInColumn(numbers, selectedCol);
            }
            
            bool CheckDiagonalMatch1(int[,] numbers)
            {
                return Logic.CheckMatchInDiagonal1(numbers);
            }

            bool CheckDiagonalMatch2(int[,] numbers)
            {
                return Logic.CheckMatchInDiagonal2(numbers);
            }
            
        }
    }
}