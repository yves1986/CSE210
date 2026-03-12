using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // === Étape 4 : Tester la classe Job ===
        Console.WriteLine("=== Test des Jobs ===");
        
        // Premier job
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;
        
        // Deuxième job
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;
        
        // === Étape 5 : Tester la méthode Display() ===
        job1.Display();
        job2.Display();
        
        Console.WriteLine(); // Ligne vide
        
        // === Étape 7 : Tester la classe Resume ===
        Console.WriteLine("=== Test du Resume ===");
        
        Resume myResume = new Resume();
        myResume._name = "Allison Rose";
        
        // Ajouter les jobs au CV
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        
        // Tester l'accès à un job spécifique
        Console.WriteLine($"Premier job: {myResume._jobs[0]._jobTitle}");
        Console.WriteLine();
        
        // === Étape 8 : Afficher le CV complet ===
        Console.WriteLine("=== CV Complet ===");
        myResume.Display();
    }
}