using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eatech.FleetManager.Web.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        /// <summary>
        ///     Creates a new car to the fleet.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Car car)
        {
            var carToAdd = await _carService.Get(car.Registration);

            if (carToAdd != null)
            {
                return BadRequest();
            }

            await _carService.Create(car);
            return CreatedAtAction(nameof(Get), new { registration = car.Registration }, car);
        }

        /// <summary>
        ///     Updates a car with given registration.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Car carIn)
        {
            var car = await _carService.Get(carIn.Registration);

            if (car == null)
            {
                return NotFound();
            }

            await _carService.Update(carIn.Registration, carIn);
            return NoContent();
        }

        /// <summary>
        ///     Deletes a car with given registration from the fleet.
        /// </summary>
        [HttpDelete("{registration}")]
        public async Task<IActionResult> Delete(string registration)
        {
            var car = await _carService.Get(registration);

            if (car == null)
            {
                return NotFound();
            }

            await _carService.Remove(car.Registration);
            return NoContent();
        }

        /// <summary>
        ///     Gets a car with given registration from the fleet.
        /// </summary>
        [HttpGet("{registration}")]
        public async Task<IActionResult> Get(string registration)
        {
            var car = await _carService.Get(registration);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(new CarDto(car));
        }

        /// <summary>
        ///     Gets all cars of the fleet.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<CarDto>> Get()
        {
            return (await _carService.GetAll()).Select(c => new CarDto(c));
        }

        /// <summary>
        ///     Gets cars from the fleet with model year between given years.
        /// </summary>
        [HttpGet]
        [Route("byModelYear/{minyear}/{maxyear}")]
        public async Task<IEnumerable<CarDto>> GetCarsByModelYear(int minyear, int maxyear)
        {
            return (await _carService.GetAllByYear(minyear, maxyear)).Select(c => new CarDto(c));
        }

        /// <summary>
        ///     Gets cars from the fleet with certain make.
        /// </summary>
        [HttpGet]
        [Route("byMake/{make}")]
        public async Task<IEnumerable<CarDto>> GetCarsByMake(string make)
        {
            return (await _carService.GetAllByMake(make)).Select(c => new CarDto(c));
        }

        /// <summary>
        ///     Gets cars from the fleet with certain model.
        /// </summary>
        [HttpGet]
        [Route("byModel/{model}")]
        public async Task<IEnumerable<CarDto>> GetCarsByModel(string model)
        {
            return (await _carService.GetAllByModel(model)).Select(c => new CarDto(c));
        }
    }
}