using Ground2Plate.Maui.Custom;
using Ground2Plate.Maui.Pages;
using Ground2Plate.Maui.ViewModels;
using Microsoft.Extensions.Logging;

namespace Ground2Plate.Maui
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
                    fonts.AddFont("PTSerifCaption-Regular.ttf", "PTSerifCaption");
                });

            builder.RegisterViewModels();
            builder.RegisterPages();
            builder.RegisterServices();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
