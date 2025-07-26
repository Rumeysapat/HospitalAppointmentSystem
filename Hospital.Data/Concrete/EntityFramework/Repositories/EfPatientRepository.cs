using Hospital.Data.Abstract;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Hospital.Shared.Data.Concrete.EntityFramework;
using Hospital.Data.Concrete.EntityFramework.Contexts;

namespace Hospital.Data.Concrete
{
    public class EfPatientRepository : EfEntityRepositoryBase<Patient>, IPatientRepository
    {
          private HospitalAppointmentDbContext _hospitalContext => (HospitalAppointmentDbContext)_context;

        public EfPatientRepository(HospitalAppointmentDbContext context) : base(context)
        {
        }
         public async Task<Patient?> GetByEmailAsync(string email)
    {
        return await _hospitalContext.Patients.FirstOrDefaultAsync(u => u.Email == email);
    }
    }
}