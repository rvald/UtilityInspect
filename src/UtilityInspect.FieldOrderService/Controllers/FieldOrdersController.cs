using Microsoft.AspNetCore.Mvc;
using UtilityInspect.FieldOrderService.Models;
using UtilityInspect.FieldOrderService.Repositories;

namespace UtilityInspect.FieldOrderService.Controllers
{
    [ApiController]
    [Route("api/v1/fieldOrders")]
    public class FieldOrdersController: ControllerBase
    {

        private readonly IFieldOrderRepository _fieldOderRepository;

        public FieldOrdersController(IFieldOrderRepository fieldOrderRepository)
        {
            _fieldOderRepository = fieldOrderRepository;
        }

        // POST api/v1/fieldOrders
        [HttpPost]
        public ActionResult Create(FieldOrder fieldOrder)
        {
            if (fieldOrder == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetFieldOrderById), new { fieldOrderId = fieldOrder.FieldOrderID }, fieldOrder);
        }

        // GET api/v1/fieldOrders/{fieldOrderId}
        [HttpGet("{fieldOrderId}")]
        public ActionResult<FieldOrder> GetFieldOrderById(string fieldOrderId)
        {
            if (fieldOrderId == null)
            {
                return BadRequest();
            }

            return Ok(_fieldOderRepository.GetFieldOrderById(fieldOrderId));
        }

    }
}