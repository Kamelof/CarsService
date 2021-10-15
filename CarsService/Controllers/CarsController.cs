using CarsBuisnessLayer;
using CarsBuisnessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarsPresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var items = await _carsService.GetAllCars();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(Guid id)
        {
            var item = await _carsService.GetCarById(id);

            if(item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarById(Guid id)
        {
            var item = await _carsService.DeleteCarById(id);

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CarDTO car)
        {
            var guid = await _carsService.CreateCar(car);

            if (guid != Guid.Empty)
            {
                return Ok(guid);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(Guid id, CarDTO car)
        {
            var updetedCar = await _carsService.UpdateCar(id, car);

            if (updetedCar != null)
            {
                return Ok(updetedCar);
            }

            return BadRequest();
        }
    }
}