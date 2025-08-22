public static class Pangram
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static bool IsPangram(string input) => 
        Alphabet.All(input.ToLower().Contains);
}
