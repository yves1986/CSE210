using System;
using System.Collections.Generic;

public class Resume
{
    // Attributs
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    // Constructeur
    public Resume()
    {
    }

    // Méthode pour afficher le CV complet
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}