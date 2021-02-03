using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UtilityInspect.EmployeeService.Data;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public void Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Employee e = this.GetEmployeeById(id);
            _context.Remove(e);
            _context.SaveChanges();
        }

        public Employee GetEmployeeById(Guid id)
        {
            return _context.Employees.Single(e => e.EmployeeID == id);
        }

        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}