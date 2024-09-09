using Company.Data.Models;

namespace Company.Web.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreateAt { get; set; }
        public ICollection<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>();
    }
}
