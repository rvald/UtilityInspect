using MongoDB.Driver;
using UtilityInspect.TaskService.Models;

namespace UtilityInspect.TaskService.Data
{
    public class TaskDbContext : ITaskDbContext
    {
        public IMongoCollection<FieldOrderTask> Tasks { get; }

        public TaskDbContext(ITaskDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Tasks = database.GetCollection<FieldOrderTask>(settings.TasksCollectionName);
        }
    }
}