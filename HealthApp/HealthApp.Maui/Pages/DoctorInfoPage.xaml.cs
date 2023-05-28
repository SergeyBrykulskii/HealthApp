using HealthApp.Maui.ViewModels;

namespace HealthApp.Maui.Pages;

public partial class DoctorInfoPage : ContentPage
{
    private readonly DoctorInfoViewModel _viewModel;
    public DoctorInfoPage(DoctorInfoViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}