using System;

namespace SoltMachine
{
    public static class UIMethods
    {
        public static void PrintGameTitle()
        {
            Console.WriteLine("Slot Machine Game");
        } 
        
        public static void AvailableBalance(int availableBalance)
         {
             Console.WriteLine($"Your available balance is £{availableBalance}.");
         }
        
        public static string BettingQuestion()
        {
            return GetAnswer("How much would you like to bet? ");
        } 
        
        public static void InvalidNumber()
        {
            Console.WriteLine("Invalid number. Please try again.");
        } 
        
        public static void LowBalance()
        {
            Console.WriteLine("Not enough cash. Please try again,");
        } 
        
        public static void LockedBet( int playerBet)
        {
            Console.WriteLine($"£{playerBet} bet locked in.");
        } 
        
        public static string EnterNumber( string position)
        {
           return GetAnswer($"Enter the {position} number (1, 2, or 3) you want to check:");
        } 
        
        public static void NoFunds()
        {
            Console.WriteLine("No funds left you lose.");
        } 
        
        public static void RemainingBalance(int availableBalance)
        {
            Console.WriteLine($"Your remaining balance is £{availableBalance}");
        } 
        
        public static void SlotNumberTitle()
        {
            Console.WriteLine("Slot Numbers:");
        } 
        
        public static void Grid(int[,] numbers, int i, int j)
        {
            Console.Write(numbers[i, j] + " ");
        } 
        
        public static void text(char row, char column, char Diagonal)
        {
            Console.WriteLine($"Please type in what position you want to match. ({row}) for Row Match, ({column}) for Column Match, and ({Diagonal}) for Diagonal Match.");
        } 
        
        public static void InvalidChar(char row, char column, char Diagonal)
        {
            Console.WriteLine($"Please enter only characters available {row}, {column}, or {Diagonal}");        
        } 
        
        public static void Matchfound(string position, int  winnings)
        {
            Console.WriteLine($"{position} match found you won £{winnings}.");
        } 
        
        public static void NoMatchfound(int selectedRow)
        {
            Console.WriteLine($"No match found in row {selectedRow}.");
            
        } 
        
        public static string GetAnswer(string question)
        {
            Console.WriteLine($"{question}");

            string answer = Console.ReadLine();

            return answer;

        } 
        
     
    }
}