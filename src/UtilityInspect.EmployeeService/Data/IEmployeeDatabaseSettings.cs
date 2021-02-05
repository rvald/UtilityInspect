namespace UtilityInspect.EmployeeService.Data
{
    public interface IEmployeeDatabaseSettings
    {
        string EmployeeCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}