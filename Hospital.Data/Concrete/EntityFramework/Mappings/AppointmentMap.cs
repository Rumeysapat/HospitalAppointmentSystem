using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AppointmentMap : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.Id); // Primary Key

        builder.Property(a => a.AppointmentDate)
               .IsRequired(); // Randevu tarihi zorunlu

        builder.Property(a => a.Notes)
               .HasMaxLength(500); // Notlar için maksimum 500 karakter

        // Hasta ilişkisi (Many-to-One)
        builder.HasOne(a => a.Patient)
               .WithMany(p => p.Appointments) // Bir hastanın birden fazla randevusu olabilir
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Cascade); // Hasta silinirse randevuları da silinir

        // Doktor ilişkisi (Many-to-One)
        builder.HasOne(a => a.Doctor)
               .WithMany(d => d.Appointments) // Bir doktorun birden fazla randevusu olabilir
               .HasForeignKey(a => a.DoctorId)
               .OnDelete(DeleteBehavior.Restrict); // Doktor silinirse randevular korunur

        // Örnek Seed Data (Varsayılan Randevu Verileri)
     builder.HasData(
    new Appointment 
    { 
        Id = 1, 
        PatientId = 1, 
        DoctorId = 1, 
        AppointmentDate = new DateTime(2025, 3, 17, 9, 0, 0), // 17 Mart 2025, Saat 09:00
        Notes = "Kontrol randevusu", 
        CreatedDate = new DateTime(2025, 3, 16, 10, 30, 0) // 16 Mart 2025, Saat 10:30
    },
    new Appointment 
    { 
        Id = 2, 
        PatientId = 2, 
        DoctorId = 2, 
        AppointmentDate = new DateTime(2025, 3, 18, 14, 30, 0), // 18 Mart 2025, Saat 14:30
        Notes = "Diyet planı kontrolü", 
        CreatedDate = new DateTime(2025, 3, 16, 10, 45, 0) // 16 Mart 2025, Saat 10:45
    },
    new Appointment 
    { 
        Id = 3, 
        PatientId = 3, 
        DoctorId = 3, 
        AppointmentDate = new DateTime(2025, 3, 19, 11, 0, 0), // 19 Mart 2025, Saat 11:00
        Notes = "Genel sağlık kontrolü", 
        CreatedDate = new DateTime(2025, 3, 16, 11, 0, 0) // 16 Mart 2025, Saat 11:00
    }
);

    }
}
