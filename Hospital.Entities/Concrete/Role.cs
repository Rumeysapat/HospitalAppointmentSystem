using Hospital.Shared.Entities;
using Hospital.Shared.Entities.Absract;


namespace Hospital.Entities.Concrete
{
public  class Role:EntityBase,IEntity
{

public string Name { get; set; }
public string Description { get; set; } 

   public ICollection<User> Users { get; set; } 

    
    
}
}