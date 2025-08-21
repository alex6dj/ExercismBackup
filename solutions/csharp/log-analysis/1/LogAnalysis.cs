using System;

public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string log, string value)
    {
        var split = log.Split(value);
        return split[1];
    }
    
    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string log, string first, string second)
    {
        var firstIndex = log.IndexOf(first) + first.Length;
        var secondIndex = log.IndexOf(second);

        var length = secondIndex - firstIndex;
        
        var result = log.Substring(firstIndex, length);

        return result;
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string log)
    {
        var split = log.Split(':');

        return split[1].Trim();
    }
    
    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string log)
    {
        return log.SubstringBetween("[", "]");
    }
}