using Hospital.Entities.Concrete;
using Hospital.Shared.Entities.Abstract;
using Hospital.Shared.Utilities.Results.ComplexTypes;

namespace Hospital.Entities.Dtos;

public class DepartmentListDto:DtoGetBase{

  public IList<Department> Departments { get; set; }

}