using Company.Data.Models;

namespace Company.Web.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }
        public DepartmentViewModel Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
