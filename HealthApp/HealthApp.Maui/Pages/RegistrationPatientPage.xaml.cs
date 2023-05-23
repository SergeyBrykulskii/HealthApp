using HealthApp.Maui.ViewModels;

namespace HealthApp.Maui.Pages;

public partial class RegistrationPatientPage : ContentPage
{
    private readonly RegistrationPatientViewModel _viewModel;
    public RegistrationPatientPage(RegistrationPatientViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}