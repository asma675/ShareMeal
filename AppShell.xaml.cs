using Microsoft.Maui.Controls;

namespace ShareMealApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("intro", typeof(Views.IntroPage));
        Routing.RegisterRoute("getstarted", typeof(Views.GetStartedPage));
    }
}