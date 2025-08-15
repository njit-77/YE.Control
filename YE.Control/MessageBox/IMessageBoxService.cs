namespace YE.Control.MessageBox;

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
