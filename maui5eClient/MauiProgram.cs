using CommunityToolkit.Maui.Markup;
using maui5eClient.Extensions;

namespace maui5eClient;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitMarkup()
            .RegisterFonts()
            .RegisterHandlers()
            .RegisterServices();

        return builder.Build();
    }
}