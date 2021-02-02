using System;
using Microsoft.AspNetCore.Mvc;
using UtilityInspect.EmployeeService.Models;
using UtilityInspect.EmployeeService.Repositories;

namespace UtilityInspect.EmployeeService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController: ControllerBase
    {

        private readonly IEmployeeRepository _repository;

        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        // GET api/v1/employess/{employeeId}
        [HttpGet("{employeeId}")]
        public ActionResult<Employee> GetEmployeeById(Guid employeeId)
        {
            var employee = _repository.GetEmployeeById(employeeId);
            return Ok(employee);
        }

        // POST api/v1/employees
        [HttpPost]
        public ActionResult<Employee> Create([FromBody]Employee employee)
        {
            Employee e = new Employee();
            e.FirstName = employee.FirstName;
            e.LastName = employee.LastName;
            e.Role = employee.Role;

            return CreatedAtAction(nameof(GetEmployeeById), new { employeeId = e.EmployeeID }, employee);
        }

        // PUT api/v1/employees/{employeeId}
        [HttpPut("{employeeId}")]
        public ActionResult<Employee> Update([FromBody] Employee employee)
        {
            Employee e = new Employee();
            e.FirstName = employee.FirstName;
            e.LastName = employee.LastName;
            e.Role = employee.Role;

            return NoContent();
        }

    }
}