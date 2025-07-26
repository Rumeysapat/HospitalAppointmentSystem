using Hospital.Data.Abstract;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Hospital.Shared.Data.Concrete.EntityFramework;
using Hospital.Data.Concrete.EntityFramework.Contexts;

namespace Hospital.Data.Concrete
{
    public class EfDepartmentRepository : EfEntityRepositoryBase<Department>,IDepartmentRepository
    {
        public  EfDepartmentRepository(HospitalAppointmentDbContext context) : base(context)
        {
        }
    }
}