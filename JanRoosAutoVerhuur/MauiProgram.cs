using Microsoft.Extensions.Logging;
using JanRoosAutoVerhuur.Viewmodel;

namespace JanRoosAutoVerhuur
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
                    fonts.AddFont("OpenSans-BoldItalic.ttf", "OpenSansBoldItalic");
                    fonts.AddFont("OpenSans-ExtraBold.ttf", "OpenSansExtraBold");
                    fonts.AddFont("OpenSans-ExtraBoldItalic.ttf", "OpenSansExtraBoldItalic");
                    fonts.AddFont("OpenSans-Italic.ttf", "OpenSansItalic");
                    fonts.AddFont("OpenSans-Light.ttf", "OpenSansLight");
                    fonts.AddFont("OpenSans-LightItalic.ttf", "OpenSansLightItalic");
                    fonts.AddFont("OpenSans-SemiboldItalic.ttf", "OpenSansSemiboldItalic");
                });
                builder.Services.AddTransient<MainPage>();
                builder.Services.AddTransient<MainViewModel>();
                builder.Services.AddTransient<Signup>();
                builder.Services.AddTransient<SignUpViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
