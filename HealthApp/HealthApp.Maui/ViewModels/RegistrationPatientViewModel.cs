using CommunityToolkit.Mvvm.ComponentModel;
using HealthApp.Application.Abstractions;
using HealthApp.Domain.Entities;
using HealthApp.Maui.Services.Abstractions;

namespace HealthApp.Maui.ViewModels;

public partial class RegistrationPatientViewModel : ObservableObject
{
    private readonly IPasswordService _passwordService;
    private readonly IPatientService _patientService;

    [ObservableProperty]
    private Patient _patient;

    public RegistrationPatientViewModel(IPasswordService passwordService, IPatientService patientService)
    {
        _passwordService = passwordService;
        _patientService = patientService;
        _patient = new Patient();
    }
}
