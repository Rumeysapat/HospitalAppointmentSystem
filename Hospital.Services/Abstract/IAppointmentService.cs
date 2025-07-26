using Hospital.Entities.Concrete; // Appointment sınıfının namespace'i

namespace Hospital.Services.Abstract
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAppointmentsByDoctorAndDateAsync(int doctorId, DateTime date);
        Task CreateAppointmentAsync(Appointment appointment); 

     

    }
}
