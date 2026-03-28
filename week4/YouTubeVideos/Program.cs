using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== YOUTUBE VIDEOS ===\n");

        // Create a list to hold all videos
        List<Video> videos = new List<Video>();

        // ========== VIDEO 1 ==========
        Video video1 = new Video("C# Programming Tutorial for Beginners", "CodeMaster", 720);
        
        video1.AddComment(new Comment("JohnDoe", "Great tutorial! Very helpful."));
        video1.AddComment(new Comment("JaneSmith", "I finally understand classes! Thanks!"));
        video1.AddComment(new Comment("DevGuy", "Could you make a video about inheritance?"));
        video1.AddComment(new Comment("CoderGirl", "This is exactly what I needed."));
        
        videos.Add(video1);

        // ========== VIDEO 2 ==========
        Video video2 = new Video("10 Tips for Better Code", "TechPro", 480);
        
        video2.AddComment(new Comment("MikeJohnson", "Tip #5 changed my life!"));
        video2.AddComment(new Comment("SarahLee", "Great advice, thank you!"));
        video2.AddComment(new Comment("CodeNewbie", "Very useful for beginners like me."));
        
        videos.Add(video2);

        // ========== VIDEO 3 ==========
        Video video3 = new Video("Understanding Object Oriented Programming", "AcademyOfCode", 1200);
        
        video3.AddComment(new Comment("ProfessorX", "Excellent explanation of OOP concepts."));
        video3.AddComment(new Comment("Student123", "This made encapsulation so clear!"));
        video3.AddComment(new Comment("DevLife", "Best OOP tutorial I've seen."));
        video3.AddComment(new Comment("CSharpFan", "Please make more videos like this!"));
        
        videos.Add(video3);

        // ========== VIDEO 4 ==========
        Video video4 = new Video("Quick Tips: Debugging in VS Code", "DevTips", 180);
        
        video4.AddComment(new Comment("AnnaDev", "Short and sweet! Very helpful."));
        video4.AddComment(new Comment("TomCode", "I didn't know about breakpoints. Thanks!"));
        video4.AddComment(new Comment("EllaCoder", "This saved me hours of frustration."));
        
        videos.Add(video4);

        // ========== DISPLAY ALL VIDEOS ==========
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine(new string('-', 50));
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}