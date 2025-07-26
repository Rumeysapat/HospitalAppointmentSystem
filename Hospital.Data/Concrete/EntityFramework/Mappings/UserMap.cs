using System.Text;
using Hospital.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Hospital.Data.Concrete.EntityFramework.Mappings;


public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Tablo adını belirleme
        builder.ToTable("Users");

        // Primary Key
        builder.HasKey(u => u.Id);

        // FirstName zorunlu ve maksimum uzunluk 50
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        // LastName zorunlu ve maksimum uzunluk 50
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);

        // Email zorunlu, benzersiz ve maksimum uzunluk 100
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(u => u.Email).IsUnique();

        // Username zorunlu ve maksimum uzunluk 50
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        // PasswordHash zorunlu
        builder.Property(u => u.PasswordHash)
            .IsRequired();

        // Picture opsiyonel
        builder.Property(u => u.Picture)
            .HasMaxLength(250);

        // Description opsiyonel
        builder.Property(u => u.Description)
            .HasMaxLength(500);

        // Role ilişkilendirmesi (User -> Role) (Many-to-One)
      builder.HasOne<Role>(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
        // Varsayılan veriler (Seed Data)
        builder.HasData(
            new User
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@hospital.com",
                Username = "admin",
                PasswordHash = new byte[0], // Buraya varsayılan bir hash eklemelisin
                Picture = "default.jpg",
                Description = "Sistem yöneticisi",
                RoleId = 1,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                IsDeleted = false
            }
        );
    }
}
