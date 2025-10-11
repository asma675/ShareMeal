using FoodRescueApp.ViewModels;
using FoodRescueApp.Views;
using FoodRescueApp.Converters;

namespace FoodRescueApp;

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
            });

        // Register ViewModels
        builder.Services.AddTransient<PartnerDirectoryViewModel>();
        
        // Register Views
        builder.Services.AddTransient<PartnerDirectoryPage>();

        // Register Converters
        builder.Services.AddSingleton<ListToStringConverter>();
        builder.Services.AddSingleton<IntToBoolConverter>();



        return builder.Build();
    }
}