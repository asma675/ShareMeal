namespace ShareMeal.Views;
public partial class ChooseRolePage : ContentPage
{
    public ChooseRolePage()
    {
        InitializeComponent();
    }

    private async void GoBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void GoRestaurant(object sender, EventArgs e)
    {
        await DisplayAlert("Coming soon", "Restaurant onboarding will be added here.", "OK");
    }

    private async void GoFoodBank(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("foodbank/signup");
    }
}
