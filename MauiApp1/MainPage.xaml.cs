using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    int count = 0;

	unsafe public MainPage()
	{
		InitializeComponent();
	}
	private void OnCounterClicked(object sender, EventArgs e)
	{
        count++;
		CounterLabel.Text = $"Current count: {count}";

		SemanticScreenReader.Announce(CounterLabel.Text);
	}
}

