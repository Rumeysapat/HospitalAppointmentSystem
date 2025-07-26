using Hospital.Data.Abstract;
using Hospital.Entities.Concrete;
using Hospital.Services.Abstract;
using Hospital.Shared.Data.Abstract;
using System.Threading.Tasks;

namespace Hospital.Services.Concrete
{
    public class PatientManager : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Patient?> GetUserByEmailAsync(string email)
        {
            return await _unitOfWork.Patients.GetByEmailAsync(email);
        }
       public async Task<Patient?> CreatePatientAsync(Patient patient)
{
    try
    {
        await _unitOfWork.Patients.AddAsync(patient);
        await _unitOfWork.SaveAsync();
        return patient;
    }
    catch
    {
        return null;
    }
}

    }
}
