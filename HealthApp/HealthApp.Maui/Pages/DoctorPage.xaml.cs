using HealthApp.Maui.ViewModels;

namespace HealthApp.Maui.Pages;

public partial class DoctorPage : ContentPage
{
    private readonly DoctorViewModel _viewModel;
    public DoctorPage(DoctorViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}