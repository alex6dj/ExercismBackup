public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var separators = phrase.Where(x => !char.IsLetter(x) && x != '\'').ToArray();
        var words = phrase.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        var firstLetters = words.Select(x => x[0]);
        return firstLetters.Aggregate("", (current, next) => current + next).ToUpper();
    }
}