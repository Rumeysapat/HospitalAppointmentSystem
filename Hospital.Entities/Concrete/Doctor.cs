using Hospital.Entities.Concrete;
using Hospital.Shared.Entities.Absract;



namespace Hospital.Entities.Concrete;

public class Doctor : EntityBase, IEntity
{
    public string Name { get; set; } // Doktorun adı
     // Foreign Key (FK) - Hangi departmana bağlı?
    public int DepartmentId { get; set; }  
    public Department Department { get; set; } // Navigation Property
    public ICollection<Appointment> Appointments { get; set; } // Randevular one to many 
    public string Specialization { get; set; } 

    // Diğer doktorla ilgili özellikler ve metotlar buraya eklenebilir
        public ICollection<Schedule> Schedules { get; set; } 
}
