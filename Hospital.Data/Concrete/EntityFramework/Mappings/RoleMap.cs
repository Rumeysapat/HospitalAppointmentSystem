
using Hospital.Entities.Concrete;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Data.Concrete.EntityFramework.Mappings;

    public class RoleMap:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.Name).HasMaxLength(30);
            builder.Property(r => r.Description).IsRequired();
            builder.Property(r => r.Description).HasMaxLength(250);
       
            builder.Property(r => r.CreatedDate).IsRequired();
            builder.Property(r => r.ModifiedDate).IsRequired();
            builder.Property(r => r.IsActive).IsRequired();
            builder.Property(r => r.IsDeleted).IsRequired();

            builder.ToTable("Roles");
            builder.HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                Description = "Admin Rolü, Tüm Haklara Sahiptir.",
                IsActive = true,
                IsDeleted = false,
       
                CreatedDate = DateTime.Now,
            
                ModifiedDate = DateTime.Now,
          
            });
        }
    }

