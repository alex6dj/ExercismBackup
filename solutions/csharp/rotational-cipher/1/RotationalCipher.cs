public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey) => string.Concat(text.Select(c => Rotate(c, shiftKey)));

    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    private static char Rotate(char value, int shiftKey)
    {
        var isLower = char.IsLower(value);
        var lowerValue = isLower ? value : char.ToLower(value);
        
        if (!Alphabet.Contains(lowerValue))
        {
            return value;
        }
        
        var index = Alphabet.IndexOf(lowerValue);
        var newIndex = index + shiftKey < Alphabet.Length ? index + shiftKey : index + shiftKey - Alphabet.Length;
        
        return isLower ? Alphabet[newIndex] : char.ToUpper(Alphabet[newIndex]);
    }
}