using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HealthApp.Maui.ViewModels;

public partial class DoctorViewModel : ObservableObject
{
    public DoctorViewModel()
    {
    }

    [RelayCommand]
    public async Task Logout()
    {
        Preferences.Default.Clear();
        await Shell.Current.GoToAsync("//LoginPage");
    }

    [RelayCommand]
    public async Task GoToPatients()
    {
        await Shell.Current.GoToAsync("//PatientsPage");
    }

    [RelayCommand]
    public async Task GoToMyInfo()
    {
        await Shell.Current.GoToAsync("//DoctorInfoPage");
    }
}
