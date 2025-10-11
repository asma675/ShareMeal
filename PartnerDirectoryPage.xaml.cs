using FoodRescueApp.ViewModels;

namespace FoodRescueApp.Views;

public partial class PartnerDirectoryPage : ContentPage
{
    public PartnerDirectoryPage(PartnerDirectoryViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}