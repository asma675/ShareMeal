namespace FoodRescueApp.Models;

public enum PartnerType
{
    FoodBank,
    Restaurant,
    CommunityFridge,
    NGO
}

public enum ActivityStatus
{
    Active,
    Inactive,
    Pending
}

public class Partner
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public PartnerType Type { get; set; }
    public ActivityStatus Status { get; set; }
    public List<string> DonationPreferences { get; set; } = new();
    public List<string> NeedPreferences { get; set; } = new();
    public DateTime LastActivity { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Description { get; set; } = string.Empty;
    public int TotalDonations { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    
    public string StatusColor => Status switch
    {
        ActivityStatus.Active => "#4CAF50",
        ActivityStatus.Inactive => "#9E9E9E",
        ActivityStatus.Pending => "#FF9800",
        _ => "#9E9E9E"
    };
    
    public string TypeIcon => Type switch
    {
        PartnerType.FoodBank => "🏪",
        PartnerType.Restaurant => "🍽️",
        PartnerType.CommunityFridge => "❄️",
        PartnerType.NGO => "🤝",
        _ => "📍"
    };
}