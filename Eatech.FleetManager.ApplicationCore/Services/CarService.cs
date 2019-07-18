using System.Collections.Generic;
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

        public async Task<Car> Create(Car car)
        {
            await _cars.InsertOneAsync(car);
            return car;
        }

        public async Task Update(string registration, Car carIn)
        {
            await _cars.ReplaceOneAsync(car => car.Registration == registration, carIn);
        }

        public async Task Remove(string registration)
        {
            await _cars.DeleteOneAsync(car => car.Registration == registration);
        }

        public async Task<Car> Get(string registration)
        {
            return await _cars.Find<Car>(car => car.Registration == registration).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _cars.Find(car => true).ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetAllByYear(int minyear, int maxyear)
        {
            return await _cars.Find(car => (minyear <= car.ModelYear && car.ModelYear <= maxyear)).ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetAllByMake(string make)
        {
            return await _cars.Find(car => car.Make == make).ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetAllByModel(string model)
        {
            return await _cars.Find(car => car.Model == model).ToListAsync();
        }
    }
}