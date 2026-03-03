using MongoDB.Driver;
using JanRoosAutoVerhuurAPI.Models;
using Microsoft.Extensions.Options;
using JanRoosAutoVerhuurAPI.Settings;

namespace JanRoosAutoVerhuurAPI.Services
{
    public class CarRepository
    {
        private readonly IMongoCollection<Car> _cars;

        public CarRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _cars = database.GetCollection<Car>(settings.Value.CarsCollection);
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await _cars.Find(_ => true).ToListAsync();
        }
    }
}
