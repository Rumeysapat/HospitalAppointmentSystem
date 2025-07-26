using Hospital.Entities.Concrete;
using Hospital.Services.Abstract;
using Hospital.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Hospital.Services.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        // Constructor - sadece UnitOfWork alır
        public AppointmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Interface'den gelen metodun implementasyonu
        public async Task<List<Appointment>> GetAppointmentsByDoctorAndDateAsync(int doctorId, DateTime date)
        {
            // UnitOfWork içindeki repository aracılığıyla veriyi al
            var appointments = await _unitOfWork.Appointments.GetAppointmentsByDoctorAndDateAsync(doctorId, date);
            
            return appointments;
        }
        public async Task CreateAppointmentAsync(Appointment appointment)
    {
        await _unitOfWork.Appointments.AddAsync(appointment);
        await _unitOfWork.SaveAsync();
    }
    }

}
