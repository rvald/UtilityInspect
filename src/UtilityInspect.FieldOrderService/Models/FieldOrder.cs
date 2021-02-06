using System;
using System.ComponentModel.DataAnnotations;

namespace UtilityInspect.FieldOrderService.Models
{
    public class FieldOrder
    {
        public string FieldOrderID { get; set; }

        [Required]
        public string EmployeeID { get; set; }

        [Required]
        public string CreatedDate { get; set; }

        [Required]
        public string Notes { get; set; }
    }
}