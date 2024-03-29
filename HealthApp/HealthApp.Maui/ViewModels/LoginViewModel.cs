﻿using CommunityToolkit.Mvvm.ComponentModel;
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


        if (user is Doctor)
        {
            Preferences.Default.Set("doctorId", user.Id);
            await Shell.Current.GoToAsync("//DoctorPage");
        }
        else
        {
            Preferences.Default.Set("patientId", user.Id);
            await Shell.Current.GoToAsync("//PatientPage");
        }
        Clear();
    }

    [RelayCommand]
    public async Task SingUp()
    {
        bool isDoctor = await App.Current.MainPage.DisplayAlert("Are you doctor?", "", "Yes", "No");
        Clear();
        if (isDoctor)
        {
            await Shell.Current.GoToAsync("//RegistrationDoctorPage");
        }
        else
        {
            await Shell.Current.GoToAsync("//RegistrationPatientPage");
        }
    }

    [RelayCommand]
    public void Clear()
    {
        _email = string.Empty;
        _password = string.Empty;
        OnPropertyChanged(nameof(Email));
        OnPropertyChanged(nameof(Password));
    }

}
