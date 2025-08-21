using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public static class DiffieHellman
{
    private static IEnumerable<BigInteger> BigIntegerGenerator(Random random, byte[] bytes)
    {
        while (true)
        {
            random.NextBytes(bytes);
            yield return new BigInteger(bytes);
        }
    }
    
    public static BigInteger PrivateKey(BigInteger primeP)
    {
        return BigIntegerGenerator(
                Random.Shared,
                primeP.ToByteArray())
            .First(bigInteger => 1 < bigInteger && bigInteger < primeP);
    }

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey)
    {
        return BigInteger.Pow(primeG, (int)privateKey) % primeP;
    }

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey)
    {
        return BigInteger.Pow(publicKey, (int)privateKey) % primeP;
    }
}