using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthApp.Application.Abstractions;
using HealthApp.Domain.Entities;
using HealthApp.Maui.Services.Abstractions;

namespace HealthApp.Maui.ViewModels;

public partial class RegistrationDoctorViewModel : ObservableObject
{
    private readonly IPasswordService _passwordService;
    private readonly IDoctorService _doctorService;

    [ObservableProperty]
    private Doctor _newDoctor;

    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _confirmPassword;

    public RegistrationDoctorViewModel(IPasswordService passwordService, IDoctorService doctorService)
    {
        _passwordService = passwordService;
        _doctorService = doctorService;
        _newDoctor = new Doctor();
    }

    [RelayCommand]
    public async Task Register()
    {
        OnPropertyChanged(nameof(Doctor));
        if (NewDoctor.Name is null || NewDoctor.Email is null || NewDoctor.Speciality is null ||
            NewDoctor.Name == "" || NewDoctor.Email == "" || NewDoctor.Speciality == "")
        {
            await App.Current.MainPage.DisplayAlert("Error", "All fields are required", "Ok");
            return;
        }
        if (Password != ConfirmPassword)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "Ok");
            return;
        }
        NewDoctor.Password = _passwordService.GetHashedPassword(Password);
        await _doctorService.AddAsync(NewDoctor);
        await _doctorService.SaveAllAsync();

        await App.Current.MainPage.DisplayAlert("Success", "You have successfully registered", "Ok");
        await Shell.Current.GoToAsync("//LoginPage");
    }
}
