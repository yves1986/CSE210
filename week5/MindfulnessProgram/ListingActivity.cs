using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _availablePrompts;

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _availablePrompts = new List<string>(_prompts);
    }

    private string GetRandomPrompt()
    {
        if (_availablePrompts.Count == 0)
            _availablePrompts = new List<string>(_prompts);
        
        Random rand = new Random();
        int index = rand.Next(_availablePrompts.Count);
        string prompt = _availablePrompts[index];
        _availablePrompts.RemoveAt(index);
        return prompt;
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                items.Add(input);
        }
        return items;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        
        List<string> items = GetListFromUser();
        _count = items.Count;
        
        Console.WriteLine($"\nYou listed {_count} items!");
        
        DisplayEndingMessage();
    }
}