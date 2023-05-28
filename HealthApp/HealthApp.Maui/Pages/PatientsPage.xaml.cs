using HealthApp.Maui.ViewModels;

namespace HealthApp.Maui.Pages;

public partial class PatientsPage : ContentPage
{
    private readonly PatientsViewModel _viewModel;
    public PatientsPage(PatientsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}