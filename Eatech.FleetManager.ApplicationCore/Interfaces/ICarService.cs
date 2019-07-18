using System.Collections.Generic;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;

namespace Eatech.FleetManager.ApplicationCore.Interfaces
{
    public interface ICarService
    {
        Task<Car> Create(Car car);

        Task Update(string registration, Car carIn);

        Task Remove(string registration);

        Task<Car> Get(string registration);

        Task<IEnumerable<Car>> GetAll();

        Task<IEnumerable<Car>> GetAllByYear(int minyear, int maxyear);

        Task<IEnumerable<Car>> GetAllByMake(string make);

        Task<IEnumerable<Car>> GetAllByModel(string model);
    }
}