using System;
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
        public ActionResult<Employee> GetEmployeeById(Guid employeeId)
        {
            var employee = _repository.GetEmployeeById(employeeId);

            return Ok(employee);
        }

        // POST api/v1/employees
        [HttpPost]
        public ActionResult<Employee> Create([FromBody]Employee employee)
        {
            _repository.Create(employee);

            return CreatedAtAction(nameof(GetEmployeeById), new { employeeId = employee.EmployeeID }, employee);
        }

        // PUT api/v1/employees/{employeeId}
        [HttpPut("{employeeId}")]
        public ActionResult<Employee> Update([FromBody] Employee employee)
        {
            _repository.Update(employee);

            return NoContent();
        }

        // DELETE api/v1/employees/{employeeId}
        [HttpDelete("{employeeId}")]
        public ActionResult Delete(Guid employeeId)
        {
            _repository.Delete(employeeId);

            return NoContent();
        }
    }
}