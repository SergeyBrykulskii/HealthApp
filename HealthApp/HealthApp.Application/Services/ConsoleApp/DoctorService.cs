using HealthApp.Application.Abstractions.ConsoleApp;
using HealthApp.Domain.Abstractions;
using HealthApp.Domain.Entities;

namespace HealthApp.Application.Services.ConsoleApp;

public class DoctorService : IDoctorService
{
    private readonly IUnitOfWork _unitOfWork;

    public DoctorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(Doctor entity)
    {
        _unitOfWork.DoctorRepository.Add(entity);
    }

    public void Delete(Doctor entity)
    {
        _unitOfWork.DoctorRepository.Delete(entity);
    }

    public Doctor GetById(int id)
    {
        return _unitOfWork.DoctorRepository.GetById(id);
    }

    public bool IsExists(Func<Doctor, bool> filter)
    {
        return _unitOfWork.DoctorRepository.IsExists(filter);
    }

    public IReadOnlyList<Doctor> ListAll()
    {
        return _unitOfWork.DoctorRepository.ListAll();
    }

    public Doctor FirstOrDefault(Func<Doctor, bool> filter)
    {
        return _unitOfWork.DoctorRepository.FirstOrDefault(filter);
    }

    public void Update(Doctor entity)
    {
        _unitOfWork.DoctorRepository.Update(entity);
    }
}
