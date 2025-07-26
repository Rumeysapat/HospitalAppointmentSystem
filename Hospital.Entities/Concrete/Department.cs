using Hospital.Shared.Entities.Absract;
namespace Hospital.Entities.Concrete;
public class Department : EntityBase, IEntity
{
    public string Name { get; set; } // Bölüm adı (Örn: Kardiyoloji)
    
    public ICollection<Doctor> Doctors { get; set; } // Bölümdeki doktorlar
}
