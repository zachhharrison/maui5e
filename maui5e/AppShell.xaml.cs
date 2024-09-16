namespace maui5e;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("ClassPage", typeof(ClassPage));
        Routing.RegisterRoute("HomeCSharp", typeof(HomePage));
    }
}