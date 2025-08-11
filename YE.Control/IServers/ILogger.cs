namespace YE.Control.IServers;

public interface ILogger
{
    void Debug(string format, params object[] args);

    void Info(string format, params object[] args);

    void Warn(string format, params object[] args);

    void Error(string format, params object[] args);

    void Fatal(string format, params object[] args);

    bool IsEnabled { get; set; }

    LogLevel Level { get; set; }
}

public enum LogLevel
{
    All = 0,

    Debug,

    Info,

    Warn,

    Error,

    Fatal,

    Off = 0xff,
}
