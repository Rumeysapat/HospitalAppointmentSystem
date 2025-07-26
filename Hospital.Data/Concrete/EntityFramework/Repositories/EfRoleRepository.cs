using Hospital.Data.Abstract;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Hospital.Shared.Data.Concrete.EntityFramework;
using Hospital.Data.Concrete.EntityFramework.Contexts;

namespace Hospital.Data.Concrete
{
    public class EfRoleRepository : EfEntityRepositoryBase<Role>,IRoleRepository
    {
        public  EfRoleRepository(HospitalAppointmentDbContext context) : base(context)
        {
        }
    }
}