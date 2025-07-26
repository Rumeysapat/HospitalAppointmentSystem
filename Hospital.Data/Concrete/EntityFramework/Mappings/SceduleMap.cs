using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hospital.Entities.Concrete;

public class ScheduleMap : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        // Schedule tablosunun ayarları
        builder.ToTable("Schedules");

        // DoctorId, Foreign Key (FK) ilişkisi
        builder.HasOne(s => s.Doctor)
            .WithMany(d => d.Schedules) // Doktor birden fazla takvimde olabilir.
            .HasForeignKey(s => s.DoctorId)
            .OnDelete(DeleteBehavior.Cascade); // Eğer bir doktor silinirse, ona bağlı olan takvimler de silinsin.

        // DayOfWeek enum, veri tipi
        builder.Property(s => s.Day)
            .IsRequired(); // Gün bilgisi zorunlu

        // Başlangıç ve bitiş saatleri
        builder.Property(s => s.StartTime)
            .IsRequired(); // Başlangıç saati zorunlu

        builder.Property(s => s.EndTime)
            .IsRequired(); // Bitiş saati zorunlu

        // Varsayılan değerler, eğer isteniyorsa
        builder.Property(s => s.StartTime)
            .HasDefaultValue(TimeSpan.FromHours(9)); // Varsayılan başlangıç saati 09:00

        builder.Property(s => s.EndTime)
            .HasDefaultValue(TimeSpan.FromHours(17)); // Varsayılan bitiş saati 17:00
    }
}
