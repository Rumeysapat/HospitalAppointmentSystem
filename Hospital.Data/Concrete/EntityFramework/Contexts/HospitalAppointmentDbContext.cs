using Hospital.Entities.Concrete;
using Hospital.Data.Concrete.EntityFramework.Mappings;

using Microsoft.EntityFrameworkCore;


namespace Hospital.Data.Concrete.EntityFramework.Contexts;
public class HospitalAppointmentDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }

       public DbSet<Role> Roles { get; set; }


    public HospitalAppointmentDbContext(DbContextOptions<HospitalAppointmentDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

// Fluent API burada tanımlanır.
modelBuilder.ApplyConfiguration(new DepartmentMap());  // 1. Sırada: Departmanlar
modelBuilder.ApplyConfiguration(new DoctorMap());     // 2. Sırada: Doktorlar (Departmanlara bağlı)
modelBuilder.ApplyConfiguration(new PatientMap());    // 3. Sırada: Hastalar (Doktorlara bağlı)
modelBuilder.ApplyConfiguration(new AppointmentMap()); // 4. Sırada: Randevular (Hastalara ve doktorlara bağlı)
modelBuilder.ApplyConfiguration(new RoleMap());       // 5. Sırada: Roller (Bağımsız bir yapı)
modelBuilder.ApplyConfiguration(new ScheduleMap());   // 6. Sırada: Takvimler (Bağımsız bir yapı)
modelBuilder.ApplyConfiguration(new UserMap());       // 7. Sırada: Kullanıcılar (Bağımsız bir yapı)

    }
}
