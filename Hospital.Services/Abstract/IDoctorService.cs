using Hospital.Entities.Dtos;
using Hospital.Shared.Utilities.Results.Abstract;
using Hospital.Entities.Concrete;


namespace Hospital.Services.Abstract;

public interface IDoctorService
{

  Task<IDataResult<DoctorListDto>> GetAllByDepartmentAsync(int departmentId);
  Task<IList<Doctor>> GetAllDoctorsAsync();

  Task<IDataResult<IList<TimeSpan>>> GetAvailableHoursAsync(int doctorId, DateTime date);

Task<IDataResult<List<TimeSpan>>> GetOccupiedHoursAsync(int doctorId, DateTime date);







}