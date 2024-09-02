using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interface
{
    internal interface IGenericRepository<T> where T :BaseEntity
    {
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
