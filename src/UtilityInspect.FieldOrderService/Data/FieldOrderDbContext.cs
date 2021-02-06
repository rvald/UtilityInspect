using MongoDB.Driver;
using UtilityInspect.FieldOrderService.Models;

namespace UtilityInspect.FieldOrderService.Data
{
    public class FieldOrderDbContext : IFieldOrderDbContext
    {
        public IMongoCollection<FieldOrder> FieldOrders { get; }

        public FieldOrderDbContext(IFieldOrderDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            FieldOrders = database.GetCollection<FieldOrder>(settings.FieldOrderCollectionName);
            
        }
    }
}