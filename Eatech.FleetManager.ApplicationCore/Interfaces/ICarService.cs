using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;

namespace Eatech.FleetManager.ApplicationCore.Interfaces
{
    public interface ICarService
    {
        Task<Car> Get(string registration);

        Task<IEnumerable<Car>> GetAll();
    }
}