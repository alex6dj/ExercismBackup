public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var separators = new[] { ' ', '-', '_' };
        var words = phrase.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        var firstLetters = words.Select(x => x[0]);
        return firstLetters.Aggregate("", (current, next) => current + next).ToUpper();
    }
}