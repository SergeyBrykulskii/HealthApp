using HealthApp.Application.Abstractions;
using HealthApp.Domain.Entities;
using System.Collections.ObjectModel;

namespace HealthApp.Maui.Services.Implementation;

public class RecordInfoService
{
    private readonly IRecordService _recordService;


    public ObservableCollection<Record> Records { get; set; } = new();

    public RecordInfoService(IRecordService recordService)
    {
        _recordService = recordService;
        MainThread.BeginInvokeOnMainThread(async () => await GetRecords());
    }

    public async Task GetRecords()
    {
        var patientId = Preferences.Get("patientId", -1);
        var records = await _recordService.ListAsync(x => x.Card.Patient.Id == patientId);
        Records.Clear();
        foreach (var record in records)
        {
            Records.Add(record);
        }
    }

    public async Task AddRecord(Record record)
    {
        Records.Add(record);
        await _recordService.AddAsync(record);
        await _recordService.SaveAllAsync();
    }

    public async Task UpdateRecord(Record record)
    {
        await _recordService.UpdateAsync(record);
        await _recordService.SaveAllAsync();
    }

    public async Task DeleteRecord(Record record)
    {
        Records.Remove(record);
        await _recordService.DeleteAsync(record);
        await _recordService.SaveAllAsync();
    }
}
