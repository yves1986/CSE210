using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog();
        log.Load();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    log.Display();
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    continue;
                case "5":
                    log.Save();
                    return;
                default:
                    continue;
            }

            if (activity != null)
            {
                activity.Run();
                log.Increment(activity.GetName());
                log.Save();
            }
        }
    }
}