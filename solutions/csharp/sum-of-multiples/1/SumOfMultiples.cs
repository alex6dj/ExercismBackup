using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max) =>
        Generate(max).Where(x => IsMultiple(multiples.Where(m => m != 0), x)).Sum();

    private static IEnumerable<int> Generate(int max) => 
        Enumerable.Range(1, max - 1);

    private static bool IsMultiple(IEnumerable<int> multiples, int value) => 
        multiples.Any(x => value % x == 0);
}