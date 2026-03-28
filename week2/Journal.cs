using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.GetDisplayText());
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetFileRepresentation());
            }
        }
        Console.WriteLine($"\nJournal saved to {filename}\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nFile {filename} does not exist.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];
                Entry entry = new Entry(date, prompt, response);
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"\nJournal loaded from {filename}\n");
    }
}