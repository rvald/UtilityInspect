using System.Collections.Generic;
using UtilityInspect.FieldOrderService.Models;

namespace UtilityInspect.FieldOrderService.Repositories
{
    public interface IFieldOrderRepository
    {
        IEnumerable<FieldOrder> GetFieldOrders();
        FieldOrder GetFieldOrderByID(string fieldOrderId);
        void Create(FieldOrder fieldOrder);
        void Update(FieldOrder fieldOrder);
        void Delete(string fieldOrderId);

    }
}