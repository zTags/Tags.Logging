namespace Tags.Logging;

/// <summary>
/// Describes a message sender
/// </summary>
public struct Sender
{
    private string name;
    /// <summary>
    /// The name of the sender
    /// </summary>
    public string Name { get => name; }

    /// <summary>
    /// Creates a new sender
    /// </summary>
    public Sender(string name)
    {
        this.name = name;
    }

    /// <summary>
    /// Emit a debug message
    /// </summary>
    public void Debug(object msg) => Logger.Debug(msg, this);

    /// <summary>
    /// Emit a info message
    /// </summary>
    public void Info(object msg)  => Logger.Info(msg, this);

    /// <summary>
    /// Emit a Warn message
    /// </summary>
    public void Warn(object msg)  => Logger.Warn(msg, this);

    /// <summary>
    /// Emit a Error message
    /// </summary>
    public void Error(object msg) => Logger.Error(msg, this);

    /// <summary>
    /// Emit a info message and exit
    /// </summary>
    public void Fatal(object msg) => Logger.Fatal(msg, this);
}