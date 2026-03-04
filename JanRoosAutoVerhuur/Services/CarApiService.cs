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
    public async Task<_Accounts> GetUserByUsernameAsync<T>(string Username)
    {
        var response = await _http.GetAsync($"api/Accounts/by-user/{Username}");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
        var account = await _http.GetFromJsonAsync<_Accounts>($"api/Accounts/by-user/{Username}");
        return account;
    }
    public async Task<bool> GetCheckIfUserExistsByUsername(string Username)
    {
        var response = await _http.GetAsync($"api/Accounts/by-user/{Username}");
        if (response.IsSuccessStatusCode) // check 1.
        {
            return true;
        }    
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound) // check 2.
        {
            return false;
        }
        response.EnsureSuccessStatusCode(); // check 3. throws exception if failed

        return false; // failsafe, shouldnt reach here but still
    }
}
