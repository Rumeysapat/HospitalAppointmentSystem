using System.ComponentModel.DataAnnotations;
using Hospital.Entities.Concrete;
using Hospital.Shared.Entities.Absract;

namespace Hospital.Entities.Concrete;

public class Patient : EntityBase, IEntity
{

   
    public string FirstName { get; set; }

 
    public string LastName { get; set; }


    public DateTime DateOfBirth { get; set; }

 
    public string Gender { get; set; }


    public string PhoneNumber { get; set; }


    public string Email { get; set; }


    public string Address { get; set; }

 public  override bool? IsActive { get; set; } = true;

    // Randevu ilişkisi (Bir hasta, birçok randevu alabilir)
    public ICollection<Appointment> Appointments { get; set; }
}




