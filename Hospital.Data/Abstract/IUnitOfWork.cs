using Hospital.Data.Abstract;

namespace Hospital.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IDoctorRepository Doctors { get; }
        IPatientRepository Patients { get; }
        IScheduleRepository Schedules{ get; }
        IRoleRepository Roles { get; }
        IUserRepository Users   { get; }

           IAppointmentRepository Appointments{ get; }

              IDepartmentRepository Departments { get; }
        /*  _unitOfWork.Categories.AddAsyc(Caterory)*/

        Task <int> SaveAsync ();
        
    }
}