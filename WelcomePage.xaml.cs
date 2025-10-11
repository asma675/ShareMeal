namespace ShareMeal.Views;
public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    private async void GoNext(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("choose");
    }
}
