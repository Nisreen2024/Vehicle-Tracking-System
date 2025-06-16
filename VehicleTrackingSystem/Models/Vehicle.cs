
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VehicleTrackingSystem.Models
{
    public class Vehicle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("plateNumber")]
        public string PlateNumber { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("driverName")]
        public string DriverName { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }
    }
}