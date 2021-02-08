using System;
using System.Collections.Generic;
using System.Linq;
using UtilityInspect.TaskService.Models;

namespace UtilityInspect.TaskService.Repositories
{
    public class FieldOrderTaskRepository : IFieldOrderTaskRepository
    {

        private readonly List<FieldOrderTask> fieldOrderTasks;

        public FieldOrderTaskRepository()
        {
            fieldOrderTasks = new List<FieldOrderTask>();
        }
        public void Create(FieldOrderTask fieldOrderTask)
        {
            fieldOrderTasks.Add(fieldOrderTask);
        }

        public void Delete(Guid fieldOrderTaskId)
        {
           var f = GetFieldOrderTaskById(fieldOrderTaskId);
           fieldOrderTasks.Remove(f);
        }

        public IEnumerable<FieldOrderTask> GetAllFieldOrderTasks()
        {
            return fieldOrderTasks.ToList();
        }

        public FieldOrderTask GetFieldOrderTaskById(Guid fieldOrderTaskId)
        {
            return fieldOrderTasks.FirstOrDefault( e => e.FieldOrderTaskID == fieldOrderTaskId);
        }

        public IEnumerable<FieldOrderTask> GetTasksByFieldOrderId(string fieldOrderId)
        {
            return fieldOrderTasks.FindAll(e => e.FieldOrderID == fieldOrderId);
        }

        public void Update(FieldOrderTask fieldOrderTask)
        {
            var f = GetFieldOrderTaskById(fieldOrderTask.FieldOrderTaskID);
            var index = fieldOrderTasks.IndexOf(f);
            fieldOrderTasks.RemoveAt(index);
            fieldOrderTasks.Insert(index, fieldOrderTask);
        }
    }
}