using Hospital.Data.Abstract;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Hospital.Data.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Shared.Data.Concrete.EntityFramework;

namespace Hospital.Data.Concrete
{
    public class EfAppointmentRepository : EfEntityRepositoryBase<Appointment>, IAppointmentRepository
    {
        private HospitalAppointmentDbContext _hospitalContext => (HospitalAppointmentDbContext)_context;

        public EfAppointmentRepository(HospitalAppointmentDbContext context) : base(context)
        {
        }

        public async Task<List<Appointment>> GetAppointmentsByDoctorAndDateAsync(int doctorId, DateTime date)
{
    return await _hospitalContext.Appointments
        .Where(a => a.DoctorId == doctorId && a.AppointmentDate.Date == date.Date)
        .ToListAsync();
}

    }
}
