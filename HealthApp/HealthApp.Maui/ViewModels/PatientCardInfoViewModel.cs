using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthApp.Maui.Services.Implementation;

namespace HealthApp.Maui.ViewModels;

public partial class PatientCardInfoViewModel : ObservableObject
{
    public RecordInfoService RecordInfoService { get; }
    public PatientCardInfoViewModel(RecordInfoService recordInfoService)
    {
        RecordInfoService = recordInfoService;
    }

    [RelayCommand]
    public async Task Back()
    {
        await Shell.Current.GoToAsync("//PatientPage");
    }
}
