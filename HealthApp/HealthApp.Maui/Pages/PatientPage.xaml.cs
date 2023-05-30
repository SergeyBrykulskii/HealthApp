namespace HealthApp.Maui.Pages;

public partial class PatientPage : ContentPage
{
    public PatientPage()
    {
        InitializeComponent();
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        Preferences.Default.Remove("patientId");
        Shell.Current.GoToAsync("//LoginPage");
    }
}