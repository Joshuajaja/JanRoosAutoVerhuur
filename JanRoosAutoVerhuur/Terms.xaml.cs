using JanRoosAutoVerhuur.Models;
using JanRoosAutoVerhuur.Services;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Devices;

namespace JanRoosAutoVerhuur;

public partial class Terms : ContentPage
{
    public ObservableCollection<Car> Cars { get; set; } = new();

    public int CardSpan { get; set; }

    private readonly CarApiService _carService = new();

    public Terms()
    {
        InitializeComponent();

        // initialize span based on current display
        UpdateSpan(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density);

        // react to display changes (resize / orientation)
        DeviceDisplay.MainDisplayInfoChanged += (_, __) =>
        {
            UpdateSpan(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density);
        };

        BindingContext = this;
    }

    private void UpdateSpan(double width)
    {
        CardSpan = width switch
        {
            < 480 => 1,   // phone portrait
            < 720 => 3,   // phone landscape
            < 1024 => 4,  // tablets
            < 1400 => 5,  // small desktop
            _ => 6        // large desktop
        };

        OnPropertyChanged(nameof(CardSpan));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var carsFromApi = await _carService.GetCarsAsync();

        Cars.Clear();
        foreach (var car in carsFromApi)
            Cars.Add(car);
    }

    private async void OnCarSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedCar = e.CurrentSelection.FirstOrDefault() as Car;

        if (selectedCar == null)
            return;

        await Navigation.PushAsync(new CarDetailPage(selectedCar));

        // clear selection so same card can be clicked again
        ((CollectionView)sender).SelectedItem = null;
    }
}
