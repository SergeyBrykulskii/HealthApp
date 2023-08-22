using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthApp.Maui.Services.Implementation;

namespace HealthApp.Maui.ViewModels;

public partial class CardInfoViewModel : ObservableObject
{
    public RecordInfoService RecordInfoService { get; }
    public CardInfoViewModel(RecordInfoService recordInfoService)
    {
        RecordInfoService = recordInfoService;
    }

    [RelayCommand]
    public async Task AddRecord()
    {
        await Shell.Current.GoToAsync("//AddRecordPage");
    }
    [RelayCommand]
    public async Task Back()
    {
        await Shell.Current.GoToAsync("//DoctorPage");
    }
}
