using MongoDB.Driver;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Data
{
    public interface IEmployeeDbContext
    {
        IMongoCollection<Employee> Employees { get; }
    }
}