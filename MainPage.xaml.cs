namespace FoodRescueApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnPartnerDirectoryClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Partners");
    }
}