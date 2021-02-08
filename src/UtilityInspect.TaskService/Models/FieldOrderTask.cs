using System;

namespace UtilityInspect.TaskService.Models
{
    public class FieldOrderTask
    {
        public Guid FieldOrderTaskID { get; set; }
        public string FieldOrderID { get; set; }
        public string Description { get; set; }
        public string Progress { get; set; }
    }
}