using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private readonly string _baseWord;
    private readonly string _orderedBaseWord;

    public Anagram(string baseWord)
    {
        _baseWord = baseWord;
        _orderedBaseWord = OrderString(baseWord.ToLower());
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var result = new List<string>();

        foreach (var match in potentialMatches)
        {
            if (OrderString(match.ToLower()) == _orderedBaseWord &&
                !match.Equals(_baseWord, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(match);
            }
        }

        return result.ToArray();
    }

    private string OrderString(string input)
    {
        var characters  = input.ToArray();
        Array.Sort(characters );
        return new string(characters );
    }
}