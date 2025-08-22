public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        var value = number;
        var steps = 0;

        while (value != 1)
        {
            steps++;
            value = value % 2 == 0 ? value / 2 : value * 3 + 1;
        }
        
        return steps;
    }
}