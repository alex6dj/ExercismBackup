public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand == string.Empty && secondStrand != string.Empty ||
            firstStrand != string.Empty && secondStrand == string.Empty ||
            firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException();
        }

        var distance = 0;

        for (var i = 0; i < firstStrand.Length; i++)
        {
            if (firstStrand[i] != secondStrand[i])
            {
                distance++;
            }
        }

        return distance;
    }
}