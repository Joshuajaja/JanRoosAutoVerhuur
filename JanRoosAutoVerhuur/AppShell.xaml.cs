namespace JanRoosAutoVerhuur;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CarDetailPage), typeof(CarDetailPage));
    }
}
