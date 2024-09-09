using Company.Data.Models;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Dto;
using Company.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller

    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        public EmployeeController(IEmployeeService employeeService , IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index( string SearchInp)
        {
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            if (string.IsNullOrEmpty(SearchInp)) 
                employees = _employeeService.GetAll();
           
            else
                employees = _employeeService.GetEmployeeByName(SearchInp);
                return View(employees);
            
        }


        [HttpGet]
        public IActionResult Create()
        {
            //var departments = _departmentService.GetAll();
            
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
               
                return View(employee);
            }
            catch (Exception ex)
            {
               
                return View(employee);
            }
        }

        //public IActionResult Details(int ? id , string viewName="Details")
        //{

        //}
        //[HttpGet]
        //public IActionResult Update(int? id)
        //{

        //}
        //[HttpPost]
        //public IActionResult Update(int id)
        //{

        //}
        //public IActionResult Delete( int id)
        //{

        //}
    }
}
