using Application = Microsoft.Maui.Controls.Application;

namespace Maui_NAudio;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}
}
