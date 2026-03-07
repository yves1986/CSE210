using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomGenerator = new Random();
            string playAgain = "yes";
            
            while (playAgain == "yes")
            {
                // Générer un nombre aléatoire
                int magicNumber = randomGenerator.Next(1, 101);
                int guess = -1;
                int guessCount = 0;
                
                Console.WriteLine("I'm thinking of a number between 1 and 100...");
                
                // Boucle de jeu
                while (guess != magicNumber)
                {
                    Console.Write("What is your guess? ");
                    string userInput = Console.ReadLine();
                    guess = int.Parse(userInput);
                    guessCount++;
                    
                    if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else
                    {
                        Console.WriteLine("You guessed it!");
                        Console.WriteLine($"It took you {guessCount} guesses!");
                    }
                }
                
                // Demander si rejouer
                Console.Write("Do you want to play again? (yes/no): ");
                playAgain = Console.ReadLine();
                Console.WriteLine();
            }
            
            Console.WriteLine("Thanks for playing!");
        }
    }
}