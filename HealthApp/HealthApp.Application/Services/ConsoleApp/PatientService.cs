using HealthApp.Application.Abstractions.ConsoleApp;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Entities;

namespace HealthApp.Application.Services.ConsoleApp;

public class PatientService : IPatientService
{
    private IUnitOfWork _unitOfWork;

    public PatientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(Patient entity)
    {
        _unitOfWork.PatientRepository.Add(entity);
    }

    public void Delete(Patient entity)
    {
        _unitOfWork.PatientRepository.Delete(entity);
    }

    public Patient GetById(int id)
    {
        return _unitOfWork.PatientRepository.GetById(id);
    }

    public bool IsExists(Func<Patient, bool> filter)
    {
        return _unitOfWork.PatientRepository.IsExists(filter);
    }

    public IReadOnlyList<Patient> ListAll()
    {
        return _unitOfWork.PatientRepository.ListAll();
    }

    public void Update(Patient entity)
    {
        _unitOfWork.PatientRepository.Update(entity);
    }
}
