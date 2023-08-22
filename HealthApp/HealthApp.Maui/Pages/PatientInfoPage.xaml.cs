using HealthApp.Maui.ViewModels;

namespace HealthApp.Maui.Pages;

public partial class PatientInfoPage : ContentPage
{
    private readonly PatientInfoViewModel _viewModel;
    public PatientInfoPage(PatientInfoViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}