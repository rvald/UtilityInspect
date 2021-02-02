using System;
using System.Collections.Generic;
using System.Linq;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private List <Employee> _employees;

        public EmployeeRepository()
        {
            InitializeData();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

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


        public void InitializeData()
        {
            _employees = new List<Employee>();

            var employee1 = new Employee
            {
                EmployeeID = new Guid(),
                FirstName = "Pepe",
                LastName = "Pepito",
                Role = "Field Tech"
            };

            var employee2 = new Employee
            {
                EmployeeID = new Guid(),
                FirstName = "Jose",
                LastName = "Joseito",
                Role = "Engineer"
            };

            var employee3 = new Employee
            {
                EmployeeID = new Guid(),
                FirstName = "Juan",
                LastName = "Juanito",
                Role = "Handyman"
            };

            _employees.Add(employee1);
            _employees.Add(employee2);
            _employees.Add(employee3);
        }
    }
}