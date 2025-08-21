using System;

public class Player
{
    private Random _random = new Random();

    public int RollDie()
    {
        return _random.Next(1, 18);
    }

    public double GenerateSpellStrength()
    {
        return (double) _random.Next(0, 1000) / 10;
    }
}
