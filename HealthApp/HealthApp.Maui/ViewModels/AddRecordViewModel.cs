using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthApp.Application.Abstractions;
using HealthApp.Domain.Entities;
using HealthApp.Maui.Services.Implementation;

namespace HealthApp.Maui.ViewModels;

public partial class AddRecordViewModel : ObservableObject
{
    private readonly ICardService _cardService;
    private readonly IDoctorService _doctorService;
    public RecordInfoService RecordInfoService { get; }
    [ObservableProperty]
    private string _content;
    public AddRecordViewModel(RecordInfoService recordInfoService, ICardService cardService, IDoctorService doctorService)
    {
        RecordInfoService = recordInfoService;
        _cardService = cardService;
        _doctorService = doctorService;
    }
    [RelayCommand]
    public async Task Add()
    {
        var patientId = Preferences.Default.Get("patientId", -1);
        var card = await _cardService.FirstOrDefaultAsync(c => c.Patient.Id == patientId);
        var doctorId = Preferences.Default.Get("doctorId", -1);
        var doctor = await _doctorService.GetByIdAsync(doctorId);

        var record = new Record
        {
            Doctor = doctor,
            Card = card,
            Content = Content,
            Date = DateTime.Now
        };
        await RecordInfoService.AddRecord(record);
        Clear();
        await Shell.Current.GoToAsync("//CardInfoPage");
    }

    [RelayCommand]
    public async Task Back()
    {
        Clear();
        await Shell.Current.GoToAsync("//CardInfoPage");
    }
    private void Clear()
    {
        Content = "";
        OnPropertyChanged(nameof(Content));
    }
}
