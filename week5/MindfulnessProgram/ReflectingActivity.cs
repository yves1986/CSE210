using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _availablePrompts;
    private List<string> _availableQuestions;

    public ReflectingActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _availablePrompts = new List<string>(_prompts);
        _availableQuestions = new List<string>(_questions);
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

    private string GetRandomQuestion()
    {
        if (_availableQuestions.Count == 0)
            _availableQuestions = new List<string>(_questions);
        
        Random rand = new Random();
        int index = rand.Next(_availableQuestions.Count);
        string question = _availableQuestions[index];
        _availableQuestions.RemoveAt(index);
        return question;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write($"\n> {GetRandomQuestion()} ");
            ShowSpinner(8);
        }
        
        DisplayEndingMessage();
    }
}