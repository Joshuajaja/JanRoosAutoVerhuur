using Microsoft.Extensions.DependencyInjection;

namespace JanRoosAutoVerhuur
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); // gewoon zo laten
        }
    }
}