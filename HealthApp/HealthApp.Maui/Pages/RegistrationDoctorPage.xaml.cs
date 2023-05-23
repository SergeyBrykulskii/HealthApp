using HealthApp.Maui.ViewModels;

namespace HealthApp.Maui.Pages;

public partial class RegistrationDoctorPage : ContentPage
{
    private readonly RegistrationDoctorViewModel _viewModel;
    public RegistrationDoctorPage(RegistrationDoctorViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}