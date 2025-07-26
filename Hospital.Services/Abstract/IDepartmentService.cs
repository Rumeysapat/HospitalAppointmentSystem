using Hospital.Entities.Concrete;
using Hospital.Entities.Dtos;
using Hospital.Shared.Utilities.Results.Abstract;

namespace Hospital.Services.Abstract;

public interface IDepartmentService
{
    Task <IDataResult<DepartmentListDto>>GetAll();
}