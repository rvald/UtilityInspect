using System;
using System.Collections.Generic;
using System.Linq;
using UtilityInspect.EmployeeService.Data;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private List <Employee> _employees;
        private EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
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
                EmployeeID = new Guid("6bb8a868-dba1-4f1a-93b7-24ebce87e243"),
                FirstName = "Pepe",
                LastName = "Pepito",
                Role = "Field Tech"
            };

            var employee2 = new Employee
            {
                EmployeeID = new Guid("b94afb54-a1cb-4313-8af3-b7511551b33b"),
                FirstName = "Jose",
                LastName = "Joseito",
                Role = "Engineer"
            };

            var employee3 = new Employee
            {
                EmployeeID = new Guid("ecfa6f80-3671-4911-aabe-63cc442c1ecf"),
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