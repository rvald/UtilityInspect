using System;

namespace UtilityInspect.FieldOrderService.Models
{
    public class FieldOrder
    {
        public string FieldOrderID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Notes { get; set; }
    }
}