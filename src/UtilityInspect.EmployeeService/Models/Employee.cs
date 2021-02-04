using System;
using System.ComponentModel.DataAnnotations;

namespace UtilityInspect.EmployeeService.Models
{
    public class Employee
    {

        public Guid EmployeeID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }

    }
}