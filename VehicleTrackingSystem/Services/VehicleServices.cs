
using MongoDB.Driver;
using VehicleTrackingSystem.Models;
using VehicleTrackingSystem.Services;

namespace VehicleTrackingSystem.Services
{
    public class VehicleService
    {
        private readonly IMongoCollection<Vehicle> _vehicles;

        public VehicleService(MongoDbContext context)
        {
            var database = context.GetDatabase();
            _vehicles = database.GetCollection<Vehicle>("Vehicles");
        }

        public List<Vehicle> GetAll() =>
            _vehicles.Find(vehicle => true).ToList();

        public Vehicle GetById(string id) =>
            _vehicles.Find(vehicle => vehicle.Id == id).FirstOrDefault();

        public void Create(Vehicle vehicle)
        {
            _vehicles.InsertOne(vehicle);
        }

        public void Update(string id, Vehicle vehicleIn) =>
            _vehicles.ReplaceOne(vehicle => vehicle.Id == id, vehicleIn);

    

        public void Delete(string id) =>
            _vehicles.DeleteOne(vehicle => vehicle.Id == id);
    }
}



