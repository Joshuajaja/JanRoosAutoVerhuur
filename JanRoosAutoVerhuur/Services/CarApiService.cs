using JanRoosAutoVerhuur.Models;
using System.Net.Http.Json;

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
    public async Task<List<_Accounts>> GetAccountsAsync()
    {
    var accounts = await _http.GetFromJsonAsync<List<_Accounts>>("api/Accounts");
        return accounts;
    }
    public async Task<_Accounts> CreateAccountAsync(_Accounts account)
    {
        var response = await _http.PostAsJsonAsync("api/Accounts", account);
        response.EnsureSuccessStatusCode(); // throws exception if failed
        return await response.Content.ReadFromJsonAsync<_Accounts>();
    }

}
