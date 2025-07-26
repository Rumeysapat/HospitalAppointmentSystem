using System.ComponentModel.DataAnnotations;
using Hospital.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace Hospital.MVC.Models;

public class AppointmentViewModel
{
    [Required]
    [FromForm(Name = "name")]

    public string Name { get; set; }

    [Required]
    [EmailAddress]
    [FromForm(Name = "email")]
    public string Email { get; set; }

    [Required]
    [FromForm(Name = "phone")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Doktor seçiniz.")]
    public int SelectedDoctorId { get; set; }

    public int SelectedDepartmentId { get; set; }


    [Required(ErrorMessage = "Randevu tarihi giriniz.")]
    [DataType(DataType.Date)]
    public DateTime SelectedDate { get; set; }

    [Required(ErrorMessage = "Randevu saati seçiniz.")]
    public string SelectedSlot { get; set; }

    public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    public List<Department> Departments { get; set; } = new List<Department>();
    public List<TimeSpan> OccupiedHours { get; set; } = new List<TimeSpan>();
    public List<TimeSpan> AvailableHours { get; set; } = new List<TimeSpan>();
}
