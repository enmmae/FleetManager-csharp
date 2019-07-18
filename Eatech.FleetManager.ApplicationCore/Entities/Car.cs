using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Eatech.FleetManager.ApplicationCore.Entities
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("make")]
        public string Make { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("registration")]
        public string Registration { get; set; }

        [BsonElement("year")]
        public int ModelYear { get; set; }

        [BsonElement("inspectiondate")]
        public string InspectionDate { get; set; }

        [BsonElement("enginesize")]
        public int EngineSize { get; set; }

        [BsonElement("enginepower")]
        public int EnginePower { get; set; }
    }
}