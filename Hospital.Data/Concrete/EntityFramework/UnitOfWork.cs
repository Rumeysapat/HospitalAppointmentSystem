using Hospital.Data.Abstract;
using Hospital.Data.Concrete.EntityFramework.Contexts;
using Hospital.Data;




namespace Hospital.Data.Concrete
{

    public class UnitOfWork : IUnitOfWork
    {

        private readonly HospitalAppointmentDbContext _context;

        private EfDoctorRepository _doctorRepository;
        private   EfPatientRepository _patientRepository;
        private  EfDepartmentRepository _departmentRepository;
        private  EfRoleRepository _roleRepository;
        private  EfUserRepository _userRepository;

        private   EfScheduleRepository _scheduleRepository;

        private  EfAppointmentRepository _appointmentRepository;





        

        public UnitOfWork(HospitalAppointmentDbContext context)
        {
            _context=context;
        }

        public IDoctorRepository Doctors => _doctorRepository ?? new EfDoctorRepository(_context);


        public IPatientRepository Patients  => _patientRepository ?? new EfPatientRepository(_context);


        public IAppointmentRepository Appointments => _appointmentRepository ?? new EfAppointmentRepository(_context);

        public IRoleRepository Roles => _roleRepository ?? new EfRoleRepository(_context);

        public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);

         public IScheduleRepository Schedules => _scheduleRepository ?? new EfScheduleRepository(_context);

          public IDepartmentRepository Departments => _departmentRepository ?? new EfDepartmentRepository(_context);

        public async ValueTask DisposeAsync()
        {
             await _context.DisposeAsync();
        }

        public  async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}