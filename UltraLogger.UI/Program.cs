using Microsoft.Extensions.DependencyInjection;

using UltraLogger.Core;

namespace UltraLogger.UI;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddInfrastructureServices();
        services.AddApplicationServices();
        services.AddUIServices();

        ServiceProvider serviceProvider = services.BuildServiceProvider();

        ApplicationConfiguration.Initialize();
        Application.Run(serviceProvider.GetService<MainForm>()!);
    }
}