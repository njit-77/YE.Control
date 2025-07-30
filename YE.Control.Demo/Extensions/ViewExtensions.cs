using Microsoft.Extensions.DependencyInjection;

namespace YE.Control.Demo.Extensions;

public static class ViewExtensions
{
    public static void AddViews(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton(sp => new MainWindow()
        {
            DataContext = sp.GetRequiredService<MainViewModel>()
        });
        serviceCollection.AddSingleton<MainViewModel>();
    }
}
