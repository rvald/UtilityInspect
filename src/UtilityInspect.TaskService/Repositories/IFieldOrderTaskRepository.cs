using System;
using System.Collections.Generic;
using UtilityInspect.TaskService.Models;

namespace UtilityInspect.TaskService.Repositories
{
    public interface IFieldOrderTaskRepository
    {
       IEnumerable<FieldOrderTask> GetTasksByFieldOrderId(string fieldOrderId);
       IEnumerable<FieldOrderTask> GetAllFieldOrderTasks();
       void Create(FieldOrderTask fieldOrderTask);
       FieldOrderTask GetFieldOrderTaskById(Guid fieldOrderTaskId);
       void Update(FieldOrderTask fieldOrderTask);
       void Delete(Guid fieldOrderTaskId);

    }
}