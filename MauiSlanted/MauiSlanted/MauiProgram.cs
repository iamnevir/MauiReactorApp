using MauiReactor;
using MauiSlanted.Pages;


namespace MauiSlanted
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiReactorApp<MainPage>()
#if DEBUG
            .EnableMauiReactorHotReload()
#endif
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                });

            return builder.Build();
        }
    }
}