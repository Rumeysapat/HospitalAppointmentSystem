using Hospital.Data.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class HospitalAppointmentDbContextFactory : IDesignTimeDbContextFactory<HospitalAppointmentDbContext>
{
    public HospitalAppointmentDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HospitalAppointmentDbContext>();
        optionsBuilder.UseSqlite("Data Source=Hospital.db");

        return new HospitalAppointmentDbContext(optionsBuilder.Options);
    }
}
