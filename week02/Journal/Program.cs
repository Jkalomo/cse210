// Added the delete entry when there is an error 
// Entries are numbered for each selection
// Prevents errors if user enters a wrong number 
// Uses properties (Date, Text, Prompt) instead of public fields
// Save each entry as a CSV-style line (date|prompt|text)


using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Date { get; set; }
    public string Text { get; set; }
    public string Prompt { get; set; }

    public void Display(int index)
    {
        Console.WriteLine($"{index + 1}. [{Date}] {Prompt}");
        Console.WriteLine(Text);
        Console.WriteLine();
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Text}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        return new Entry { Date = parts[0], Prompt = parts[1], Text = parts[2] };
    }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAllEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
            return;
        }

        for (int i = 0; i < _entries.Count; i++)
        {
            _entries[i].Display(i);
        }
    }

    public void DeleteEntry(int index)
    {
        if (index < 0 || index >= _entries.Count)
        {
            Console.WriteLine("Invalid entry number.");
            return;
        }

        _entries.RemoveAt(index);
        Console.WriteLine("Entry deleted successfully.");
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear(); // Clear existing entries before loading

        foreach (string line in File.ReadAllLines(filename))
        {
            _entries.Add(Entry.FromFileFormat(line));
        }
        
        Console.WriteLine($"Journal loaded from {filename}");
    }
}

class Program
{
    static void Main()
    {
        Journal myJournal = new Journal();

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Delete Entry");
            Console.WriteLine("4. Save to File");
            Console.WriteLine("5. Load from File");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter a date (YYYY-MM-DD): ");
                string date = Console.ReadLine();
                
                Console.Write("Enter a journal prompt: ");
                string prompt = Console.ReadLine();

                Console.Write("Write your journal entry: ");
                string text = Console.ReadLine();

                Entry newEntry = new Entry
                {
                    Date = date,
                    Prompt = prompt,
                    Text = text
                };

                myJournal.AddEntry(newEntry);
                Console.WriteLine("Entry added!");
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nYour Journal Entries:");
                myJournal.DisplayAllEntries();
            }
            else if (choice == "3")
            {
                Console.WriteLine("\nWhich entry would you like to delete?");
                myJournal.DisplayAllEntries();
                
                Console.Write("Enter entry number to delete: ");
                if (int.TryParse(Console.ReadLine(), out int index))
                {
                    myJournal.DeleteEntry(index - 1);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}
