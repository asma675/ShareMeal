using FoodRescueWeb.Models;

namespace FoodRescueWeb.Services;

public class PartnerService
{
    public List<Partner> GetPartners()
    {
        return new List<Partner>
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
    }
}