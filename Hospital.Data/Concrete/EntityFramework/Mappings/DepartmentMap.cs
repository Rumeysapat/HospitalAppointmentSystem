
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hospital.Entities.Concrete;
namespace Hospital.Data.Concrete.EntityFramework.Mappings;


public class DepartmentMap : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id); // Primary Key
        builder.Property(d => d.Name)
               .IsRequired()
               .HasMaxLength(100); // Departman ismi zorunlu ve max 100 karakter

        // One-to-Many (Bir departmanda birden fazla doktor olabilir)
        builder.HasMany(d => d.Doctors)
               .WithOne(doc => doc.Department)
               .HasForeignKey(doc => doc.DepartmentId)
               .OnDelete(DeleteBehavior.Cascade); // Departman silinirse doktorlar da silinir

        // Örnek Seed Data (Varsayılan Departman Verileri)
        builder.HasData(
            new Department { Id = 1, Name = "Kardiyoloji", CreatedDate = DateTime.UtcNow },
            new Department { Id = 2, Name = "Ortopedi", CreatedDate = DateTime.UtcNow },
            new Department { Id = 3, Name = "Nöroloji", CreatedDate = DateTime.UtcNow }
        );
    }
}
