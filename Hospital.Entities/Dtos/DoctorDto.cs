using Hospital.Entities.Concrete;
using Hospital.Shared.Entities.Abstract;

namespace Hospital.Entities.Dtos
{
    public class DoctorDto : DtoGetBase
    {
        // Tek bir doktorun adı ve diğer bilgilerini tutacak şekilde düzenliyoruz
        public int Id { get; set; }       // Doktorun ID'si
        public string Name { get; set; }   // Doktorun adı
        public string Specialization { get; set; }  // Uzmanlık alanı (isteğe bağlı)
        public int DepartmentId { get; set; }        // Doktorun bağlı olduğu departman ID'si
         public DepartmentDto Departments { get; set; }
       

        public Doctor doctor{ get; set; }
    }
}
