using Maui5eClient.Extensions;

namespace Maui5eClient;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .RegisterFonts()
            .RegisterHandlers()
            .RegisterServices();

        return builder.Build();
    }
}