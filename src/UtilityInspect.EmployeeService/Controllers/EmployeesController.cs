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

    }
}