namespace Maui5eClient.Extensions;

public static class RegisterFontsExtension
{
    public static MauiAppBuilder RegisterFonts(this MauiAppBuilder builder)
    {
        return builder.ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });
    }
}