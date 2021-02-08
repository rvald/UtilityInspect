namespace UtilityInspect.TaskService.Models
{
    public class Task
    {
        public Guid TaskID { get; set; }
        public string FieldOrderID { get; set; }
        public string Description { get; set; }
        public string Progress { get; set; }
    }
}