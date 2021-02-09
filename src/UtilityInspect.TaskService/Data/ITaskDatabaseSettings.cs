namespace UtilityInspect.TaskService.Data
{
    public interface ITaskDatabaseSettings
    {
        string TasksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}