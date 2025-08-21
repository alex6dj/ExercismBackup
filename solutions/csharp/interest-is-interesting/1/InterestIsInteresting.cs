using System;
using System.Diagnostics;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        return balance switch
        {
            < 0 => 3.213f,
            >= 0 and < 1000 => 0.5f,
            >= 1000 and < 5000 => 1.621f,
            _ => 2.475f
        };
    }

    public static decimal Interest(decimal balance)
    {
        return balance * (decimal)InterestRate(balance) / 100m;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var round = 0;
        var cumulativeBalance = balance;

        while (cumulativeBalance < targetBalance)
        {
            cumulativeBalance = AnnualBalanceUpdate(cumulativeBalance);
            round++;
        }

        return round;
    }
}
