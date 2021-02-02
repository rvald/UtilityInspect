using System;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(Guid id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(Guid id);
    }
}