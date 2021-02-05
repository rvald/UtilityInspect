using System.Collections.Generic;
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

        // GET api/v1/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            var employees = _repository.GetAll();
            
            return Ok(employees);
        }

        // GET api/v1/employees/{employeeId}
        [HttpGet("{employeeId}")]
        public ActionResult<Employee> GetEmployeeById(string employeeId)
        {
            var employee = _repository.GetEmployeeById(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST api/v1/employees
        [HttpPost]
        public ActionResult<Employee> Create([FromBody]Employee employee)
        {
            if (employee == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.Create(employee);

            return CreatedAtAction(nameof(GetEmployeeById), new { employeeId = employee.EmployeeID }, employee);
        }

        // PUT api/v1/employees/{employeeId}
        [HttpPut]
        public ActionResult<Employee> Update([FromBody] Employee employee)
        {

            var e = GetEmployeeById(employee.EmployeeID);

            if (e == null)
            {
                return NotFound();
            }

            _repository.Update(employee);

            return NoContent();
        }

        // DELETE api/v1/employees/{employeeId}
        [HttpDelete("{employeeId}")]
        public ActionResult Delete(string employeeId)
        {
            var e = GetEmployeeById(employeeId);
            
            if (e == null)
            {
                return NotFound();
            }

            _repository.Delete(employeeId);

            return NoContent();
        }
    }
}