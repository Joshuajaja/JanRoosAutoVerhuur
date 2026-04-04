using JanRoosAutoVerhuur.Models;
using JanRoosAutoVerhuur.Services;
using System.Runtime.CompilerServices;

namespace JanRoosAutoVerhuur;

[QueryProperty(nameof(CarId), "carId")]
public partial class CarDetailPage : ContentPage
{
    private readonly CarApiService _carService = new();
    public string CarId
    {
        set
        {
            LoadCarId(value);
        }
    }

    private async Task LoadCarId(string value)
    {
        var cars = await _carService.GetCarsAsync();

        var car = cars.FirstOrDefault(c => c.Id == value);

        if (car != null)
        {
            BindingContext = car;
        }
    }

    public CarDetailPage()
    {
        InitializeComponent();
    }

    private async void LoadCar(string id)
    {
        // call your API/service here
    }
}
