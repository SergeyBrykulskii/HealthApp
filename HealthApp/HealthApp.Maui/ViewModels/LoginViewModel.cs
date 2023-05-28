using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthApp.Domain.Entities;
using HealthApp.Maui.Services.Abstractions;

namespace HealthApp.Maui.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IAuthenticationService _authenticationService;

    [ObservableProperty]
    private string _email;
    [ObservableProperty]
    private string _password;
    public LoginViewModel(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [RelayCommand]
    public async Task SingIn()
    {
        var user = await _authenticationService.LoginAsync(_email, _password);

        if (user is null)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid credentials", "Ok");
            return;
        }

        Preferences.Default.Set("id", user.Id);

        if (user is Doctor)
        {
            await Shell.Current.GoToAsync("//DoctorPage");
        }
        else
        {
            await Shell.Current.GoToAsync("//PatientPage");
        }
    }

    [RelayCommand]
    public async Task SingUp()
    {
        bool isDoctor = await App.Current.MainPage.DisplayAlert("Are you doctor?", "", "Yes", "No");
        if (isDoctor)
        {
            await Shell.Current.GoToAsync("//RegistrationDoctorPage");
        }
        else
        {
            await Shell.Current.GoToAsync("//RegistrationPatientPage");
        }
    }

}
