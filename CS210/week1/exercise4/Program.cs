using System;
using System.Collections.Generic;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int userNumber = -1;
            
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            
            // Collecter les nombres
            while (userNumber != 0)
            {
                Console.Write("Enter number: ");
                string userInput = Console.ReadLine();
                userNumber = int.Parse(userInput);
                
                if (userNumber != 0)
                {
                    numbers.Add(userNumber);
                }
            }
            
            // Core Requirements
            // 1. Calculer la somme
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"The sum is: {sum}");
            
            // 2. Calculer la moyenne
            float average = (float)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");
            
            // 3. Trouver le maximum
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine($"The largest number is: {max}");
            
            // Stretch Challenge
            // Trouver le plus petit nombre positif
            int smallestPositive = int.MaxValue;
            foreach (int number in numbers)
            {
                if (number > 0 && number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            
            // Trier la liste
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}