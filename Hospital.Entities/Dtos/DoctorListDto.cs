using Hospital.Entities.Concrete;
using Hospital.Shared.Entities.Abstract;
using Hospital.Shared.Utilities.Results.ComplexTypes;

namespace Hospital.Entities.Dtos;

public class DoctorListDto:DtoGetBase{

  public IList<DoctorDto> Doctors { get; set; }

}