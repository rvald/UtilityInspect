using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UtilityInspect.TaskService.Models;
using UtilityInspect.TaskService.Repositories;

namespace UtilityInspect.TaskService.Controllers
{
    [ApiController]
    [Route("api/v1/tasks/[controller]")]
    public class FieldOrderTasksController: ControllerBase
    {

        private readonly IFieldOrderTaskRepository _fieldOrderTaskRepository;

        public FieldOrderTasksController(IFieldOrderTaskRepository fieldOrderTaskRepository)
        {
            _fieldOrderTaskRepository = fieldOrderTaskRepository;
        }

        // POST api/v1/tasks
        [HttpPost]
        public ActionResult Create([FromBody] FieldOrderTask fieldOrderTask)
        {
            if (fieldOrderTask == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _fieldOrderTaskRepository.Create(fieldOrderTask);

            return CreatedAtAction(nameof(GetFieldOrderTaskById), new { fielOrderTaskId = fieldOrderTask.FieldOrderTaskID }, fieldOrderTask);
        }

        // GET api/v1/tasks/{fielOrderTaskId}
        [HttpGet("{fielOrderTaskId}")]
        public ActionResult<FieldOrderTask> GetFieldOrderTaskById(Guid fieldOrderTaskId)
        {
            var e = _fieldOrderTaskRepository.GetFieldOrderTaskById(fieldOrderTaskId);

            if (e == null)
            {
                return NotFound();
            }

            return Ok(e);
        }

        // GET api/v1/tasks/{fieldOrderId}
        [HttpGet("{fieldOrderId}")]
        public ActionResult<IEnumerable<FieldOrderTask>> GetTasksByFieldOrderId(string fieldOrderId)
        {
            var results = _fieldOrderTaskRepository.GetTasksByFieldOrderId(fieldOrderId);

            if (results == null)
            {
                return NotFound();
            }

            return Ok(results);
        }


        // PUT api/v1/tasks
        [HttpPut]
        public ActionResult Update([FromBody] FieldOrderTask fieldOrderTask)
        {
            if (fieldOrderTask == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _fieldOrderTaskRepository.Update(fieldOrderTask);

            return NoContent();
        }

        // DELETE api/v1/tasks/{fieldOrderTaskId}
        [HttpDelete("{fieldOrderTaskId}")]
        public ActionResult Delete(Guid fieldOrderTaskId)
        {
            var e = GetFieldOrderTaskById(fieldOrderTaskId);

            if (e == null)
            {
                return NotFound();
            }

            _fieldOrderTaskRepository.Delete(fieldOrderTaskId);

            return NoContent();
        }
    }
}