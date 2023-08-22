using HealthApp.Maui.ViewModels;

namespace HealthApp.Maui.Pages;

public partial class AddRecordPage : ContentPage
{
    private readonly AddRecordViewModel _viewModel;
    public AddRecordPage(AddRecordViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}