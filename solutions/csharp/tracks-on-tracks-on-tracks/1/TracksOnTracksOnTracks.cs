using System;
using System.Collections.Generic;
using System.Linq;

public static class Languages
{
    public static List<string> NewList() => new();

    public static List<string> GetExistingLanguages() => new() { "C#", "Clojure", "Elm" };
    
    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages) => languages.Count;

    public static bool HasLanguage(List<string> languages, string language) => languages.Contains(language);

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        const string excitingLanguage = "C#";

        if (languages.Count == 0)
        {
            return false;
        }

        if (languages[0] == excitingLanguage)
        {
            return true;
        }

        if (languages.Count is 2 or 3 && languages[1] == excitingLanguage)
        {
            return true;
        }

        return false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language) =>
        languages.Where(x => x != language).ToList();

    public static bool IsUnique(List<string> languages) => languages.Count == languages.Distinct().Count();
}
