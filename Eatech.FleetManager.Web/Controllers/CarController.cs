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
        /// <param name="car"></param>
        /// <response code="201">Returns the newly created car</response>
        /// <response code="400">If there is already a car with given registration in the database</response>
        /// <response code="500">If the car is null</response>  
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
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
        /// <param name="carIn"></param>
        /// <response code="204">Returns no content on success</response>
        /// <response code="404">If there is no car with given registration in the database</response>
        /// <response code="500">If the car is null</response>  
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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
        /// <param name="registration"></param>
        /// <response code="204">Returns no content on success</response>
        /// <response code="404">If registration is null or there is no car with given registration in the database</response>  
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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
        /// <param name="registration"></param>
        /// <response code="200">Returns a car with given registration</response>
        /// <response code="404">If car not found</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
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
        /// <response code="200">Returns all cars of the fleet</response>
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<IEnumerable<CarDto>> Get()
        {
            return (await _carService.GetAll()).Select(c => new CarDto(c));
        }

        /// <summary>
        ///     Gets cars from the fleet with model year between given years.
        /// </summary>
        /// <param name="minyear"></param>
        /// <param name="maxyear"></param>
        /// <response code="200">Returns cars with modelyear between given years</response>
        /// <response code="404">If minyear or maxyear is null</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("byModelYear/{minyear}/{maxyear}")]
        public async Task<IEnumerable<CarDto>> GetCarsByModelYear(int minyear, int maxyear)
        {
            return (await _carService.GetAllByYear(minyear, maxyear)).Select(c => new CarDto(c));
        }

        /// <summary>
        ///     Gets cars from the fleet with certain make.
        /// </summary>
        /// <param name="make"></param>
        /// <response code="200">Returns cars of certain make</response>
        /// <response code="404">If make is null</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("byMake/{make}")]
        public async Task<IEnumerable<CarDto>> GetCarsByMake(string make)
        {
            return (await _carService.GetAllByMake(make)).Select(c => new CarDto(c));
        }

        /// <summary>
        ///     Gets cars from the fleet with certain model.
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Returns cars of certain model</response>
        /// <response code="404">If model is null</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("byModel/{model}")]
        public async Task<IEnumerable<CarDto>> GetCarsByModel(string model)
        {
            return (await _carService.GetAllByModel(model)).Select(c => new CarDto(c));
        }
    }
}