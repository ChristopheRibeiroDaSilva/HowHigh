
using CommunityToolkit.Maui;
using HowHigh.MobileApp.ViewModels;
using HowHigh.MobileApp.Views;

namespace HowHigh.MobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //builder.Services.AddSingleton<LoadingPage>();
            /*builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<SignInPage>();


            builder.Services.AddTransient<LoadingPage>();
*/
            builder.Services.AddTransient<PlayViewModel>();
            builder.Services.AddTransient<PlayPage>();

            builder.Services.AddSingleton<UserViewModel>();
            builder.Services.AddSingleton<UserPage>();

            return builder.Build();
        }
    }
}