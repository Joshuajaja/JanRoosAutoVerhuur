using System.Net.Http.Json;
using JanRoosAutoVerhuur.Models;

namespace JanRoosAutoVerhuur.Services;

public class CarApiService
{
    private readonly HttpClient _http;

    public CarApiService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("https://localhost:7278/");
    }

    public async Task<List<Car>> GetCarsAsync()
    {
        return await _http.GetFromJsonAsync<List<Car>>("api/cars");
    }
}
