using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using UtilityInspect.TaskService.Data;
using UtilityInspect.TaskService.Models;

namespace UtilityInspect.TaskService.Repositories
{
    public class FieldOrderTaskRepository : IFieldOrderTaskRepository
    {

        private readonly ITaskDbContext _context;

        public FieldOrderTaskRepository(ITaskDbContext context)
        {
            _context = context;
        }
        public void Create(FieldOrderTask fieldOrderTask)
        {
            _context.Tasks.InsertOne(fieldOrderTask);
        }

        public void Delete(string fieldOrderTaskId)
        {
           _context.Tasks.DeleteOne(task => task.FieldOrderTaskID == fieldOrderTaskId);
        }

        public IEnumerable<FieldOrderTask> GetAllFieldOrderTasks()
        {
            return _context.Tasks.Find(task => true).ToList();
        }

        public FieldOrderTask GetFieldOrderTaskById(string fieldOrderTaskId)
        {
            return _context.Tasks.Find<FieldOrderTask>(task => task.FieldOrderTaskID == fieldOrderTaskId).FirstOrDefault();
        }

        public IEnumerable<FieldOrderTask> GetTasksByFieldOrderId(string fieldOrderId)
        {
            return _context.Tasks.Find<FieldOrderTask>(task => task.FieldOrderID == fieldOrderId).ToList();
        }

        public void Update(FieldOrderTask fieldOrderTask)
        {
            _context.Tasks.ReplaceOne(task => task.FieldOrderTaskID == fieldOrderTask.FieldOrderTaskID, fieldOrderTask);
        }
    }
}