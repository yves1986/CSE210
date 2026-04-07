using System;
using System.Collections.Generic;
using System.IO;

public class ActivityLog
{
    private Dictionary<string, int> _log = new Dictionary<string, int>
    {
        { "Breathing Activity", 0 },
        { "Reflection Activity", 0 },
        { "Listing Activity", 0 }
    };

    public void Increment(string activityName)
    {
        if (_log.ContainsKey(activityName))
            _log[activityName]++;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("Activity Log");
        Console.WriteLine("-------------");
        foreach (var entry in _log)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} time(s)");
        }
    }

    public void Save()
    {
        using (StreamWriter writer = new StreamWriter("activity_log.txt"))
        {
            foreach (var entry in _log)
            {
                writer.WriteLine($"{entry.Key}|{entry.Value}");
            }
        }
    }

    public void Load()
    {
        if (File.Exists("activity_log.txt"))
        {
            string[] lines = File.ReadAllLines("activity_log.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2 && _log.ContainsKey(parts[0]))
                {
                    _log[parts[0]] = int.Parse(parts[1]);
                }
            }
        }
    }
}