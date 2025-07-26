using Hospital.Entities.Concrete;
using System.Threading.Tasks;

namespace Hospital.Services.Abstract
{
    public interface IPatientService
    {
        Task<Patient?> GetUserByEmailAsync(string email);
        Task<Patient?> CreatePatientAsync(Patient patient);

    }
}
