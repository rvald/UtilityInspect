using System;

namespace UtilityInspect.EmployeeService.Models
{
    public class Employee
    {

        public Guid EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

    }
}