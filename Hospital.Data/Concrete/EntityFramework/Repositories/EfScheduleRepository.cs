using Hospital.Data.Abstract;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Hospital.Shared.Data.Concrete.EntityFramework;
using Hospital.Data.Concrete.EntityFramework.Contexts;

namespace Hospital.Data.Concrete
{
    public class EfScheduleRepository : EfEntityRepositoryBase<Schedule>,IScheduleRepository
    {
        public  EfScheduleRepository(HospitalAppointmentDbContext context) : base(context)
        {
        }
    }
}