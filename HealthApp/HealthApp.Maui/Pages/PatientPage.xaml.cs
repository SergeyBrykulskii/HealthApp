namespace HealthApp.Maui.Pages;

public partial class PatientPage : ContentPage
{
    public PatientPage()
    {
        InitializeComponent();
    }

    private void OnCardInfoClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PatientCardInfo");
    }

    private void OnPatientInfoClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PatientInfoPage");
    }
    private void OnLogoutClicked(object sender, EventArgs e)
    {
        Preferences.Default.Remove("patientId");
        Shell.Current.GoToAsync("//LoginPage");
    }
}