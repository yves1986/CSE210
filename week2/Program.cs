using System;

class Program
{
    static void Main(string[] args)
    {
        // CREATIVITY EXCEEDING REQUIREMENTS:
        // 1. Added a 7th prompt for variety
        // 2. Added validation for file operations
        // 3. Added friendly messages after save/load
        // 4. Clear separation of concerns with proper classes
        
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== JOURNAL MENU ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    Entry entry = new Entry(date, prompt, response);
                    journal.AddEntry(entry);
                    Console.WriteLine("\nEntry added successfully!");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("\nEnter filename to save: ");
                    string saveFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(saveFile))
                    {
                        journal.SaveToFile(saveFile);
                    }
                    break;

                case "4":
                    Console.Write("\nEnter filename to load: ");
                    string loadFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadFile))
                    {
                        journal.LoadFromFile(loadFile);
                    }
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("\nGoodbye! Keep journaling!\n");
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Please choose 1-5.");
                    break;
            }
        }
    }
}