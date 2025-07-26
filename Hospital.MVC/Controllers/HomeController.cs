using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hospital.MVC.Models;
using Hospital.Data.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospital.Services.Abstract;
using System.Threading.Tasks;
using Hospital.Shared.Utilities.Results.ComplexTypes;
using Hospital.Entities.Dtos;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Hospital.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IDoctorService _doctorService;
    private readonly IDepartmentService _departmentService;
    private readonly IAppointmentService _appointmentService;
    private readonly IPatientService _patientService;

    public HomeController(IDoctorService doctorService, IDepartmentService departmentService, IAppointmentService appointmentService, IPatientService patientService)
    {
        _doctorService = doctorService;
        _departmentService = departmentService;
        _appointmentService = appointmentService;

        _patientService = patientService;

    }
public async Task<IActionResult> Index()
{
    var departmentResult = await _departmentService.GetAll();

    var doctorDepartmentViewModel = new DoctorDepartmentViewModel
    {
        DepartmentList = departmentResult.Data,
        DoctorList = null
    };

    var combinedViewModel = new CombinedViewModel
    {
        DoctorDepartment = doctorDepartmentViewModel,
        Appointment = new AppointmentViewModel()
    };

    ViewBag.ErrorMessage = TempData["Error"];

    return View(combinedViewModel);
}



    [HttpGet]
    public async Task<IActionResult> GetDoctorsByDepartment(int departmentId)
    {
        try
        {
            var doctorResult = await _doctorService.GetAllByDepartmentAsync(departmentId);

            if (doctorResult.ResultStatus == ResultStatus.Success && doctorResult.Data?.Doctors != null)
            {
                return Json(doctorResult.Data.Doctors);
            }

            return Json(new List<object>()); // boş liste dön
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Sunucu hatası: {ex.Message}");
        }
    }






    [HttpPost]
    public async Task<IActionResult> MakeAppointment(CombinedViewModel model)
    {
        Console.WriteLine(">>> Randevu kaydı çalıştı");

        // Kullanıcıyı email ile getir
        var patient = await _patientService.GetUserByEmailAsync(model.Appointment.Email);

        if (patient == null)
        {
            // Yeni kullanıcı oluştur
            patient = new Patient
            {
               FirstName = string.IsNullOrEmpty(model.Appointment.Name) ? "Belirsiz" : model.Appointment.Name,
    LastName = "Belirsiz", // Zorunlu
    DateOfBirth = DateTime.Now.AddYears(-30), // Varsayılan doğum tarihi (zorunlu)
    Gender = "Belirsiz", // Zorunlu
    PhoneNumber = "0000000000", // Zorunlu
    Email = model.Appointment.Email,
    IsActive = true,
    CreatedDate = DateTime.Now
            };

            patient = await _patientService.CreatePatientAsync(patient);
            if (patient == null)
            {
                TempData["Error"] = "Kullanıcı oluşturulamadı.";
                return RedirectToAction("Index");
            }
        }

        // Model doğrulama logları
        foreach (var key in ModelState.Keys)
        {
            var value = ModelState[key];
            foreach (var error in value.Errors)
            {
                Console.WriteLine($"Field: {key}, Error: {error.ErrorMessage}");
            }
        }

        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Form verileri geçersiz.";
            return RedirectToAction("Index");
        }

        // Doktor ve tarih seçildiyse uygun saatleri al
        if (model.Appointment.SelectedDoctorId != 0 && model.Appointment.SelectedDate != DateTime.MinValue)
        {
            var availableHoursResult = await _doctorService.GetAvailableHoursAsync(model.Appointment.SelectedDoctorId, model.Appointment.SelectedDate);
            if (availableHoursResult.ResultStatus == ResultStatus.Success)
            {
                model.Appointment.AvailableHours = availableHoursResult.Data.ToList();
            }
            else
            {
                TempData["Error"] = availableHoursResult.Message;
                return RedirectToAction("Index");
            }
        }

        // Saat seçildiyse randevu oluştur
        if (!string.IsNullOrEmpty(model.Appointment.SelectedSlot))
        {
            if (patient == null)
            {
                TempData["Error"] = "Hasta bilgisi bulunamadı.";
                return RedirectToAction("Index");
            }

            // Randevu nesnesi oluşturuluyor
            var newAppointment = new Appointment
            {
                PatientId = patient.Id,
                DoctorId = model.Appointment.SelectedDoctorId,
                AppointmentDate = model.Appointment.SelectedDate,
                AppointmentTime = TimeSpan.Parse(model.Appointment.SelectedSlot),
                CreatedDate = DateTime.Now
            };

            try
            {
                await _appointmentService.CreateAppointmentAsync(newAppointment);
                return RedirectToAction("AppointmentSuccess");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Randevu oluşturulurken hata oluştu: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // Slot seçilmemişse hata ver
        TempData["Error"] = "Lütfen bir saat seçiniz.";
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> GetAvailableHours(int doctorId, DateTime date)
    {
        try
        {
            var result = await _doctorService.GetAvailableHoursAsync(doctorId, date);

            if (result.ResultStatus == ResultStatus.Success && result.Data != null)
            {
                return Json(result.Data);  // Boş saatleri JSON olarak döndür
            }

            return Json(result.Data.Select(ts => ts.ToString(@"hh\:mm")).ToList());
            // Boş liste dön
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Sunucu hatası: {ex.Message}");
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetAppointmentStatus(int doctorId, DateTime date)
    {
        try
        {
            // Sadece dolu saatleri al
            var result = await _doctorService.GetOccupiedHoursAsync(doctorId, date);

            if (result.ResultStatus == ResultStatus.Success && result.Data != null)
            {
                return Json(result.Data.Select(ts => ts.ToString(@"hh\:mm")).ToList());
                // List<TimeSpan> - dolu saatler
            }

            return Json(new List<TimeSpan>());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Sunucu hatası: {ex.Message}");
        }
    }


    public IActionResult AppointmentSuccess()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetWorkingHours(int doctorId)
    {
        var workingHours = new List<string>();
        for (TimeSpan time = TimeSpan.FromHours(9); time < TimeSpan.FromHours(17); time += TimeSpan.FromMinutes(20))
        {
            workingHours.Add(time.ToString(@"hh\:mm"));
        }
        return Json(workingHours);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
