using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        var split = logLine.Split(':');

        return split[1].Trim();
    }

    public static string LogLevel(string logLine)
    {
        var split = logLine.Split(':');

        return split[0].Trim('[', ']').ToLowerInvariant();
    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
}
