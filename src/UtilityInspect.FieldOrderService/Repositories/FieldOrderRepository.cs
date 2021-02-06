using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using UtilityInspect.FieldOrderService.Data;
using UtilityInspect.FieldOrderService.Models;

namespace UtilityInspect.FieldOrderService.Repositories
{
    public class FieldOrderRepository : IFieldOrderRepository
    {
        private readonly IFieldOrderDbContext _context;

        public FieldOrderRepository(IFieldOrderDbContext context)
        {
            _context = context;
        }

        public void Create(FieldOrder fieldOrder)
        {
            _context.FieldOrders.InsertOne(fieldOrder);
        }

        public void Delete(string fieldOrderId)
        {
            _context.FieldOrders.DeleteOne(order => order.FieldOrderID == fieldOrderId);
        }

        public FieldOrder GetFieldOrderById(string fieldOrderId)
        {
            return _context.FieldOrders.Find<FieldOrder>(order => order.FieldOrderID == fieldOrderId).FirstOrDefault();
        }

        public IEnumerable<FieldOrder> GetFieldOrders()
        {
            return _context.FieldOrders.Find(order => true).ToList();
        }

        public void Update(FieldOrder fieldOrder)
        {
            _context.FieldOrders.ReplaceOne(order => order.FieldOrderID == fieldOrder.FieldOrderID, fieldOrder);
        }
    }
}