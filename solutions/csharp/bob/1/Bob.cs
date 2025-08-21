using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        if (statement.Contains("How are you?"))
        {
            return "Sure.";
        }
        
        if (IsQuestion(statement) && IsAllUppers(statement))
        {
            return "Calm down, I know what I'm doing!";
        }
        
        if (IsAllUppers(statement))
        {
            return "Whoa, chill out!";
        }

        if (IsQuestion(statement))
        {
            return "Sure.";
        }

        if (IsSilence(statement))
        {
            return "Fine. Be that way!";
        }
        
        return "Whatever.";
    }

    private static bool IsSilence(string statement) => string.IsNullOrEmpty(statement.Trim());

    private static bool IsAllUppers(string input)
    {
        var letters = input.Where(char.IsLetter).ToArray();
        var uppers = letters.Where(char.IsUpper).ToArray();

        if (letters.Length == 0)
        {
            return false;
        }
        
        return letters.Length == uppers.Length;
    }

    private static bool IsQuestion(string input) => input.Trim().EndsWith('?');
}