using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        var values = Enumerable.Range(1, max);
        var sum = values.Sum();
        var square = sum * sum;

        return square;
    }

    public static int CalculateSumOfSquares(int max)
    {
        var values = Enumerable.Range(1, max);
        var squares = values.Select(x => x * x);
        var sum = squares.Sum();
        
        return sum;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        var difference = CalculateSquareOfSum(max) - CalculateSumOfSquares(max);

        return difference;
    }
}