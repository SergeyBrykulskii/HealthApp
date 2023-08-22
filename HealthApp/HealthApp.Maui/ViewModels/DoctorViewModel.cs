using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthApp.Application.Abstractions;

namespace HealthApp.Maui.ViewModels;

public partial class DoctorViewModel : ObservableObject
{
    private readonly IPatientService _patientService;

    [ObservableProperty]
    private string _patientEmail = string.Empty;
    public DoctorViewModel(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [RelayCommand]
    public async Task Logout()
    {
        Preferences.Default.Remove("doctorId");
        await Shell.Current.GoToAsync("//LoginPage");
    }


    [RelayCommand]
    public async Task GoToMyInfo()
    {
        await Shell.Current.GoToAsync("//DoctorInfoPage");
    }

    [RelayCommand]
    public async Task SearchPatient()
    {
        var patient = await _patientService.FirstOrDefaultAsync(p => p.Email == PatientEmail);
        if (patient is null)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Patient not found", "Ok");
        }
        else
        {
            Preferences.Default.Set("patientId", patient.Id);
            await Shell.Current.GoToAsync($"//CardInfoPage");
        }
    }
}
