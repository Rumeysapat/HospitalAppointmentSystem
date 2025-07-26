using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hospital.Entities.Concrete;
namespace Hospital.Data.Concrete.EntityFramework.Mappings;
public class PatientMap : IEntityTypeConfiguration<Patient>
{
           public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");

        builder.Property(p => p.FirstName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(p => p.LastName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(p => p.DateOfBirth)
               .IsRequired();

        builder.Property(p => p.Gender)
               .IsRequired()
               .HasMaxLength(10);

        builder.Property(p => p.PhoneNumber)
               .IsRequired()
               .HasMaxLength(15);

        builder.Property(p => p.Email)
               .HasMaxLength(100);

        builder.Property(p => p.Address)
               .HasMaxLength(250);

        builder.Property(p => p.IsActive)
               .HasDefaultValue(true);
                 builder.HasData(
                new Patient
                {
                    Id = 1,
                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    DateOfBirth = new DateTime(1985, 5, 20),
                    Gender = "Male",
                    PhoneNumber = "555-1234567",
                    Email = "ahmet.yilmaz@example.com",
                    Address = "İstanbul, Türkiye",
                    IsActive = true
                },
                new Patient
                {
                    Id = 2,
                    FirstName = "Ayşe",
                    LastName = "Demir",
                    DateOfBirth = new DateTime(1990, 8, 15),
                    Gender = "Female",
                    PhoneNumber = "555-9876543",
                    Email = "ayse.demir@example.com",
                    Address = "Ankara, Türkiye",
                    IsActive = true
                },
                new Patient
                {
                    Id = 3,
                    FirstName = "Mehmet",
                    LastName = "Kara",
                    DateOfBirth = new DateTime(1980, 2, 10),
                    Gender = "Male",
                    PhoneNumber = "555-2468101",
                    Email = "mehmet.kara@example.com",
                    Address = "İzmir, Türkiye",
                    IsActive = true
                }
            );
    }
}
