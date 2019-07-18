using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using MongoDB.Driver;

namespace Eatech.FleetManager.ApplicationCore.Services
{
    public class CarService : ICarService
    {
        private readonly IMongoCollection<Car> _cars;

        public CarService(IFleetManagerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cars = database.GetCollection<Car>(settings.CarsCollectionName);
        }

        public async Task<Car> Get(string registration)
        {
            return await _cars.Find<Car>(car => car.Registration == registration).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _cars.Find(car => true).ToListAsync();
        }
    }
}