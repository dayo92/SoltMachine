using System;

namespace SoltMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Slot Machine Game");

            const int NUMBER_OF_ROWS = 3;
            const int NUMBER_OF_COLUMNS = 3;
            
            Random random = new Random();

            int availableBalance = 10;

            bool gameIsOn = true;
            bool matchFound = false;
            

            while (gameIsOn)
            {
                Console.WriteLine($"Your available balance is £{availableBalance}.");
                
                Console.Write("How much would you like to bet? ");
                int bet = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine($"£{bet} locked in.");

                availableBalance -= bet;
            
                int[,] numbers = new int[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];
                
                
                for (int i = 0; i < numbers.GetLength(0); i++)
                {
                    for (int j = 0; j < numbers.GetLength(1); j++)
                    {
                        numbers[i, j] = random.Next(1, 10); 
                    }
                }
                
                Console.WriteLine("Slot Numbers:");
                for (int i = 0; i < numbers.GetLength(0); i++)
                {
                    for (int j = 0; j < numbers.GetLength(1); j++)
                    {
                        Console.Write(numbers[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                
                if (matchFound)
                {
                    availableBalance += 1;
                }
                
                if (availableBalance == 0)
                {
                    Console.WriteLine("No funds left you lose.");
                    gameIsOn = false;
                }
                
                
                for (int i = 0; i < numbers.GetLength(0); i++)
                {
                    if (numbers[i, 0] == numbers[i, 1] && numbers[i, 1] == numbers[i, 2])
                    {
                        Console.WriteLine($"Matching numbers found you won £1.");
                        matchFound = true;
                    }
                  
                }

                // vertical
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (numbers[0, j] == numbers[1, j] && numbers[1, j] == numbers[2, j])
                    {
                        Console.WriteLine($"Matching numbers found you won £1.");
                        matchFound = true;
                    }
                  
                }

                // diagonal
                if (numbers[0, 0] == numbers[1, 1] && numbers[1, 1] == numbers[2, 2])
                {
                    Console.WriteLine($"Matching numbers found you won £1.");
                    matchFound = true;
                }
               
                if (numbers[0, 2] == numbers[1, 1] && numbers[1, 1] == numbers[2, 0])
                {
                    Console.WriteLine($"Matching numbers found you won £1.");
                    matchFound = true;
                }
              
                
               

                
                Console.WriteLine($"Your remaining balance is £{availableBalance}");
                
            }

          
            
        }
    }
}