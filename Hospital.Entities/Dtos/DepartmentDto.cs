using Hospital.Entities.Concrete;
using Hospital.Shared.Entities.Abstract;
using Hospital.Shared.Utilities.Results.ComplexTypes;

namespace Hospital.Entities.Dtos;

public class DepartmentDto:DtoGetBase{


    
        public int Id { get; set; }   // Departman ID'si
        public string Name { get; set; }  // Departman adı
    }
