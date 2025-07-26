using Hospital.Data.Abstract;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Hospital.Shared.Data.Concrete.EntityFramework;
using Hospital.Data.Concrete.EntityFramework.Contexts;

namespace Hospital.Data.Concrete
{
  public class EfUserRepository : EfEntityRepositoryBase<User>, IUserRepository
{
    private HospitalAppointmentDbContext _hospitalContext => (HospitalAppointmentDbContext)_context;

    public EfUserRepository(HospitalAppointmentDbContext context) : base(context)
    {
    }

   
}

}
