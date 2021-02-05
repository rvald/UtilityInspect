using MongoDB.Driver;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Data
{
    public class EmployeeDbContext : IEmployeeDbContext
    {
        public IMongoCollection<Employee> Employees { get; }

        public EmployeeDbContext(IEmployeeDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Employees = database.GetCollection<Employee>(settings.EmployeeCollectionName);
            
        }
    }
}