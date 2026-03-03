using Microsoft.AspNetCore.Mvc;
using JanRoosAutoVerhuurAPI.Services;

namespace JanRoosAutoVerhuurAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarRepository _repo;

        public CarsController(CarRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _repo.GetAllAsync();
            return Ok(cars);
        }
    }
}
