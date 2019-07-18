
namespace Eatech.FleetManager.ApplicationCore.Entities
{
    public class FleetManagerDatabaseSettings : IFleetManagerDatabaseSettings
    {
        public string CarsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IFleetManagerDatabaseSettings
    {
        string CarsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
