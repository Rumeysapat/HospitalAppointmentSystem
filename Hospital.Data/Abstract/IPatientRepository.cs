using Hospital.Entities.Concrete;
using Hospital.Shared.Data.Abstract;

namespace Hospital.Data.Abstract
{
    public interface IPatientRepository : IEntityRepository<Patient>
    {
         Task<Patient?> GetByEmailAsync(string email);
       
    }
}