﻿using Company.Data.Context;
using Company.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;
        public UnitOfWork( CompanyDbContext context)
        {
            _context = context;
            DepartmentRepository = new DepartmentRepository(context);
           EmployeeRepository = new EmployeeRepository(context);
        }
        public IEmployeeRepository EmployeeRepository { get ; set ; }
        public IDepartmentRepository DepartmentRepository { get ; set; }


        public int Complete()
        => _context.SaveChanges();
    }
}
