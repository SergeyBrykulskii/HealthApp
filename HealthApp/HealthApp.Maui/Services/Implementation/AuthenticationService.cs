using HealthApp.Application.Abstractions;
using HealthApp.Domain.Entities;
using HealthApp.Maui.Services.Abstractions;

namespace HealthApp.Maui.Services.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly IDoctorService _doctorService;
    private readonly IPatientService _patientService;
    private readonly IPasswordService _passwordService;

    public AuthenticationService(IDoctorService doctorService, IPatientService patientService, IPasswordService passwordService)
    {
        _doctorService = doctorService;
        _patientService = patientService;
        _passwordService = passwordService;
    }

    public async Task<User> LoginAsync(string email, string password)
    {
        var doctor = await _doctorService.FirstOrDefaultAsync(d => d.Email == email);
        if (doctor is not null && _passwordService.VerifyPassword(password, doctor.Password))
        {
            return doctor;
        }
        var patient = await _patientService.FirstOrDefaultAsync(d => d.Email == email);
        if (patient is not null && _passwordService.VerifyPassword(password, patient.Password))
        {
            return patient;
        }
        return null;
    }

}
