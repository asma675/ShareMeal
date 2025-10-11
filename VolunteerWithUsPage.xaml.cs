using FoodRescueApp.ViewModels;

namespace FoodRescueApp.Views;

public partial class VolunteerWithUsPage : ContentPage
{
    public VolunteerWithUsPage(VolunteerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}