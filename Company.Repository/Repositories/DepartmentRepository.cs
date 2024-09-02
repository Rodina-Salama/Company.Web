using Company.Data.Context;
using Company.Data.Models;
using Company.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {

        private readonly CompanyDbContext _context;

        public DepartmentRepository(CompanyDbContext context) :base(context)
        {
            _context = context;
        }
        //public void Add(Department department)
        //{
        //    _context.Add(department);
        //}

        //public void Delete(Department department)
        //{
        //    _context.Remove(department);
        //}

        //public IEnumerable<Department> GetAll()
        //=>
        //    _context.Departments.ToList();

        //public Employee GetById(int id)
        //     => _context.Employees.FirstOrDefault(x => x.Id == id);

        //public void Update(Department department)
        //{
        //    _context.Update(department);
        //}
    }
}
