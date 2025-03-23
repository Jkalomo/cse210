using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture(new Reference("John 3:16"),
            "For God so loved the world that He gave His one and only Son, that whoever believes in Him shall not perish but have eternal life.");

        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorization Program!");
        Console.WriteLine("Press Enter to start, type 'hint' for a clue, or 'quit' to exit.");
        Console.ReadLine();

        int attempts = 0;

        while (!scripture.IsFullyHidden())
        {
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine($"Attempts: {attempts} | Progress: {scripture.GetProgress()}% words hidden");

            string userInput = Console.ReadLine()?.Trim().ToLower();
            if (userInput == "quit")
            {
                Console.WriteLine("Exiting program. Goodbye!");
                break;
            }
            else if (userInput == "hint")
            {
                scripture.RevealOneWord();
            }
            else
            {
                scripture.HideRandomWords();
                attempts++;
            }
        }

        Console.WriteLine($"All words hidden! You took {attempts} attempts. Well done!");
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void DisplayScripture()
    {
        Console.WriteLine(_reference);
        Console.WriteLine(string.Join(" ", _words.Select(word => word.DisplayWord())));
        Console.WriteLine("\nType 'hint' to reveal a word, press Enter to continue, or type 'quit' to exit.");
    }

    public void HideRandomWords()
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        int wordsToHide = Math.Min(3, visibleWords.Count);

        if (wordsToHide == 0) return;

        foreach (var word in visibleWords.OrderBy(_ => _rand.Next()).Take(wordsToHide))
        {
            word.Hide();
        }
    }

    public void RevealOneWord()
    {
        var hiddenWords = _words.Where(w => w.IsHidden()).ToList();
        if (hiddenWords.Any())
        {
            hiddenWords[_rand.Next(hiddenWords.Count)].Reveal();
        }
    }

    public int GetProgress()
    {
        return (_words.Count(w => w.IsHidden()) * 100) / _words.Count;
    }

    public bool IsFullyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}

class Reference
{
    private string _text;

    public Reference(string reference)
    {
        _text = reference;
    }

    public string GetText()
    {
        return _text;
    }

    public override string ToString()
    {
        return _text;
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Reveal()
    {
        _isHidden = false;
    }

    public bool IsHidden() => _isHidden;

    public string DisplayWord()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}
