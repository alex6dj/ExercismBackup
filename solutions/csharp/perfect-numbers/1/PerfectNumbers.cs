public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        if (number == 1)
        {
            return Classification.Deficient;
        }
        
        var sum = CalculateProperDivisorsSum(number);
        if (sum == number)
        {
            return Classification.Perfect;
        }
        if (sum > number)
        {
            return Classification.Abundant;
        }

        return Classification.Deficient;
    }

    private static int CalculateProperDivisorsSum(int number)
    {
        int sum = 1;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i != 0)
            {
                continue;
            }

            sum += i;
            if (i * i != number)
            {
                sum += number / i;
            }
        }

        return sum;
    }
}
