using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks; 
using Microsoft.Maui.Controls; 

namespace FoodRescueApp.ViewModels;

public partial class VolunteerTask : ObservableObject
{
    [ObservableProperty]
    private string title = string.Empty;
    
    [ObservableProperty]
    private string pickupLocation = string.Empty;
    
    [ObservableProperty]
    private string dropoffLocation = string.Empty;
    
    [ObservableProperty]
    private string timeWindow = string.Empty;
    
    [ObservableProperty]
    private string urgency = string.Empty;
    
    [ObservableProperty]
    private int points;
    
    [ObservableProperty]
    private double carbonSaved;
    
    [ObservableProperty]
    private bool isAccepted;

    public string UrgencyColor => Urgency switch
    {
        "Urgent" => "#dc3545",
        "High" => "#fd7e14", 
        "Medium" => "#ffc107",
        "Low" => "#198754",
        _ => "#6c757d"
    };
}

public partial class VolunteerViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<VolunteerTask> availableTasks = new();
    
    [ObservableProperty]
    private int availableTasksCount;
    
    [ObservableProperty]
    private int totalPoints;
    
    [ObservableProperty]
    private bool hasNoTasks;

    public VolunteerViewModel()
    {
        LoadSampleTasks();
        AvailableTasksCount = AvailableTasks.Count;
        TotalPoints = 245; // Sample points
        HasNoTasks = !AvailableTasks.Any();
    }

    [RelayCommand]
    private async Task AcceptTask(VolunteerTask task)
    {
        if (task == null) return;

        var confirmed = await Application.Current.MainPage.DisplayAlert(
            "Accept Task", 
            $"Accept this delivery task for {task.Points} points?", 
            "Yes, Accept", "Cancel");

        if (confirmed)
        {
            task.IsAccepted = true;
            AvailableTasks.Remove(task);
            AvailableTasksCount = AvailableTasks.Count;
            TotalPoints += task.Points;
            HasNoTasks = !AvailableTasks.Any();

            await Application.Current.MainPage.DisplayAlert(
                "Task Accepted!", 
                $"" + $"You've accepted: {task.Title}\nYou earned {task.Points} points!", 
                "OK");
        }
    }

    [RelayCommand]
    private async Task ViewMyTasks()
    {
        await Application.Current.MainPage.DisplayAlert(
            "My Tasks", 
            "This would show your accepted tasks and delivery history.", 
            "OK");
    }

    [RelayCommand]
    private async Task ViewLeaderboard()
    {
        await Application.Current.MainPage.DisplayAlert(
            "Volunteer Leaderboard", 
            "This would show the top volunteers in your community.", 
            "OK");
    }

    private void LoadSampleTasks()
    {
        AvailableTasks.Clear();
        
        var sampleTasks = new List<VolunteerTask>
        {
            new VolunteerTask
            {
                Title = "Bakery to Shelter Delivery",
                PickupLocation = "Sunrise Grill, 324 Hays Blvd",
                DropoffLocation = "Hope Shelter, 456 Oak Ave",
                TimeWindow = "Today, 2:00-4:00 PM",
                Urgency = "High",
                Points = 50,
                CarbonSaved = 2.5
            },
            new VolunteerTask
            {
                Title = "Restaurant to Food Bank",
                PickupLocation = "Gino's Pizza, Sheridan College",
                DropoffLocation = "Downtown Food Bank, 321 Elm St",
                TimeWindow = "Tomorrow, 10:00-12:00 PM",
                Urgency = "Medium",
                Points = 35,
                CarbonSaved = 1.8
            },
            new VolunteerTask
            {
                Title = "Grocery Store Rescue",
                PickupLocation = "Freshway Market, 654 Iroquious Shore Rd",
                DropoffLocation = "Community Center, 987 Center Ave",
                TimeWindow = "Today, 5:00-7:00 PM",
                Urgency = "Urgent",
                Points = 75,
                CarbonSaved = 3.2
            }
        };

        foreach (var task in sampleTasks)
        {
            AvailableTasks.Add(task);
        }
    }
}