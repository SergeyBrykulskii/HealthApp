using HealthApp.Maui.ViewModels;

namespace HealthApp.Maui.Pages;

public partial class CardInfoPage : ContentPage
{
    private readonly CardInfoViewModel _viewModel;
    public CardInfoPage(CardInfoViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}