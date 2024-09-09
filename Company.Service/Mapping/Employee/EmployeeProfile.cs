using AutoMapper;
using Company.Service.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Mapping.Department
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Data.Models.Employee, EmployeeDto>().ReverseMap();

        }
    }
}
