using Hospital.Entities.Concrete;
using Hospital.Shared.Data.Abstract;

namespace Hospital.Data.Abstract
{
    public interface IDoctorRepository : IEntityRepository<Doctor>
    {
        Task<List<Doctor>> GetDoctorsByDepartmentAsync(int departmentId);

    }
}