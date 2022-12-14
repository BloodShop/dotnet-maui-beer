using SheetaBeer.Services;
using SheetaBeer.View;

namespace SheetaBeer;

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
		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
		builder.Services.AddSingleton<IMap>(Map.Default);

		builder.Services.AddSingleton<BeerService>();

		builder.Services.AddSingleton<BeersViewModel>();
		builder.Services.AddTransient<BeerDetailsViewModel>();

		builder.Services.AddSingleton<BeersPage>();
		builder.Services.AddTransient<DetailsPage>();

		return builder.Build();
	}
}