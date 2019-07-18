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
    }
}