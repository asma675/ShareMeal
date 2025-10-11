using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FoodRescueApp.ViewModels;

public partial class RegisterAccountViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isRestaurantSelected;
    
    [ObservableProperty]
    private bool isFoodBankSelected;
    
    [ObservableProperty]
    private bool isVolunteerSelected;
    
    [ObservableProperty]
    private bool isFormVisible;
    
    [ObservableProperty]
    private string registrationTitle = "Create Account";
    
    [ObservableProperty]
    private string fullName = string.Empty;
    
    [ObservableProperty]
    private string email = string.Empty;
    
    [ObservableProperty]
    private string phone = string.Empty;
    
    [ObservableProperty]
    private string password = string.Empty;
    
    [ObservableProperty]
    private string confirmPassword = string.Empty;
    
    [ObservableProperty]
    private string restaurantName = string.Empty;
    
    [ObservableProperty]
    private string selectedCuisine = string.Empty;
    
    [ObservableProperty]
    private string donationTypes = string.Empty;
    
    [ObservableProperty]
    private string organizationName = string.Empty;
    
    [ObservableProperty]
    private string selectedFoodType = string.Empty;
    
    [ObservableProperty]
    private string address = string.Empty;
    
    [ObservableProperty]
    private bool hasLocation;
    
    [ObservableProperty]
    private string formattedAddress = string.Empty;
    
    [ObservableProperty]
    private bool canSubmit;

    public List<string> CuisineTypes { get; } = new()
    {
        "American", "Italian", "Mexican", "Chinese", "Indian", 
        "Japanese", "Thai", "French", "Mediterranean", "Vegetarian", "Halal", "Other"
    };

    public List<string> AcceptedFoodTypes { get; } = new()
    {
        "Prepared Meals", "Fresh Produce", "Baked Goods", "Dairy", 
        "Meat & Poultry", "Canned Goods", "Non-Perishables", "All Types"
    };

    [RelayCommand]
    private void SelectRestaurant()
    {
        IsRestaurantSelected = true;
        IsFoodBankSelected = false;
        IsVolunteerSelected = false;
        IsFormVisible = true;
        RegistrationTitle = "Restaurant Registration";
        UpdateCanSubmit();
    }

    [RelayCommand]
    private void SelectFoodBank()
    {
        IsRestaurantSelected = false;
        IsFoodBankSelected = true;
        IsVolunteerSelected = false;
        IsFormVisible = true;
        RegistrationTitle = "Food Bank Registration";
        UpdateCanSubmit();
    }

    [RelayCommand]
    private void SelectVolunteer()
    {
        IsRestaurantSelected = false;
        IsFoodBankSelected = false;
        IsVolunteerSelected = true;
        IsFormVisible = true;
        RegistrationTitle = "Volunteer Registration";
        UpdateCanSubmit();
    }

    [RelayCommand]
    private async Task GetCurrentLocation()
    {
        try
        {
            
            HasLocation = true;
            FormattedAddress = "123 Main St, Downtown (Sample Location)";
            Address = FormattedAddress;
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Location Error", 
                "Unable to get location. Please enter manually.", "OK");
        }
    }

    [RelayCommand]
    private async Task SubmitRegistration()
    {
        if (!CanSubmit) return;

        // Validate passwords match
        if (Password != ConfirmPassword)
        {
            await Application.Current.MainPage.DisplayAlert("Error", 
                "Passwords do not match.", "OK");
            return;
        }

        // Simulate registration process
        await Application.Current.MainPage.DisplayAlert("Success!", 
            $"Welcome to Food Rescue, {FullName}! Your {RegistrationTitle.ToLower()} is complete.", "OK");

        // Navigate to appropriate page 
        if (IsRestaurantSelected)
            await Shell.Current.GoToAsync("//Partners");
        else if (IsVolunteerSelected)
            await Shell.Current.GoToAsync("//Volunteer");
        else
            await Shell.Current.GoToAsync("//Home");
    }

    partial void OnFullNameChanged(string value) => UpdateCanSubmit();
    partial void OnEmailChanged(string value) => UpdateCanSubmit();
    partial void OnPasswordChanged(string value) => UpdateCanSubmit();
    partial void OnConfirmPasswordChanged(string value) => UpdateCanSubmit();

    private void UpdateCanSubmit()
    {
        CanSubmit = !string.IsNullOrWhiteSpace(FullName) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(Password) &&
                   !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                   (IsRestaurantSelected || IsFoodBankSelected || IsVolunteerSelected);
    }
}