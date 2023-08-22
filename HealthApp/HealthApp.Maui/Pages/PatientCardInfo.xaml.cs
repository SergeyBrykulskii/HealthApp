using HealthApp.Maui.ViewModels;

namespace HealthApp.Maui.Pages;

public partial class PatientCardInfo : ContentPage
{
    private readonly PatientCardInfoViewModel _viewModel;
    public PatientCardInfo(PatientCardInfoViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}