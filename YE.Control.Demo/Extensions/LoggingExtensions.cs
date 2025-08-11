using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace YE.Control.Demo.Extensions;

public static class LoggingExtensions
{
    public static void AddLogger(this IServiceCollection serviceCollection)
    {
        NLog.LogManager.Setup()
            .LoadConfiguration(builder =>
            {
                builder
                    .ForLogger()
                    .FilterMinLevel(LogLevel.Trace)
                    .WriteToConsole(
                        encoding: System.Text.Encoding.UTF8,
                        layout: "${longdate} [ThreadID:${threadid}] [${level}] ${message} ${exception:format=ToString}"
                    );
                builder
                    .ForLogger()
                    .FilterMinLevel(LogLevel.Trace)
                    .WriteToFile(
                        fileName: "${basedir}/log/log${date:yyyyMMdd}.log",
                        encoding: System.Text.Encoding.UTF8,
                        layout: "${longdate} [ThreadID:${threadid}] [${level}] ${message} ${exception:format=ToString}"
                    );
            });

        serviceCollection.AddSingleton<NLog.ILogger>(_ =>
        {
            return NLog.LogManager.GetCurrentClassLogger();
        });

        serviceCollection.AddSingleton<IServers.ILogger, Services.Logger>();
    }

    [DllImport("kernel32.dll")]
    public static extern bool AllocConsole();

    [DllImport("kernel32.dll")]
    public static extern bool FreeConsole();
}
