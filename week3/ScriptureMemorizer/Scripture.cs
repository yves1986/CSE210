using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            // Clean punctuation for display but preserve it for the Word object
            string cleanedWord = word.Trim(new char[] { '.', ',', ';', ':', '!', '?' });
            _words.Add(new Word(cleanedWord));
        }
    }

    public void HideRandomWords(int count)
    {
        // Get only words that are not already hidden
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        // If there are no visible words, return
        if (visibleWords.Count == 0)
        {
            return;
        }
        
        // Determine how many words to hide (don't exceed available visible words)
        int wordsToHide = Math.Min(count, visibleWords.Count);
        
        // Randomly select words to hide
        Random random = new Random();
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            // Remove the hidden word from the list to avoid hiding it again in this cycle
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n\n{scriptureText}";
    }

    public void Reset()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                // Since Word doesn't have an unhide method, we need to recreate
                // Alternatively, we could add an Unhide() method to Word class
            }
        }
    }
}