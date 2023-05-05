using HealthApp.Domain.Entities;
using Serialization;
using System.Text.Json;

namespace HealthApp.Persistence.Data;

public class FakeDbContext : IFakeDbContext
{
    public List<Patient> _patients { get; set; } = new();
    public List<Doctor> _doctors { get; set; } = new();
    public List<Card> _cards { get; set; } = new();

    private readonly ISerializer _serializer;

    /*    private readonly string _patientPath = Path.Combine(Directory.GetCurrentDirectory(), typeof(Patient).Name + ".json");
        private readonly string _doctorPath = Path.Combine(Directory.GetCurrentDirectory(), typeof(Doctor).Name + ".json");
        private readonly string _cardsPath = Path.Combine(Directory.GetCurrentDirectory(), typeof(Card).Name + ".json");*/

    private readonly string _patientPath = Path.Combine(Directory.GetCurrentDirectory(), "Patients.json");
    private readonly string _doctorPath = Path.Combine(Directory.GetCurrentDirectory(), "Doctors.json");
    private readonly string _cardPath = Path.Combine(Directory.GetCurrentDirectory(), "Cards.json");

    public FakeDbContext(ISerializer serializer)
    {
        _serializer = serializer;

        _patients = _serializer.DeserializeJson<Patient>(_patientPath)?.ToList() ?? new();
        _doctors = _serializer.DeserializeJson<Doctor>(_doctorPath)?.ToList() ?? new();
        _cards = _serializer.DeserializeJson<Card>(_cardPath)?.ToList() ?? new();
    }
    public void Serialize()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        _serializer.SerializeJson(_patients, _patientPath, options);
        _serializer.SerializeJson(_doctors, _doctorPath, options);
        _serializer.SerializeJson(_cards, _cardPath, options);
    }
}
