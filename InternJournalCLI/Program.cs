using System;
using System.Collections.Generic;
using System.Linq;
using InternJournal.Models;

namespace InternJournalCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to hold the journal entries
            var listOfEntries = new List<Entry>
            {
                new Entry
                {
                    Id = 1,
                    Title = "First Day of Intern Journal",
                    Body = "Today I created the project and wrote my first class in C#!",
                    Mood = "Productive",
                    Tags = new List<string> { "setup", "csharp", "day1" },
                    Date = DateTime.Now
                },
                new Entry
                {
                    Id = 2,
                    Title = "Second Day of Intern Journal",
                    Body = "Today I learned about classes and objects in C#!",
                    Mood = "Excited",
                    Tags = new List<string> { "learning", "csharp", "day2" },
                    Date = DateTime.Now.AddDays(1)
                },
                new Entry
                {
                    Id = 3,
                    Title = "Third Day of Intern Journal",
                    Body = "Today I practiced writing methods and properties in C#!",
                    Mood = "Confident",
                    Tags = new List<string> { "practice", "csharp", "day3" },
                    Date = DateTime.Now.AddDays(2)
                },
                new Entry
                {
                    Id = 4,
                    Title = "Fourth Day of Intern Journal",
                    Body = "Today I created a simple console application in C#!",
                    Mood = "Accomplished",
                    Tags = new List<string> { "application", "csharp", "day4" },
                    Date = DateTime.Now.AddDays(3)
                }
            };

            // Example usage of the FilterByMood method
            var filteredEntries = FilterByMood(listOfEntries, "Productive");

            foreach (var entry in filteredEntries)
            {
                Console.WriteLine($"[{entry.Date.ToShortDateString()}] {entry.Title} ({entry.Mood})");
                Console.WriteLine($"Tags: {string.Join(", ", entry.Tags)}");
                Console.WriteLine(entry.Body);
                Console.WriteLine(new string('-', 40));
            }

            // Example method to filter entries by tag
            var filteredEntriesByTag = FilterByTag(listOfEntries, "csharp");
            
            foreach (var entry in filteredEntriesByTag)
            {
                Console.WriteLine($"[{entry.Date.ToShortDateString()}] {entry.Title} ({entry.Mood})");
                Console.WriteLine($"Tags: {string.Join(", ", entry.Tags)}");
                Console.WriteLine(entry.Body);
                Console.WriteLine(new string('-', 40));
            }
        }

        // Method to filter entries by mood
        public static List<Entry> FilterByMood(List<Entry> entries, string mood)
        {
            return entries
                .Where(entry => entry.Mood == mood)
                .ToList();
        }

        public static List<Entry> FilterByTag(List<Entry> entries, string tag)
        {
            return entries
                .Where(entry => entry.Tags.Any(t => t == tag))
                .ToList();
        }
    }
}
