using HealthApp.Application.Abstractions.ConsoleApp;
using HealthApp.Domain.Entities;

namespace ConsoleApp.ConsoleMenu;

public class Menu
{
    private readonly ICardService _cardService;
    private readonly IDoctorService _doctorService;
    private readonly IPatientService _patientService;

    public Menu(ICardService cardService,
         IDoctorService doctorService,
         IPatientService patientService)
    {
        _cardService = cardService;
        _doctorService = doctorService;
        _patientService = patientService;
    }

    public bool IsPatientExists(Func<Patient, bool> func)
    {
        return _patientService.IsExists(func);
    }

    public void AddPatient(Patient patient)
    {
        _patientService.Add(patient);
    }

    public int GetPatientId(Func<Patient, bool> func)
    {
        var patient = _patientService.FirstOrDefault(func);
        return patient == null ? -1 : patient.Id;
    }

    public bool IsDoctorExists(Func<Doctor, bool> func)
    {
        return _doctorService.IsExists(func);
    }

    public void AddDoctor(Doctor doctor)
    {
        _doctorService.Add(doctor);
    }

    public int GetDoctorId(Func<Doctor, bool> func)
    {
        var doctor = _doctorService.FirstOrDefault(func);
        return doctor == null ? -1 : doctor.Id;
    }
}
