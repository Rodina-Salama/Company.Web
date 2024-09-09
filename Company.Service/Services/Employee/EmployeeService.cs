using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interface;
using Company.Service.Helper;
using Company.Service.Interfaces;
//using Company.Service.Interfaces.Employee;
using Company.Service.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services.Employee
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
      

        public void Add(EmployeeDto employeeDto)
        {
            //Manual mapping
            //Data.Models.Employee employee = new Data.Models.Employee
            //{
            //      Address = employeeDto.Address,
            //      Age = employeeDto.Age,
            //      DepartmentId = employeeDto.DepartmentId,
            //      Name = employeeDto.Name,
            //      Email = employeeDto.Email,
            //      ImgUrl = employeeDto.ImgUrl,
            //      HiringDate = employeeDto.HiringDate,
            //      PhoneNumber = employeeDto.PhoneNumber,
            //      Salary = employeeDto.Salary
            //  };

            employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image, "Images");
            Data.Models.Employee employee = _mapper.Map<Data.Models.Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

       
        public void Delete(EmployeeDto employeeDto)
        {
            //Data.Models.Employee employee = new Data.Models.Employee
            //{
            //    Id=employeeDto.Id,
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Name = employeeDto.Name,
            //    Email = employeeDto.Email,
            //    ImgUrl = employeeDto.ImgUrl,
            //    HiringDate = employeeDto.HiringDate,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    Salary = employeeDto.Salary
            //};
            Data.Models.Employee employee = _mapper.Map<Data.Models.Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }




        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {   var employees =_unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    Id = x.Id,
            //    Address = x.Address,
            //    Age = x.Age,
            //    DepartmentId = x.DepartmentId,
            //    Name = x.Name,
            //    Email = x.Email,
            //    ImgUrl = x.ImgUrl,
            //    HiringDate = x.HiringDate,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    CreateAt = x.CreateAt


            //});
           IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public void Update(EmployeeDto employee)
        {
          //  _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }

        IEnumerable<EmployeeDto> IEmployeeService.GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    Id=x.Id,
            //    Address = x.Address,
            //    Age = x.Age,
            //    DepartmentId = x.DepartmentId,
            //    Name = x.Name,
            //    Email = x.Email,
            //    ImgUrl = x.ImgUrl,
            //    HiringDate = x.HiringDate,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    CreateAt=x.CreateAt

            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        EmployeeDto IEmployeeService.GetById(int? id)
        {
            if (id == null)
                return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee == null)
                return null;
            //EmployeeDto employeeDto = new EmployeeDto
            //    {
            //        Id = employee.Id,
            //        Address = employee.Address,
            //        Age = employee.Age,
            //        DepartmentId = employee.DepartmentId,
            //        Name = employee.Name,
            //        Email = employee.Email,
            //        ImgUrl = employee.ImgUrl,
            //        HiringDate = employee.HiringDate,
            //        PhoneNumber = employee.PhoneNumber,
            //        Salary = employee.Salary,
            //        CreateAt =employee.CreateAt
            //    };
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);


            return employeeDto;
        }
    }
}
