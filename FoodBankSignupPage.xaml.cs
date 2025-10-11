using Microsoft.Maui.Storage;

namespace ShareMealApp.Views;

public partial class FoodBankSignupPage : ContentPage
{
    private FileResult? _picked;

    public FoodBankSignupPage()
    {
        InitializeComponent();
    }

    private async void PickFile(object sender, EventArgs e)
    {
        try
        {
            var fileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>> {
                { DevicePlatform.iOS, new[] { "com.adobe.pdf", "public.image" } },
                { DevicePlatform.MacCatalyst, new[] { "com.adobe.pdf", "public.image" } },
                { DevicePlatform.Android, new[] { "application/pdf", "image/*" } },
                { DevicePlatform.WinUI, new[] { ".pdf", ".png", ".jpg", ".jpeg" } },
            });

            _picked = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a PDF or image",
                FileTypes = fileTypes
            });

            PickedDoc.Text = _picked == null ? "No file selected." : $"Selected: {_picked.FileName}";
        }
        catch (Exception ex)
        {
            await DisplayAlert("File error", ex.Message, "OK");
        }
    }

    private Task GoBack(object sender, EventArgs e)
        => Shell.Current.GoToAsync("..");

    private async void SubmitForm(object sender, EventArgs e)
    {
        var issues = ValidateInputs();
        if (issues.Count > 0)
        {
            await DisplayAlert("Check the form", string.Join("\n", issues), "OK");
            return;
        }

        var accepted = BuildFoodTypes();
        var form = new
        {
            Name = OrgName.Text?.Trim(),
            Address = OrgAddress.Text?.Trim(),
            Contact = ContactPerson.Text?.Trim(),
            Phone = ContactPhone.Text?.Trim(),
            Email = ContactEmail.Text?.Trim(),
            Hours = HoursText.Text?.Trim(),
            AcceptedTypes = accepted,
            DocumentName = _picked?.FileName
        };

        // TODO: send `form` + `_picked` to your API (multipart if file included)

        await DisplayAlert("Submitted", "Thanks! We’ll reach out after review.", "OK");
        await Shell.Current.GoToAsync("..");
    }

    private List<string> ValidateInputs()
    {
        var problems = new List<string>();

        if (string.IsNullOrWhiteSpace(OrgName.Text)) problems.Add("Organization name is required.");
        if (string.IsNullOrWhiteSpace(OrgAddress.Text)) problems.Add("Address is required.");
        if (string.IsNullOrWhiteSpace(ContactPerson.Text)) problems.Add("Contact name is required.");
        if (string.IsNullOrWhiteSpace(ContactPhone.Text)) problems.Add("Phone is required.");
        if (string.IsNullOrWhiteSpace(ContactEmail.Text)) problems.Add("Email is required.");

        return problems;
    }

    private List<string> BuildFoodTypes()
    {
        var types = new List<string>();
        if (CbCanned.IsChecked) types.Add("Canned / shelf-stable");
        if (CbProduce.IsChecked) types.Add("Fresh produce");
        if (CbDairy.IsChecked) types.Add("Dairy (refrigerated)");
        if (CbFrozen.IsChecked) types.Add("Frozen goods");
        if (CbPrepared.IsChecked) types.Add("Prepared meals");
        if (CbBakery.IsChecked) types.Add("Bakery");
        if (CbOther.IsChecked && !string.IsNullOrWhiteSpace(OtherNotes.Text))
            types.Add($"Other: {OtherNotes.Text.Trim()}");
        return types;
    }
}
