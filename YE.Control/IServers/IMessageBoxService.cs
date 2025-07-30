namespace YE.Control.IServers;

public interface IMessageBoxService
{
    bool ShowMessage(string message, MessageLevel messageLevel);
}

public enum MessageLevel
{
    Information,

    Warning,

    Error,
}
