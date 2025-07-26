using Hospital.Entities.Concrete;
using Hospital.Shared.Data.Abstract;

namespace Hospital.Data.Abstract
{
    public interface IAppointmentRepository : IEntityRepository<Appointment>
    {
        Task<List<Appointment>> GetAppointmentsByDoctorAndDateAsync(int doctorId, DateTime date);
    }
}