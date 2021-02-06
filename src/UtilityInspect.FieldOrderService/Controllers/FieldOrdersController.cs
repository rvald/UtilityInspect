using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UtilityInspect.FieldOrderService.Models;
using UtilityInspect.FieldOrderService.Repositories;

namespace UtilityInspect.FieldOrderService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FieldOrdersController: ControllerBase
    {
        private readonly IFieldOrderRepository _fieldOderRepository;

        public FieldOrdersController(IFieldOrderRepository fieldOrderRepository)
        {
            _fieldOderRepository = fieldOrderRepository;
        }

        // POST api/v1/fieldOrders
        [HttpPost]
        public ActionResult<FieldOrder> Create([FromBody] FieldOrder fieldOrder)
        {
            if (fieldOrder == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _fieldOderRepository.Create(fieldOrder);

            return CreatedAtAction(nameof(GetFieldOrderById), new { fieldOrderId = fieldOrder.FieldOrderID }, fieldOrder);
        }

        // GET api/v1/fieldOrders/{fieldOrderId}
        [HttpGet("{fieldOrderId}")]
        public ActionResult<FieldOrder> GetFieldOrderById(string fieldOrderId)
        {
            var order = _fieldOderRepository.GetFieldOrderById(fieldOrderId);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // GET api/v1/fieldOrders
        [HttpGet]
        public ActionResult<IEnumerable<FieldOrder>> GetFieldOrders()
        {
            return Ok(_fieldOderRepository.GetFieldOrders());
        }

        // PUT api/v1/fieldOrders
        [HttpPut]
        public ActionResult Update([FromBody] FieldOrder fieldOrder)
        {
            var e = GetFieldOrderById(fieldOrder.FieldOrderID);

            if (e == null)
            {
                return BadRequest();
            }

            _fieldOderRepository.Update(fieldOrder);

            return NoContent();
        }

        // DELETE api/v1/fieldOrders/{fieldOrderId}
        [HttpDelete("{fieldOrderId}")]
        public ActionResult Delete(string fieldOrderId)
        {
            var order = GetFieldOrderById(fieldOrderId);

            if (order == null)
            {
                return NotFound();
            }

            _fieldOderRepository.Delete(fieldOrderId);

            return NoContent();
        }

    }
}