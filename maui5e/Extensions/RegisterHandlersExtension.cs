namespace maui5e.Extensions;

public static class RegisterHandlersExtension
{
    public static MauiAppBuilder RegisterHandlers(this MauiAppBuilder builder)
    {
        return builder.ConfigureMauiHandlers(handlers =>
        {
            // Your handlers here...
            //handlers.AddHandler(typeof(MyEntry), typeof(MyEntryHandler));
        });
    }
}