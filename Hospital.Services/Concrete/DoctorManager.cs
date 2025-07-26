using Hospital.Services.Abstract;
using Hospital.Data.Abstract;
using Hospital.Shared.Utilities;
using Hospital.Shared.Utilities.Results.Abstract;
using Hospital.Entities.Dtos;
using Blog.Data.Shared.Utilities.Results.Concrete;
using Hospital.Shared.Utilities.Results.ComplexTypes;
using Hospital.Entities.Concrete;


namespace Hospital.Services.Concrete;

public class DoctorManager : IDoctorService
{

    private readonly IUnitOfWork _unitOfWork;

    public DoctorManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IDataResult<DoctorListDto>> GetAll()
    {
        // Tüm doktorları alıyoruz
        var doctors = await _unitOfWork.Doctors.GetAllAsync();

        // Eğer doktor varsa
        if (doctors.Any())
        {
            // Doctor nesnelerini DoctorDto'ya dönüştürüyoruz
            var doctorDtos = doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                Name = d.Name,
                Specialization = d.Specialization,
                DepartmentId = d.DepartmentId,
                Departments = d.Department != null ? new DepartmentDto
                {
                    Id = d.Department.Id,
                    Name = d.Department.Name
                } : null
            }).ToList(); // Listeye çeviriyoruz

            return new DataResult<DoctorListDto>(ResultStatus.Success, new DoctorListDto
            {
                Doctors = doctorDtos,  // DTO listesi olarak atıyoruz
                ResultStatus = ResultStatus.Success
            });
        }

        // Eğer doktor yoksa, hata mesajı döndürüyoruz
        return new DataResult<DoctorListDto>(ResultStatus.Error, "No doctors found.", null);
    }

    public async Task<IDataResult<DoctorListDto>> GetAllByDepartmentAsync(int departmentId)
    {
        var doctors = await _unitOfWork.Doctors.GetAllAsync(d => d.DepartmentId == departmentId);


        // Eğer doktor varsa
        if (doctors.Any())
        {
            var doctorDtos = doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                Name = d.Name,
                Specialization = d.Specialization,
                DepartmentId = d.DepartmentId,
                Departments = d.Department != null ? new DepartmentDto
                {
                    Id = d.Department.Id,
                    Name = d.Department.Name
                } : null
            }).ToList(); // Listeye çeviriyoruz

            return new DataResult<DoctorListDto>(ResultStatus.Success, new DoctorListDto
            {
                Doctors = doctorDtos,  // Artık DTO listesi atıyoruz
                ResultStatus = ResultStatus.Success
            });
        }

        // Eğer doktor yoksa, hata mesajı döndürüyoruz
        return new DataResult<DoctorListDto>(ResultStatus.Error, "No doctors found.", null);
    }
    public async Task<IList<Doctor>> GetAllDoctorsAsync()
    {
        return await _unitOfWork.Doctors.GetAllAsync();
    }


private List<TimeSpan> GenerateTimeSlots(TimeSpan start, TimeSpan end, TimeSpan interval)
{
    var slots = new List<TimeSpan>();
    var current = start;

    while (current < end)
    {
        slots.Add(current);
        current = current.Add(interval);
    }

    return slots;
}
public async Task<IDataResult<IList<TimeSpan>>> GetAvailableHoursAsync(int doctorId, DateTime date)
{
    // O gün o doktora ait randevuları getir
    var appointments = await _unitOfWork.Appointments.GetAppointmentsByDoctorAndDateAsync(doctorId, date);

    if (appointments == null)
    {
        return new DataResult<IList<TimeSpan>>(ResultStatus.Error, "Appointments not found.", null);
    }

    // Çalışma saatlerini belirle (örnek: 09:00 - 17:00)
    var startTime = new TimeSpan(9, 0, 0);
    var endTime = new TimeSpan(17, 0, 0);
    var slotDuration = TimeSpan.FromMinutes(30);

    var allSlots = new List<TimeSpan>();
    for (var time = startTime; time < endTime; time = time.Add(slotDuration))
    {
        allSlots.Add(time);
    }

    // Dolu saatler
var occupiedSlots = appointments.Select(a => a.AppointmentDate.TimeOfDay).ToList();


    // Boş saatler
    var availableSlots = allSlots.Where(slot => !occupiedSlots.Contains(slot)).ToList();

    return new DataResult<IList<TimeSpan>>(ResultStatus.Success, availableSlots);
}
 public async Task<IDataResult<List<TimeSpan>>> GetOccupiedHoursAsync(int doctorId, DateTime date)
    {
        var appointments = await _unitOfWork.Appointments.GetAppointmentsByDoctorAndDateAsync(doctorId, date);

        if (appointments == null)
        {
            return new DataResult<List<TimeSpan>>(ResultStatus.Error, "Appointments not found.", null);
        }

       var occupiedSlots = appointments
    .Select(a => a.AppointmentTime != TimeSpan.Zero ? a.AppointmentTime : a.AppointmentDate.TimeOfDay)
    .ToList();

        return new DataResult<List<TimeSpan>>(ResultStatus.Success, occupiedSlots);
    }
}
