public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var lowerWord = word.ToLower();
        var repeatedLettersCount = lowerWord
            .GroupBy(x => x, y => y, (c, chars) => new { Key = c, Count = chars.Count() })
            .Count(x => char.IsLetter(x.Key) && x.Count > 1);
        
        return repeatedLettersCount == 0;
    }
}
