namespace YE.Control.MessageBox;

public interface IMessageBoxService
{
    bool ShowMessage(string message, MessageLevel messageLevel);

    void ShowException(System.Exception exception, ExceptionType exceptionType);
}

public enum MessageLevel
{
    Information,

    Warning,

    Error,
}

public enum ExceptionType
{
    _UI,

    _非UI,

    _Task,

    _非托管代码,
}