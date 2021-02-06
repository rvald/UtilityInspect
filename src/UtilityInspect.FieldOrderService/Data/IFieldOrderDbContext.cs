using MongoDB.Driver;
using UtilityInspect.FieldOrderService.Models;

namespace UtilityInspect.FieldOrderService.Data
{
    public interface IFieldOrderDbContext
    {
        IMongoCollection<FieldOrder> FieldOrders { get; }
    }
}