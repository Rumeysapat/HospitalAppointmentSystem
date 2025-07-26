using Hospital.Entities.Dtos;

namespace Hospital.MVC.Models
{
    public class DoctorDepartmentViewModel
    {
        public  DoctorListDto DoctorList { get; set; }
        public DepartmentListDto DepartmentList { get; set; }
    }
}
