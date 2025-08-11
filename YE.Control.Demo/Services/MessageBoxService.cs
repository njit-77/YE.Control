namespace YE.Control.Demo.Services;

class MessageBoxService : IServers.IMessageBoxService
{
    private readonly IServers.ILogger logger;

    public MessageBoxService(IServers.ILogger _logger)
    {
        logger = _logger;
    }

    public bool ShowMessage(string message, IServers.MessageLevel messageLevel)
    {
        System.Windows.MessageBoxResult result = System.Windows.MessageBoxResult.None;
        switch (messageLevel)
        {
            case IServers.MessageLevel.Information:

                {
                    logger.Info("MessageBox:{message}", message);

                    result = System.Windows.MessageBox.Show(
                        message,
                        "Information",
                        System.Windows.MessageBoxButton.OKCancel,
                        System.Windows.MessageBoxImage.Information,
                        System.Windows.MessageBoxResult.None,
                        System.Windows.MessageBoxOptions.DefaultDesktopOnly
                    );

                    logger.Info("MessageBoxResult:{result}", result);
                }
                break;
            case IServers.MessageLevel.Warning:

                {
                    logger.Warn("MessageBox:{message}", message);

                    result = System.Windows.MessageBox.Show(
                        message,
                        "Warning",
                        System.Windows.MessageBoxButton.OKCancel,
                        System.Windows.MessageBoxImage.Warning,
                        System.Windows.MessageBoxResult.None,
                        System.Windows.MessageBoxOptions.DefaultDesktopOnly
                    );

                    logger.Warn("MessageBoxResult:{result}", result);
                }
                break;
            case IServers.MessageLevel.Error:

                {
                    logger.Error("MessageBox:{message}", message);

                    result = System.Windows.MessageBox.Show(
                        message,
                        "Error",
                        System.Windows.MessageBoxButton.OKCancel,
                        System.Windows.MessageBoxImage.Error,
                        System.Windows.MessageBoxResult.None,
                        System.Windows.MessageBoxOptions.DefaultDesktopOnly
                    );

                    logger.Error("MessageBoxResult:{result}", result);
                }
                break;
            default:
                break;
        }
        return result == System.Windows.MessageBoxResult.OK;
    }
}
