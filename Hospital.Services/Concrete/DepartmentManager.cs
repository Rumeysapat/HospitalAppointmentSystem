using Hospital.Services.Abstract;
using Hospital.Data.Abstract;
using Hospital.Shared.Utilities;
using Hospital.Shared.Utilities.Results.Abstract;
using Hospital.Entities.Dtos;
using Blog.Data.Shared.Utilities.Results.Concrete;
using Hospital.Shared.Utilities.Results.ComplexTypes;
using Hospital.Entities.Concrete;


namespace Hospital.Services.Concrete;

public class DepartmentManager:IDepartmentService
{

private readonly IUnitOfWork _unitOfWork;

public DepartmentManager(IUnitOfWork unitOfWork)
{
    _unitOfWork = unitOfWork;
}
public async Task<IDataResult<DepartmentListDto>> GetAll()
{
    // Tüm doktorları alıyoruz
    var departments = await _unitOfWork.Departments.GetAllAsync();

    // Eğer doktor varsa
    if (departments.Any())
    {
        return new DataResult<DepartmentListDto>(ResultStatus.Success, new DepartmentListDto
        {
            Departments = departments,  // Doktorları DTO'ya atıyoruz
            ResultStatus = ResultStatus.Success
        });
    }

    // Eğer department yoksa, hata mesajı döndürüyoruz
    return new DataResult<DepartmentListDto>(ResultStatus.Error, "No doctors found.", null);
}
}