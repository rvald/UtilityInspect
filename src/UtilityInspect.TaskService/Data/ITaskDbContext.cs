using MongoDB.Driver;
using UtilityInspect.TaskService.Models;

namespace UtilityInspect.TaskService.Data
{
    public interface ITaskDbContext
    {
        IMongoCollection<FieldOrderTask> Tasks { get; }
    }
}