using System.Diagnostics;

namespace MauiApp1;

public partial class App : Application
{
	public static Application app;
	public App()
	{
		app = this;
		InitializeComponent();

        MainPage = new OpenGLPage();
	}
}
