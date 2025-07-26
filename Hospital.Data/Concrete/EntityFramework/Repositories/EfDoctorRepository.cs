using Hospital.Data.Abstract;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Hospital.Shared.Data.Concrete.EntityFramework;
using Hospital.Data.Concrete.EntityFramework.Contexts;

namespace Hospital.Data.Concrete
{
       public class EfDoctorRepository : EfEntityRepositoryBase<Doctor>, IDoctorRepository
{
    public EfDoctorRepository(DbContext context) : base(context) { }

    public async Task<List<Doctor>> GetDoctorsByDepartmentAsync(int departmentId)
    {
        // GetAsync metodunu kullanarak departman ID'sine göre doktorları al
        var doctors = await GetAllAsync(
            d => d.DepartmentId == departmentId // predicate (filtreleme) kısmı
        );

        return doctors.ToList(); // Eğer birden fazla doktor döndürmek istersen, bu satırı genişletebilirsin.
    }
}
}