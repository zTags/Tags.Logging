using System.Collections.Immutable;

namespace Tags.Logging;

/// <summary>
/// Contains all the basic logging functions
/// </summary>
public static class Logger 
{
    /// <summary>
    /// Used in Conjuction with <see cref="Tags.Logging.Logger.RegisterLogFunction(Action{string, ConsoleColor})">RegisterLogFunction</see>
    /// </summary>
    public static readonly Action<string, ConsoleColor> toConsole = (s, c) => {
        Console.ForegroundColor = c;
        Console.WriteLine(s);
        Console.ResetColor();
    };

    private const string DATETIME_FORMAT = "hh\\:mm\\:s\\.fff";

    private static DateTime startTime;
    private static ImmutableArray<Action<string>> functions;
    private static ImmutableArray<Action<string, ConsoleColor>> colorizedFunctions;

    static Logger()
    {
        startTime = DateTime.Now;
        functions = ImmutableArray<Action<string>>.Empty;
        colorizedFunctions = ImmutableArray<Action<string, ConsoleColor>>.Empty;
    }

    /// <summary>
    /// Register a logging function, for example if you want a GUI logging pane
    /// </summary>
    public static void RegisterLogFunction(Action<string> f) =>
        functions = functions.Add(f);

    /// <summary>
    /// Same as <see cref="Tags.Logging.Logger.RegisterLogFunction(Action{string})">RegisterLogFunction</see>, but with a color attached
    /// </summary>
    public static void RegisterLogFunction(Action<string, ConsoleColor> f) =>
        colorizedFunctions = colorizedFunctions.Add(f);

    /// <summary>
    /// Emit a debug message
    /// </summary>
    public static void Debug(object msg)
    {
        string timePassedSinceStart = DateTime.Now.Subtract(startTime).ToString(DATETIME_FORMAT);
        foreach (Action<string> f in functions)
            f($"[{timePassedSinceStart}] [DEBUG] [DEFAULT] {msg}"); 
        foreach (Action<string, ConsoleColor> f in colorizedFunctions)
            f($"[{timePassedSinceStart}] [DEBUG] [DEFAULT] {msg}", ConsoleColor.Gray);
    }

    /// <summary>
    /// Emit a debug message with a sender
    /// </summary>
    public static void Debug(object msg, Sender s)
    {
        string timePassedSinceStart = DateTime.Now.Subtract(startTime).ToString(DATETIME_FORMAT);
        foreach (Action<string> f in functions)
            f($"[{timePassedSinceStart}] [DEBUG] [{s.Name}] {msg}"); 
        foreach (Action<string, ConsoleColor> f in colorizedFunctions)
            f($"[{timePassedSinceStart}] [DEBUG] [{s.Name}] {msg}", ConsoleColor.Gray);
    }

    /// <summary>
    /// Emit a info message
    /// </summary>
    public static void Info(object msg)
    {
        string timePassedSinceStart = DateTime.Now.Subtract(startTime).ToString(DATETIME_FORMAT);
        foreach (Action<string> f in functions)
            f($"[{timePassedSinceStart}] [INFO]  [DEFAULT] {msg}"); 
        foreach (Action<string, ConsoleColor> f in colorizedFunctions)
            f($"[{timePassedSinceStart}] [INFO]  [DEFAULT] {msg}", ConsoleColor.Blue);
    }

    /// <summary>
    /// Emit a info message with a sender
    /// </summary>
    public static void Info(object msg, Sender s)
    {
        string timePassedSinceStart = DateTime.Now.Subtract(startTime).ToString(DATETIME_FORMAT);
        foreach (Action<string> f in functions)
            f($"[{timePassedSinceStart}] [INFO]  [{s.Name}] {msg}"); 
        foreach (Action<string, ConsoleColor> f in colorizedFunctions)
            f($"[{timePassedSinceStart}] [INFO]  [{s.Name}] {msg}", ConsoleColor.Blue);
    }

    /// <summary>
    /// Emit a warn message
    /// </summary>
    public static void Warn(object msg)
    {
        string timePassedSinceStart = DateTime.Now.Subtract(startTime).ToString(DATETIME_FORMAT);
        foreach (Action<string> f in functions)
            f($"[{timePassedSinceStart}] [WARN]  [DEFAULT] {msg}"); 
        foreach (Action<string, ConsoleColor> f in colorizedFunctions)
            f($"[{timePassedSinceStart}] [WARN]  [DEFAULT] {msg}", ConsoleColor.Yellow);
    }

    /// <summary>
    /// Emit a Warn message with a sender
    /// </summary>
    public static void Warn(object msg, Sender s)
    {
        string timePassedSinceStart = DateTime.Now.Subtract(startTime).ToString(DATETIME_FORMAT);
        foreach (Action<string> f in functions)
            f($"[{timePassedSinceStart}] [WARN]  [{s.Name}] {msg}"); 
        foreach (Action<string, ConsoleColor> f in colorizedFunctions)
            f($"[{timePassedSinceStart}] [WARN]  [{s.Name}] {msg}", ConsoleColor.Yellow);
    }

    /// <summary>
    /// Emit a error message
    /// </summary>
    public static void Error(object msg)
    {
        string timePassedSinceStart = DateTime.Now.Subtract(startTime).ToString(DATETIME_FORMAT);
        foreach (Action<string> f in functions)
            f($"[{timePassedSinceStart}] [ERROR] [DEFAULT] {msg}"); 
        foreach (Action<string, ConsoleColor> f in colorizedFunctions)
            f($"[{timePassedSinceStart}] [ERROR] [DEFAULT] {msg}", ConsoleColor.Red);
    }

    /// <summary>
    /// Emit a error message with a sender
    /// </summary>
    public static void Error(object msg, Sender s)
    {
        string timePassedSinceStart = DateTime.Now.Subtract(startTime).ToString(DATETIME_FORMAT);
        foreach (Action<string> f in functions)
            f($"[{timePassedSinceStart}] [ERROR] [{s.Name}] {msg}"); 
        foreach (Action<string, ConsoleColor> f in colorizedFunctions)
            f($"[{timePassedSinceStart}] [ERROR] [{s.Name}] {msg}", ConsoleColor.Red);
    }

    /// <summary>
    /// Same as <see cref="Tags.Logging.Logger.Error(object)">Error</see>, but exits after logging. Consider writing a stack trace first.
    /// </summary>
    public static void Fatal(object msg)
    {
        string timePassedSinceStart = DateTime.Now.Subtract(startTime).ToString(DATETIME_FORMAT);
        foreach (Action<string> f in functions)
            f($"[{timePassedSinceStart}] [FATAL] [DEFAULT] {msg}"); 
        foreach (Action<string, ConsoleColor> f in colorizedFunctions)
            f($"[{timePassedSinceStart}] [FATAL] [DEFAULT] {msg}", ConsoleColor.Red);
        Environment.Exit(1);
    }

    /// <summary>
    /// Same as <see cref="Tags.Logging.Logger.Error(object, Sender)">Error</see>, but exits after logging. Consider writing a stack trace first.
    /// </summary>
    public static void Fatal(object msg, Sender s)
    {
        string timePassedSinceStart = DateTime.Now.Subtract(startTime).ToString(DATETIME_FORMAT);
        foreach (Action<string> f in functions)
            f($"[{timePassedSinceStart}] [FATAL] [{s.Name}] {msg}"); 
        foreach (Action<string, ConsoleColor> f in colorizedFunctions)
            f($"[{timePassedSinceStart}] [FATAL] [{s.Name}] {msg}", ConsoleColor.Red);
        Environment.Exit(1);
    }
}