using System;
using Microsoft.AspNetCore.Mvc;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController: ControllerBase
    {

        // GET api/v1/employess/{employeeId}
        [HttpGet("{employeeId}")]
        public ActionResult<Employee> GetEmployeeById(Guid employeeId)
        {
            var employee = new Employee { FirstName="FirstName", LastName="LastName", Role="Field Tech" };
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

    }
}