using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthApp.Maui.Services.Implementation;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace HealthApp.Maui.ViewModels;

public partial class StatisticViewModel : ObservableObject
{
    public RecordInfoService _recordInfoService { get; }
    private int numLastWeek;
    private int numLastMonth;
    private int numLastYear;
    private TimeSpan _lastWeek = new(7, 0, 0, 0);
    private TimeSpan _lastMonth = new(30, 0, 0, 0);
    private TimeSpan _lastYear = new(365, 0, 0, 0);
    public StatisticViewModel(RecordInfoService recordInfoService)
    {
        _recordInfoService = recordInfoService;
        GetStatistic();
    }
    public ISeries[] Series { get; set; } =
    {
        new ColumnSeries<int>
        {
            Name = "Records",
            Values = new int[] {  }
        }
    };

    public Axis[] XAxes { get; set; } =
    {
        new Axis
        {
            Labels = new string[] { "Last week", "Last month", "Last year" },
            LabelsRotation = 0,
            LabelsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
            SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
            SeparatorsAtCenter = false,
            TicksPaint = new SolidColorPaint(new SKColor(2, 0, 253)),
            TicksAtCenter = true
        }
    };

    public void GetStatistic()
    {
        numLastWeek = _recordInfoService.Records.Count(r => r.Date - DateTime.Now < _lastWeek);
        numLastMonth = _recordInfoService.Records.Count(r => r.Date - DateTime.Now < _lastMonth);
        numLastYear = _recordInfoService.Records.Count(r => r.Date - DateTime.Now < _lastYear);
        Series[0].Values = new int[] { numLastWeek, numLastMonth, numLastYear };
    }

    [RelayCommand]
    public async Task Back()
    {
        await Shell.Current.GoToAsync("//PatientPage");
    }
}
