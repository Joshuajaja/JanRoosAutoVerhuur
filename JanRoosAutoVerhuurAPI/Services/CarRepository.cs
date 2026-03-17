using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using JanRoosAutoVerhuurAPI.Models;
using Microsoft.Extensions.Options;
using JanRoosAutoVerhuurAPI.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace JanRoosAutoVerhuurAPI.Services
{
    public class CarRepository
    {
        private readonly IMongoCollection<CarDto>? _cars;
        private List<CarDto> _backupCars = new();
        private readonly bool _useBackup;
        private readonly ILogger<CarRepository> _logger;

        public CarRepository(IOptions<MongoSettings> settings, IWebHostEnvironment env, ILogger<CarRepository> logger)
        {
            _logger = logger;

            try
            {
                var mongoSettings = MongoClientSettings.FromConnectionString(settings.Value.ConnectionString);
                // short timeout so start-up doesn't hang when Mongo isn't available
                mongoSettings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);

                var client = new MongoClient(mongoSettings);
                var database = client.GetDatabase(settings.Value.DatabaseName);

                // quick ping to confirm connectivity (will throw if unreachable)
                database.RunCommandAsync<BsonDocument>(new BsonDocument("ping", 1))
                        .GetAwaiter()
                        .GetResult();

                _cars = database.GetCollection<CarDto>(settings.Value.CarsCollection);
                _useBackup = false;
                _logger.LogInformation("Connected to MongoDB; using MongoDB collection for cars.");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Unable to connect to MongoDB; falling back to local JSON backup.");
                _useBackup = true;

                var path = Path.Combine(env.ContentRootPath, "backup_cars.json");
                if (File.Exists(path))
                {
                    try
                    {
                        var json = File.ReadAllText(path);
                        // Deserialize to a simple POCO to avoid ObjectId deserialization issues,
                        // then map to CarDto (generate new ObjectId for local items).
                        var backupItems = JsonSerializer.Deserialize<List<BackupCar>>(json, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }) ?? new List<BackupCar>();

                        var mapped = new List<CarDto>(backupItems.Count);
                        foreach (var b in backupItems)
                        {
                            mapped.Add(new CarDto
                            {
                                Id = ObjectId.GenerateNewId(),
                                Brand = b.Brand,
                                Model = b.Model,
                                Type = b.Type,
                                Age = b.Age,
                                Seats = b.Seats,
                                Towbar = b.Towbar,
                                Color = b.Color,
                                WinterTires = b.WinterTires,
                                RoofboxOption = b.RoofboxOption,
                                Class = b.Class
                            });
                        }

                        _backupCars = mapped;
                        _logger.LogInformation("Loaded {Count} cars from local backup file.", _backupCars.Count);
                    }
                    catch (Exception readEx)
                    {
                        _logger.LogError(readEx, "Failed to read/parse backup file at {Path}. The backup list will be empty.", path);
                        _backupCars = new List<CarDto>();
                    }
                }
                else
                {
                    _logger.LogWarning("Backup file not found at {Path}. The backup list will be empty.", path);
                    _backupCars = new List<CarDto>();
                }
            }
        }

        public async Task<List<CarDto>> GetAllAsync()
        {
            if (_useBackup)
            {
                // return a copy to avoid callers mutating repository state
                return await Task.FromResult(new List<CarDto>(_backupCars));
            }

            return await _cars!.Find(_ => true).ToListAsync();
        }

        private class BackupCar
        {
            public string Brand { get; set; } = string.Empty;
            public string Model { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
            public int Age { get; set; }
            public int Seats { get; set; }
            public bool Towbar { get; set; }
            public string Color { get; set; } = string.Empty;
            public bool WinterTires { get; set; }
            public bool RoofboxOption { get; set; }
            public string Class { get; set; } = string.Empty;
        }
    }
}
