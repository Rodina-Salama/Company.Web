using Company.Data.Models;
using Company.Repository.Interface;
using Company.Repository.Repositories;
//using Company.Service.Interfaces.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Dto;
using AutoMapper;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
       // private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new DepartmentDto
            //{
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreateAt = DateTime.Now

            //};
            Data.Models.Department department = _mapper.Map<Data.Models.Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(department);
            _unitOfWork.Complete();
        }

     

        public void Delete(DepartmentDto departmentDto)
        {
            Data.Models.Department department = _mapper.Map<Data.Models.Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.Complete();
        }

     
        public IEnumerable<DepartmentDto> GetAll()
        {
            var department = _unitOfWork.DepartmentRepository.GetAll();
            //return departments;
            IEnumerable<DepartmentDto> mappedEmployees = _mapper.Map<IEnumerable<DepartmentDto>>(department);
            return mappedEmployees;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;
                var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (department is null)
                return null;
            DepartmentDto employeeDto = _mapper.Map<DepartmentDto>(department);
            return employeeDto;
          //  return department;

        }

        public void Update(DepartmentDto departmentDto)
        {
            //var dept = GetById(department.Id);
            //if(dept.Name != department.Name)
            //{
            //    if (GetAll().Any(X => X.Name == department.Name))
            //        throw new Exception("DuplicateDepartmentName");
            //}
            //dept.Name = department.Name;
            //dept.Code = department.Code;
            Data.Models.Department department = _mapper.Map<Data.Models.Department>(departmentDto);

            _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();
        }

   
     
    }
}
