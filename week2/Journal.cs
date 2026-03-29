using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        // Additional creative prompts
        "What is something I learned today?",
        "What am I grateful for today?",
        "What made me smile today?"
    };
    private Random _random = new Random();

    public void WriteNewEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();
        Entry newEntry = new Entry(date, prompt, response);
        AddEntry(newEntry);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nEntry added successfully!");
        Console.ResetColor();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNo entries to display.\n");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("\n" + "=".PadRight(60, '='));
        foreach (Entry entry in _entries)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(entry.GetDisplayText());
            Console.WriteLine("-".PadRight(60, '-'));
        }
        Console.WriteLine($"\nTotal entries: {_entries.Count}");
        Console.ResetColor();
    }

    public void SaveToFile()
    {
        Console.Write("\nEnter filename to save (e.g., journal.txt): ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid filename.");
            Console.ResetColor();
            return;
        }

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetFileRepresentation());
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nJournal saved to {filename}");
        Console.ResetColor();
    }

    public void LoadFromFile()
    {
        Console.Write("\nEnter filename to load (e.g., journal.txt): ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid filename.");
            Console.ResetColor();
            return;
        }

        if (!File.Exists(filename))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nFile '{filename}' does not exist.");
            Console.ResetColor();
            return;
        }

        _entries.Clear(); // Prevent duplicate loading
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
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nJournal loaded from {filename} ({_entries.Count} entries)");
        Console.ResetColor();
    }

    public void SearchEntries()
    {
        if (_entries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNo entries to search.");
            Console.ResetColor();
            return;
        }

        Console.Write("\nSearch by (1) Date or (2) Keyword: ");
        string searchType = Console.ReadLine();

        if (searchType == "1")
        {
            Console.Write("Enter date (e.g., 01/15/2024): ");
            string date = Console.ReadLine();
            var found = _entries.Where(e => e._date.Contains(date)).ToList();

            if (found.Count == 0)
            {
                Console.WriteLine($"\nNo entries found for date: {date}");
            }
            else
            {
                Console.WriteLine($"\nFound {found.Count} entries:");
                foreach (Entry entry in found)
                {
                    Console.WriteLine(entry.GetDisplayText());
                    Console.WriteLine("-".PadRight(50, '-'));
                }
            }
        }
        else if (searchType == "2")
        {
            Console.Write("Enter keyword: ");
            string keyword = Console.ReadLine().ToLower();
            var found = _entries.Where(e => e._response.ToLower().Contains(keyword) || e._prompt.ToLower().Contains(keyword)).ToList();

            if (found.Count == 0)
            {
                Console.WriteLine($"\nNo entries found containing '{keyword}'");
            }
            else
            {
                Console.WriteLine($"\nFound {found.Count} entries containing '{keyword}':");
                foreach (Entry entry in found)
                {
                    Console.WriteLine(entry.GetDisplayText());
                    Console.WriteLine("-".PadRight(50, '-'));
                }
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid search option.");
            Console.ResetColor();
        }
    }

    public void DeleteEntry()
    {
        if (_entries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNo entries to delete.");
            Console.ResetColor();
            return;
        }

        DisplayAll();
        Console.Write("\nEnter the number of the entry to delete (1-based): ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _entries.Count)
        {
            Entry removed = _entries[index - 1];
            _entries.RemoveAt(index - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nEntry from {removed._date} deleted successfully.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid entry number.");
            Console.ResetColor();
        }
    }

    public void ShowStatistics()
    {
        if (_entries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNo entries to analyze.");
            Console.ResetColor();
            return;
        }

        int totalWords = 0;
        foreach (Entry entry in _entries)
        {
            totalWords += entry._response.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        }

        double avgWords = (double)totalWords / _entries.Count;

        Console.WriteLine("\n" + "=".PadRight(40, '='));
        Console.WriteLine("JOURNAL STATISTICS");
        Console.WriteLine("=".PadRight(40, '='));
        Console.WriteLine($"Total entries: {_entries.Count}");
        Console.WriteLine($"Total words written: {totalWords}");
        Console.WriteLine($"Average words per entry: {avgWords:F2}");
        Console.WriteLine($"First entry: {_entries[0]._date}");
        Console.WriteLine($"Last entry: {_entries[_entries.Count - 1]._date}");
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}