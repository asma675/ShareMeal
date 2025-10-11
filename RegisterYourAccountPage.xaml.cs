using FoodRescueApp.ViewModels;

namespace FoodRescueApp.Views;

public partial class RegisterYourAccountPage : ContentPage
{
    public RegisterYourAccountPage(RegisterAccountViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}