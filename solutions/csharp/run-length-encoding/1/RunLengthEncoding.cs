using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        var sb = new StringBuilder();
        sb.AppendJoin(string.Empty, CutAndCount(input));
        return sb.ToString();
    }

    public static IEnumerable<string> CutAndCount(string input)
    {
        if (input.Length == 0)
        {
            yield return "";
            yield break;
        }

        var indexes = new List<int>();

        for (var i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                indexes.Add(i);
            }
        }

        switch (indexes.Count)
        {
            case 0:
                yield return input.Length > 1 ? $"{input.Length}{input[0]}" : input;
                yield break;
            case > 0:
                yield return indexes[0] > 1 ? $"{indexes[0]}{input[0]}" : input[0].ToString();
                break;
        }

        for (var i = 1; i < indexes.Count; i++)
        {
            yield return indexes[i] - indexes[i - 1] > 1
                ? $"{indexes[i] - indexes[i - 1]}{input[indexes[i - 1]]}"
                : input[indexes[i - 1]].ToString();
        }

        yield return input.Length - indexes[^1] > 1
            ? $"{input.Length - indexes[^1]}{input[indexes[^1]]}"
            : input[^1].ToString();
    }

    public static string Decode(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var result = new StringBuilder();
        var count = 0;

        foreach (var c in input)
        {
            if (!char.IsDigit(c))
            {
                if (count == 0)
                {
                    count = 1;
                }

                result.Append(c, count);
                count = 0;
            }
            else
            {
                count = count * 10 + (int)char.GetNumericValue(c);
            }
        }

        return result.ToString();
    }
}