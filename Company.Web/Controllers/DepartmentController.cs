using Company.Data.Models;
//using Company.Service.Interfaces.Department;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Dto;

namespace Company.Web.Controllers
{


    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            TempData.Keep("TextTempMessage");
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(DepartmentDto departmentDto)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    _departmentService.Add(departmentDto);
                    TempData["TextTempMessage"] = "Hello from Employee index";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("DepartmentError", "ValidationsError");
                return View(departmentDto);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(departmentDto);
            }
          
        }


        public IActionResult Details(int? id, string viewName = "Details")
        {
            var department = _departmentService.GetById(id);

            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");
            return View(viewName, department);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {

            return Details(id, "Update");
        }

        [HttpPost]
        public IActionResult Update(int? id, DepartmentDto departmentDto)
        {
            if (departmentDto.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");
            _departmentService.Update(departmentDto);
            return RedirectToAction(nameof(Index));
        }
     
        public IActionResult Delete (int id)
        {
            var department = _departmentService.GetById(id);

            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");
            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));
        }

    }
}
