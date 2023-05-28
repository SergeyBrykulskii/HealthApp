using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthApp.Application.Abstractions;

namespace HealthApp.Maui.ViewModels;

public partial class PatientsViewModel : ObservableObject
{
    private readonly IPatientService _patientService;

    [ObservableProperty]
    private string _patientEmail = string.Empty;
    public PatientsViewModel(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [RelayCommand]
    public async Task BackToDoctor()
    {
        await Shell.Current.GoToAsync("//DoctorPage");
    }
}
