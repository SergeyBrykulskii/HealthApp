using HealthApp.Maui.ViewModels;

namespace HealthApp.Maui.Pages;

public partial class StatisticPage : ContentPage
{
    private readonly StatisticViewModel _viewModel;
    public StatisticPage(StatisticViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}