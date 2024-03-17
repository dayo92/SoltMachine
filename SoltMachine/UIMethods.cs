using System;

namespace SoltMachine
{
    public static class UIMethods
    {
        public static void PrintGameTitle()
        {
            Console.WriteLine("Slot Machine Game");
        } 
        
        public static void PrintAvailableBalance(int availableBalance)
         {
             Console.WriteLine($"Your available balance is £{availableBalance}.");
         }
        
        public static string PrintBettingQuestion()
        {
            return GetPlayerAnswer("How much would you like to bet? ");
        } 
        
        public static void PrintInvalidNumber()
        {
            Console.WriteLine("Invalid number. Please try again.");
        } 
        
        public static void PrintLowBalanceMessage()
        {
            Console.WriteLine("Not enough cash. Please try again,");
        } 
        
        public static void PrintLockedBet( int playerBet)
        {
            Console.WriteLine($"£{playerBet} bet locked in.");
        } 
        
        public static string PrintEnterNumberOption( string position)
        {
           return GetPlayerAnswer($"Enter the {position} number (1, 2, or 3) you want to check:");
        } 
        
        public static void PrintNoFundsMessage()
        {
            Console.WriteLine("No funds left you lose.");
        } 
        
        public static void PrintRemainingBalance(int availableBalance)
        {
            Console.WriteLine($"Your remaining balance is £{availableBalance}");
        } 
        
        public static void PrintSlotNumberTitle()
        {
            Console.WriteLine("Slot Numbers:");
        } 
        
        public static void PrintMachnieGrid(int[,] numbers, int i, int j)
        {
            Console.Write(numbers[i, j] + " ");
        } 
        
        public static void PrintPlayerPositionChoice(char row, char column, char Diagonal)
        {
            Console.WriteLine($"Please type in what position you want to match. ({row}) for Row Match, ({column}) for Column Match, and ({Diagonal}) for Diagonal Match.");
        } 
        
        public static void PrintInvalidCharMessage(char row, char column, char Diagonal)
        {
            Console.WriteLine($"Please enter only characters available {row}, {column}, or {Diagonal}");        
        } 
        
        public static void PrintMatchfoundMessage(int  winnings)
        {
            Console.WriteLine($"Match found you won £{winnings}.");
        } 
        
        public static void PrintNoMatchfoundMessage()
        {
            Console.WriteLine($"No match found");
            
        } 
        
        public static string GetPlayerAnswer(string question)
        {
            Console.WriteLine($"{question}");

            string answer = Console.ReadLine();

            return answer;

        }
        
        public static void WriteLine()
        {
            Console.WriteLine();
        }
        
     
    }
}