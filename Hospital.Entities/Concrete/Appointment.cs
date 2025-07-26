using Hospital.Shared.Entities.Absract;

namespace Hospital.Entities.Concrete;

public class Appointment :EntityBase, IEntity
{

    public int PatientId { get; set; }
    public Patient Patient { get; set; } // Hasta ilişkisi

   
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } // Doktor ilişkisi

   
    public DateTime AppointmentDate { get; set; } // Randevu tarihi ve saati


    public string Notes { get; set; }

   
    public TimeSpan AppointmentTime { get; set; } // Seçilen saat 

     public bool IsActive { get; set; } = true; // Randevu geçerli mi?

}
