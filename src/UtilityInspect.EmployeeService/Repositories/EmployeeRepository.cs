using System;
using System.Collections.Generic;
using System.Linq;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private List <Employee> _employees;

        public void Create(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Delete(Guid id)
        {
            _employees.Remove(this.GetEmployeeById(id));
        }

        public Employee GetEmployeeById(Guid id)
        {
            return _employees.FirstOrDefault(e => e.EmployeeID == id);
        }

        public void Update(Employee employee)
        {
            var e = this.GetEmployeeById(employee.EmployeeID);
            var index = _employees.IndexOf(e);
            _employees.RemoveAt(index);
            _employees.Insert(index, employee);
        }
    }
}