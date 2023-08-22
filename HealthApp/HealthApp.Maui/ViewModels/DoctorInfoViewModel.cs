using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthApp.Application.Abstractions;
using HealthApp.Domain.Entities;

namespace HealthApp.Maui.ViewModels;

public partial class DoctorInfoViewModel : ObservableObject
{
    private readonly IDoctorService _doctorService;

    [ObservableProperty]
    private Doctor _currDoctor;

    public DoctorInfoViewModel(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [RelayCommand]
    public async Task Appearing()
    {
        var id = Preferences.Default.Get("doctorId", -1);
        CurrDoctor = await _doctorService.GetByIdAsync(id);
        OnPropertyChanged(nameof(CurrDoctor));
    }

    [RelayCommand]
    public async Task BackToDoctor()
    {
        await Shell.Current.GoToAsync("//DoctorPage");
    }

    [RelayCommand]
    public async Task Update()
    {
        OnPropertyChanged(nameof(CurrDoctor));
        await _doctorService.UpdateAsync(CurrDoctor);
        await Shell.Current.GoToAsync("//DoctorPage");
    }
}
