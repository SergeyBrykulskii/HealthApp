using HealthApp.Maui.ViewModels;

namespace HealthApp.Maui.Pages;

public partial class PatientPage : ContentPage
{
    private readonly StatisticViewModel _viewModel;
    public PatientPage(StatisticViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
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

    private void OnStatisticClicked(object sender, EventArgs e)
    {
        _viewModel.GetStatistic();
        Shell.Current.GoToAsync("//StatisticPage");
    }
}