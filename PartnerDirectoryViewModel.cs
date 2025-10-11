using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodRescueApp.Models;

namespace FoodRescueApp.ViewModels;

public partial class PartnerDirectoryViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Partner> partners = new();
    
    [ObservableProperty]
    private ObservableCollection<Partner> filteredPartners = new();
    
    [ObservableProperty]
    private string searchText = string.Empty;
    
    [ObservableProperty]
    private PartnerType? selectedType;
    
    [ObservableProperty]
    private ActivityStatus? selectedStatus;
    
    [ObservableProperty]
    private bool isLoading;

    public PartnerDirectoryViewModel()
    {
        LoadSampleData();
    }

    [RelayCommand]
    private async Task LoadPartnersAsync()
    {
        IsLoading = true;
        
        try
        {
            // Simulate API call
            await Task.Delay(1000);
            LoadSampleData();
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private void ApplyFilters()
    {
        var filtered = Partners.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            filtered = filtered.Where(p => 
                p.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                p.City.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                p.Address.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
        }

        if (SelectedType.HasValue)
        {
            filtered = filtered.Where(p => p.Type == SelectedType.Value);
        }

        if (SelectedStatus.HasValue)
        {
            filtered = filtered.Where(p => p.Status == SelectedStatus.Value);
        }

        FilteredPartners.Clear();
        foreach (var partner in filtered)
        {
            FilteredPartners.Add(partner);
        }
    }

    [RelayCommand]
    private void ClearFilters()
    {
        SearchText = string.Empty;
        SelectedType = null;
        SelectedStatus = null;
        ApplyFilters();
    }

    [RelayCommand]
    private async Task ViewPartnerDetailsAsync(Partner partner)
    {
        if (partner == null) return;
        
        // Navigate to partner details page
        await Shell.Current.DisplayAlert("Partner Details", 
            $"Name: {partner.Name}\nType: {partner.Type}\nAddress: {partner.Address}\nPhone: {partner.Phone}", 
            "OK");
    }

    partial void OnSearchTextChanged(string value)
    {
        ApplyFilters();
    }

    partial void OnSelectedTypeChanged(PartnerType? value)
    {
        ApplyFilters();
    }

    partial void OnSelectedStatusChanged(ActivityStatus? value)
    {
        ApplyFilters();
    }

    private void LoadSampleData()
    {
        var samplePartners = new List<Partner>
        {
            new Partner
            {
                Id = 1,
                Name = "Downtown Food Bank",
                Address = "123 Main St",
                City = "Downtown",
                Phone = "+1-555-0101",
                Email = "contact@downtownfoodbank.org",
                Type = PartnerType.FoodBank,
                Status = ActivityStatus.Active,
                NeedPreferences = new List<string> { "Fresh Produce", "Canned Goods", "Dairy" },
                LastActivity = DateTime.Now.AddHours(-2),
                Latitude = 40.7128,
                Longitude = -74.0060,
                Description = "Serving the downtown community for over 20 years",
                TotalDonations = 1250
            },
            new Partner
            {
                Id = 2,
                Name = "Mario's Italian Kitchen",
                Address = "456 Oak Ave",
                City = "Midtown",
                Phone = "+1-555-0102",
                Email = "info@marios.com",
                Type = PartnerType.Restaurant,
                Status = ActivityStatus.Active,
                DonationPreferences = new List<string> { "Prepared Meals", "Bread", "Pasta" },
                LastActivity = DateTime.Now.AddMinutes(-30),
                Latitude = 40.7589,
                Longitude = -73.9851,
                Description = "Family-owned Italian restaurant committed to reducing food waste",
                TotalDonations = 89
            },
            new Partner
            {
                Id = 3,
                Name = "Community Helping Hands",
                Address = "789 Pine St",
                City = "Uptown",
                Phone = "+1-555-0103",
                Email = "help@communityhandsngo.org",
                Type = PartnerType.NGO,
                Status = ActivityStatus.Active,
                NeedPreferences = new List<string> { "Non-Perishables", "Baby Food", "Hygiene Items" },
                LastActivity = DateTime.Now.AddDays(-1),
                Latitude = 40.7831,
                Longitude = -73.9712,
                Description = "NGO focused on supporting families in need",
                TotalDonations = 567
            },
            new Partner
            {
                Id = 4,
                Name = "Green Valley Bistro",
                Address = "321 Elm St",
                City = "Green Valley",
                Phone = "+1-555-0104",
                Email = "contact@greenvalleybistro.com",
                Type = PartnerType.Restaurant,
                Status = ActivityStatus.Pending,
                DonationPreferences = new List<string> { "Organic Produce", "Prepared Salads" },
                LastActivity = DateTime.Now.AddDays(-3),
                Latitude = 40.7505,
                Longitude = -73.9934,
                Description = "Farm-to-table restaurant focusing on sustainability",
                TotalDonations = 23
            },
            new Partner
            {
                Id = 5,
                Name = "Riverside Community Fridge",
                Address = "654 River Rd",
                City = "Riverside",
                Phone = "+1-555-0105",
                Email = "info@riversidecommunityfridge.org",
                Type = PartnerType.CommunityFridge,
                Status = ActivityStatus.Active,
                NeedPreferences = new List<string> { "Fresh Fruits", "Vegetables", "Snacks" },
                LastActivity = DateTime.Now.AddHours(-4),
                Latitude = 40.7282,
                Longitude = -74.0776,
                Description = "24/7 community fridge serving the riverside neighborhood",
                TotalDonations = 892
            }
        };

        Partners.Clear();
        FilteredPartners.Clear();
        
        foreach (var partner in samplePartners)
        {
            Partners.Add(partner);
            FilteredPartners.Add(partner);
        }
    }
}