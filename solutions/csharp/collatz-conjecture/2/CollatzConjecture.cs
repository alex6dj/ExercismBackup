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
            if (value % 2 == 0)
            {
                value = value / 2;
            }
            else
            {
                value = value * 3 + 1;
            }
        }
        
        return steps;
    }
}