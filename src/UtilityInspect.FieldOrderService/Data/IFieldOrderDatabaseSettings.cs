namespace UtilityInspect.FieldOrderService.Data
{
    public interface IFieldOrderDatabaseSettings
    {
        string ConnectionString { get; set; }
        string FieldOrderCollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}