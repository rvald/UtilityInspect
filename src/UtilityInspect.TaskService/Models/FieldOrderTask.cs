using System;
using System.ComponentModel.DataAnnotations;

namespace UtilityInspect.TaskService.Models
{
    public class FieldOrderTask
    {
        public Guid FieldOrderTaskID { get; set; }

        [Required]
        public string FieldOrderID { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Progress { get; set; }
    }
}