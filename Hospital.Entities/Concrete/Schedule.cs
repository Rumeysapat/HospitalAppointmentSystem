using Hospital.Shared.Entities.Absract;
namespace Hospital.Entities.Concrete;

public class Schedule : EntityBase,IEntity
{
    public int DoctorId { get; set; } // FK - Doktor
    public Doctor Doctor { get; set; } // Navigation Property

    public DayOfWeek Day { get; set; } // Hangi gün? (Pazartesi, Salı, vb.)
    
    public TimeSpan StartTime { get; set; } // Başlangıç saati (09:00)
    public TimeSpan EndTime { get; set; } // Bitiş saati (17:00)


    public bool IsAvailable { get; set; } = true;
}
