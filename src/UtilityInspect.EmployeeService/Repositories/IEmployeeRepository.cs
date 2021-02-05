using System;
using System.Collections.Generic;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetEmployeeById(string id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(string id);
    }
}