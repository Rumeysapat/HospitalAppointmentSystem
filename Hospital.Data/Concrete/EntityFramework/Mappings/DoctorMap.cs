using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Hospital.Data.Concrete.EntityFramework.Mappings;
using Hospital.Entities.Concrete;

public class DoctorMap:IEntityTypeConfiguration <Doctor>
{
public void Configure(EntityTypeBuilder<Doctor>builder)
{
builder.ToTable("Doctors"); // Veritabanındaki tablo adı

        builder.HasKey(d => d.Id); // Primary Key

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100); // Doktor ismi en fazla 100 karakter olabilir

        // Foreign Key - Bir doktor bir departmana bağlı olabilir
        builder.HasOne(d => d.Department)
            .WithMany(dep => dep.Doctors) // Bir departmanın birden fazla doktoru olabilir
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade); // Departman silinirse, doktorlar da silinsin

        // Bir doktorun birden fazla randevusu olabilir
        builder.HasMany(d => d.Appointments)
            .WithOne(a => a.Doctor)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Cascade); // Doktor silinirse randevular da silinsin

        // Varsayılan değerler
        builder.Property(d => d.CreatedDate).IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP"); // Varsayılan oluşturulma tarihi

        builder.Property(d => d.IsActive)
            .HasDefaultValue(true);

        builder.Property(d => d.IsDeleted)
            .HasDefaultValue(false);

           builder.HasData(
   new Doctor
    {
        Id = 1,
        Name = "Dr. Ahmet Yılmaz",
        DepartmentId = 1, // Kardiyoloji bölümü
        CreatedDate = DateTime.Now,
        IsActive = true,
        IsDeleted = false
    },
    new Doctor
    {
        Id = 2,
        Name = "Dr. Ayşe Demir",
        DepartmentId = 2, // Dermatoloji bölümü
        CreatedDate = DateTime.Now,
        IsActive = false,
        IsDeleted = false
    },
    new Doctor
    {
        Id = 3,
        Name = "Dr. Mehmet Kaya",
        DepartmentId = 3, // Ortopedi bölümü
        CreatedDate = DateTime.Now,
        IsActive = true,
        IsDeleted = false
    },
    new Doctor
    {
        Id = 4,
        Name = "Dr. Zeynep Çelik",
        DepartmentId = 1, // Nöroloji bölümü
        CreatedDate = DateTime.Now,
        IsActive = false,
        IsDeleted = false
    },
    new Doctor
    {
        Id = 5,
        Name = "Dr. Canan Öztürk",
        DepartmentId = 1, // Göz Hastalıkları bölümü
        CreatedDate = DateTime.Now,
        IsActive = true,
        IsDeleted = false
    }
);


}

}