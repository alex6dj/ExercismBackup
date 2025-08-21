using System.Collections.Generic;

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine) =>
        LogMap.TryGetValue(logLine[1..4], out var logLevel) ? 
            logLevel :
            LogLevel.Unknown;

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{logLevel:D}:{message}";

    private static readonly Dictionary<string, LogLevel> LogMap = new()
    {
        { "TRC", LogLevel.Trace },
        { "DBG", LogLevel.Debug },
        { "INF", LogLevel.Info },
        { "WRN", LogLevel.Warning },
        { "ERR", LogLevel.Error },
        { "FTL", LogLevel.Fatal }
    };
}

enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}
