namespace YE.Control.Demo.Services
{
    internal class Logger : IServers.ILogger
    {
        public bool IsEnabled { get; set; } = true;

        public IServers.LogLevel Level { get; set; } = IServers.LogLevel.All;

        public void Debug(string format, params object[] args) =>
            Write(IServers.LogLevel.Debug, format, args);

        public void Info(string format, params object[] args) =>
            Write(IServers.LogLevel.Info, format, args);

        public void Warn(string format, params object[] args) =>
            Write(IServers.LogLevel.Warn, format, args);

        public void Error(string format, params object[] args) =>
            Write(IServers.LogLevel.Error, format, args);

        public void Fatal(string format, params object[] args) =>
            Write(IServers.LogLevel.Fatal, format, args);

        private void Write(IServers.LogLevel logLevel, string format, params object[] args)
        {
            if (IsEnabled && logLevel >= Level)
            {
                var logger = App.Current.GetService<NLog.ILogger>();

                switch (logLevel)
                {
                    case IServers.LogLevel.All:
                        break;
                    case IServers.LogLevel.Debug:

                        {
                            logger.Debug(format, args);
                        }
                        break;
                    case IServers.LogLevel.Info:

                        {
                            logger.Info(format, args);
                        }
                        break;
                    case IServers.LogLevel.Warn:

                        {
                            logger.Warn(format, args);
                        }
                        break;
                    case IServers.LogLevel.Error:

                        {
                            logger.Error(format, args);
                        }
                        break;
                    case IServers.LogLevel.Fatal:

                        {
                            logger.Debug(format, args);
                        }
                        break;
                    case IServers.LogLevel.Off:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
