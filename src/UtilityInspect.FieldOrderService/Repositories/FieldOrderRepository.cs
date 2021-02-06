using System.Collections.Generic;
using System.Linq;
using UtilityInspect.FieldOrderService.Models;

namespace UtilityInspect.FieldOrderService.Repositories
{
    public class FieldOrderRepository : IFieldOrderRepository
    {

        private readonly List<FieldOrder> fieldOrders;

        public FieldOrderRepository()
        {
            fieldOrders = new List<FieldOrder>();
        }

        public void Create(FieldOrder fieldOrder)
        {
            fieldOrders.Add(fieldOrder);
        }

        public void Delete(string fieldOrderId)
        {
            var order = GetFieldOrderByID(fieldOrderId);
            fieldOrders.Remove(order);
        }

        public FieldOrder GetFieldOrderByID(string fieldOrderId)
        {
            return fieldOrders.FirstOrDefault(e => e.FieldOrderID == fieldOrderId);
        }

        public IEnumerable<FieldOrder> GetFieldOrders()
        {
            return fieldOrders.ToList();
        }

        public void Update(FieldOrder fieldOrder)
        {
            var order = GetFieldOrderByID(fieldOrder.FieldOrderID);
            var index = fieldOrders.IndexOf(order);
            fieldOrders.RemoveAt(index);
            fieldOrders.Add(fieldOrder);
        }
    }
}