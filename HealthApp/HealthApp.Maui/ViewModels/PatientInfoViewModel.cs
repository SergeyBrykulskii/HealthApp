using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthApp.Application.Abstractions;
using HealthApp.Domain.Entities;

namespace HealthApp.Maui.ViewModels;

public partial class PatientInfoViewModel : ObservableObject
{
    private readonly IPatientService _patientService;
    [ObservableProperty]
    private Patient _currPatient;
    public PatientInfoViewModel(IPatientService patientService)
    {
        _patientService = patientService;
    }
    [RelayCommand]
    public async Task Appearing()
    {
        var id = Preferences.Default.Get("patientId", -1);
        CurrPatient = await _patientService.GetByIdAsync(id);
        OnPropertyChanged(nameof(CurrPatient));
    }
    [RelayCommand]
    public async Task BackToDoctor()
    {
        await Shell.Current.GoToAsync("//DoctorPage");
    }
    [RelayCommand]
    public async Task Update()
    {
        OnPropertyChanged(nameof(CurrPatient));
        await _patientService.UpdateAsync(CurrPatient);
        await Shell.Current.GoToAsync("//DoctorPage");
    }
}
