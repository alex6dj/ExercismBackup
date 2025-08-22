public static class ReverseString
{
    public static string Reverse(string input)
    {
        if (input == string.Empty)
        {
            return string.Empty;
        }

        return input.Reverse().Aggregate(string.Empty, (current, next) => current + next);
    }
}