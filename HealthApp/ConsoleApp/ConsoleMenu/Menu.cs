/*using HealthApp.Application.Abstractions;
using HealthApp.Domain.Entities;

namespace ConsoleApp.ConsoleMenu;

public class Menu
{
    private readonly ICardService _cardService;
    private readonly IDoctorService _doctorService;
    private readonly IPatientService _patientService;

    public Dictionary<int, Action<int>> Commands = new();
    public Menu(ICardService cardService,
         IDoctorService doctorService,
         IPatientService patientService)
    {
        _cardService = cardService;
        _doctorService = doctorService;
        _patientService = patientService;

        Commands[1] = AddCard;
        Commands[2] = AddRecord;
        Commands[3] = AddInfo;
        Commands[4] = PrintAllRecords;
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

    private bool IsCardExists(Func<Card, bool> func)
    {
        return _cardService.IsExists(func);
    }
    private void AddCard(int id)
    {
        if (IsCardExists(card => card.Id == id))
        {
            Console.WriteLine("Card already exists");
            return;
        }
        Console.WriteLine("Card added");
        _cardService.Add(new Card(id));
    }

    private void AddRecord(int id)
    {
        if (!IsCardExists(card => card.Id == id))
        {
            Console.WriteLine("There isnt card");
            return;
        }

        Console.WriteLine("Enter record");
        var content = Console.ReadLine();

        var card = _cardService.GetById(id);
        card.AddRecord(id, content, DateTime.Now);
    }

    private void AddInfo(int id)
    {
        if (!IsCardExists(card => card.Id == id))
        {
            Console.WriteLine("There isnt card");
            return;
        }

        var card = _cardService.GetById(id);
        Console.WriteLine("Enter age: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Something wrong, try again");
        }

        Console.WriteLine("You are men?: ");
        if (!bool.TryParse(Console.ReadLine(), out bool male))
        {
            Console.WriteLine("Something wrong, try again");
        }

        Console.WriteLine("Enter weight: ");
        if (!int.TryParse(Console.ReadLine(), out int weight))
        {
            Console.WriteLine("Something wrong, try again");
        }

        card.AddInfo(age, male, weight);
    }

    private void PrintAllRecords(int id)
    {
        if (!IsCardExists(card => card.Id == id))
        {
            Console.WriteLine("There isnt card");
            return;
        }

        var records = _cardService.GetById(id).Records;
        if (records.Count() == 0)
        {
            Console.WriteLine("There are no records");
            return;
        }

        foreach (var record in records)
        {
            var text = record.Date.ToString() + " " + record.Content;
            Console.WriteLine(text);
        }

    }

}
*/