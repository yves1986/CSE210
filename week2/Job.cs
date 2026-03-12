using System;

public class Job
{
    // Attributs (membres variables)
    public string _company = "";
    public string _jobTitle = "";
    public int _startYear;
    public int _endYear;

    // Constructeur
    public Job()
    {
    }

    // Méthode pour afficher les détails du job
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}