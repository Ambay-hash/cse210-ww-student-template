using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // The List of scriptures to memorize
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("1 Nephi 3:7"),
                "And it came to pass that I, Nephi, said unto my father, I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),

            new Scripture(new Reference("2 Nephi 28:30"),
                "For behold, thus saith the Lord God: I will give unto the children of men line upon line, precept upon precept, here a little and there a little; and blessed are those who hearken unto my precepts, and lend an ear unto my counsel, for they shall learn wisdom; for unto him that receiveth I will give more; and from them that shall say, We have enough, from them shall be taken away even that which they have."),
                
            new Scripture(new Reference("1 Nephi 33:1"),
                "And now I, Nephi, cannot write all the things which were taught among my people; neither am I mighty in writing, like unto speaking; for when a man speaketh by the power of the Holy Ghost the power of the Holy Ghost carrieth it unto the hearts of the children of men."),
        };

        // This will Randomly select a scripture
        var rand = new Random();
        var selectedScripture = scriptures[rand.Next(scriptures.Count)];

        selectedScripture.DisplayScripture();

        while (!selectedScripture.IsComplete())
        {
            var input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                break;
            }
            else if (input == "")
            {
                selectedScripture.HideRandomWord();
                selectedScripture.DisplayScripture();
            }
        }

        // This will hidden scripture display
        selectedScripture.DisplayScripture();
        Console.WriteLine("Memorization complete!");
    }
}

public class Reference
{
    public string Text { get; private set; }

    public Reference(string text)
    {
        Text = text;
    }
}

public class Word
{
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    public string GetDisplayText()
    {
        return Hidden ? new string('_', Text.Length) : Text;
    }

    public void Hide()
    {
        Hidden = true;
    }
}

public class Scripture
{
    private static readonly Random rand = new Random();
    public Reference Reference { get; private set; }
    public List<Word> Words { get; private set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWord()
    {
        // And this will randomly select a word that is not hidden and hide it
        var visibleWords = Words.Where(w => !w.Hidden).ToList();
        if (visibleWords.Count > 0)
        {
            var wordToHide = visibleWords[rand.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }

    public void DisplayScripture()
    {
        Console.Clear();

        Console.Write(Reference.Text + ": ");
        Console.WriteLine(string.Join(" ", Words.Select(w => w.GetDisplayText())));
        
        Console.WriteLine("Please press Enter to continue or Type 'quit' to finish:");
    }

    public bool IsComplete()
    {
        return !Words.Any(w => !w.Hidden);
    }
} 
