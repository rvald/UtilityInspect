namespace UtilityInspect.FieldOrderService.Data
{
    public interface IFieldOrderDatabaseSettings
    {
        string ConnectionString { get; set; }
        string FieldOrdersCollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}