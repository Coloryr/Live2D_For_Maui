using Microsoft.Maui.Controls.Compatibility;

namespace MauiApp1;

public static class MauiProgram
{
	static bool isLoad;
	public static MauiApp CreateMauiApp()
	{
		var assemblies = Device.GetAssemblies();
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			})
			.ConfigureMauiHandlers(handlers =>
			{
				handlers.AddCompatibilityRenderers(assemblies);
			})
			.ConfigureEffects(effects =>
			{
				if (isLoad)
					return;
				effects.AddCompatibilityEffects(assemblies);
				isLoad = true;
				OpenGLPage.page.bind();
			});

		return builder.Build();
	}
}
