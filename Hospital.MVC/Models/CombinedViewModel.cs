using Hospital.MVC.Models; 
namespace Hospital.MVC.Models
{
    public class CombinedViewModel
    {
        public AppointmentViewModel Appointment { get; set; }
        public DoctorDepartmentViewModel DoctorDepartment { get; set; }
    }
}