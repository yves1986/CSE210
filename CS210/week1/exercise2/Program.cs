using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Demander le pourcentage
            Console.Write("Enter your grade percentage: ");
            string userInput = Console.ReadLine();
            int percentage = int.Parse(userInput);
            
            // Déterminer la lettre
            string letter = "";
            
            if (percentage >= 90)
            {
                letter = "A";
            }
            else if (percentage >= 80)
            {
                letter = "B";
            }
            else if (percentage >= 70)
            {
                letter = "C";
            }
            else if (percentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }
            
            // Stretch challenge - Ajouter le signe + ou -
            string sign = "";
            int lastDigit = percentage % 10;
            
            if (percentage >= 60 && percentage <= 100)
            {
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }
            
            // Cas spéciaux
            if (letter == "A" && sign == "+")
            {
                sign = "";  // Pas de A+
            }
            else if (letter == "F")
            {
                sign = "";  // Pas de signe pour F
            }
            
            // Afficher le résultat
            Console.WriteLine($"Your grade is: {letter}{sign}");
            
            // Message de réussite/encouragement
            if (percentage >= 70)
            {
                Console.WriteLine("Congratulations, you passed the course!");
            }
            else
            {
                Console.WriteLine("Keep working hard for next time!");
            }
        }
    }
}