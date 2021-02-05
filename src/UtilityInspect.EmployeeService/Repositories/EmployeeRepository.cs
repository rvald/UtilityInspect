using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using UtilityInspect.EmployeeService.Data;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IEmployeeDbContext _context;

        public EmployeeRepository(IEmployeeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Find(Employee => true).ToList();
        }

        public void Create(Employee employee)
        {
            _context.Employees.InsertOne(employee);
        }

        public void Delete(string id)
        {
            _context.Employees.DeleteOne(e => e.EmployeeID == id);
        }

        public Employee GetEmployeeById(string id)
        {
            return _context.Employees.Find<Employee>(e => e.EmployeeID == id).FirstOrDefault();
        }

        public void Update(Employee employee)
        {
            _context.Employees.ReplaceOne(e => e.EmployeeID == employee.EmployeeID, employee);
        }
    }
}