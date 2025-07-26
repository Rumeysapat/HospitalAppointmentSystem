namespace Hospital.Shared.Entities.Absract;
public abstract class EntityBase
{
    public virtual int Id { get; set; } // Benzersiz ID
    public virtual DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Oluşturulma zamanı
    public virtual DateTime? ModifiedDate { get; set; } // Güncellenme zamanı (nullable)
    public virtual bool? IsActive { get; set; } = true; // Varsayılan olarak aktif
    public virtual bool IsDeleted { get; set; } = false; // Silinme durumu
}
