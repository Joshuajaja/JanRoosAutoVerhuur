using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using JanRoosAutoVerhuurAPI.Settings;

namespace JanRoosAutoVerhuurAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly MongoSettings _settings;

        public HealthController(IOptions<MongoSettings> settings)
        {
            _settings = settings.Value;
        }

        [HttpGet("mongo")]
        public async Task<IActionResult> TestMongo()
        {
            try
            {
                var client = new MongoClient(_settings.ConnectionString);
                var db = client.GetDatabase(_settings.DatabaseName);

                // Simple ping command aaaaaaaaaa
                await db.RunCommandAsync((Command<dynamic>)"{ping:1}");

                return Ok("MongoDB connection successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
