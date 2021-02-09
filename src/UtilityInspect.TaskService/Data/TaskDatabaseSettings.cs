namespace UtilityInspect.TaskService.Data
{
    public class TaskDatabaseSettings : ITaskDatabaseSettings
    {
        public string TasksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}