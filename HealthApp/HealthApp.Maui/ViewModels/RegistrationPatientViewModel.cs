using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthApp.Application.Abstractions;
using HealthApp.Domain.Entities;
using HealthApp.Maui.Services.Abstractions;

namespace HealthApp.Maui.ViewModels;

public partial class RegistrationPatientViewModel : ObservableObject
{
    private readonly IPasswordService _passwordService;
    private readonly IPatientService _patientService;

    [ObservableProperty]
    private Patient _newPatient;

    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _confirmPassword;

    public RegistrationPatientViewModel(IPasswordService passwordService, IPatientService patientService)
    {
        _passwordService = passwordService;
        _patientService = patientService;
        _newPatient = new Patient();
    }

    [RelayCommand]
    public async Task Register()
    {
        OnPropertyChanged(nameof(NewPatient));
        if (NewPatient.Name is null || NewPatient.Email is null ||
            NewPatient.Name == "" || NewPatient.Email == "")
        {
            await App.Current.MainPage.DisplayAlert("Error", "All fields are required", "Ok");
            return;
        }
        if (await _patientService.FirstOrDefaultAsync(p => p.Email == NewPatient.Email) is not null)
        {
            await App.Current.MainPage.DisplayAlert("Error", "User with such email already exists", "Ok");
            return;
        }
        if (_password != _confirmPassword)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "Ok");
            return;
        }
        NewPatient.Password = _passwordService.GetHashedPassword(_password);
        await _patientService.AddAsync(NewPatient);
        await _patientService.SaveAllAsync();
        Clear();
        await App.Current.MainPage.DisplayAlert("Success", "You have successfully registered", "Ok");
        await Shell.Current.GoToAsync("//LoginPage");
    }

    [RelayCommand]
    public async Task BackToLogin()
    {
        Clear();
        await Shell.Current.GoToAsync("//LoginPage");
    }

    public void Clear()
    {
        NewPatient = new Patient();
        Password = "";
        ConfirmPassword = "";
        OnPropertyChanged(nameof(NewPatient));
        OnPropertyChanged(nameof(Password));
        OnPropertyChanged(nameof(ConfirmPassword));
    }
}
