namespace UtilityInspect.FieldOrderService.Data
{
    public class FieldOrderDatabaseSettings : IFieldOrderDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string FieldOrdersCollectionName { get; set; }
        public string DatabaseName { get; set; }
    }
}