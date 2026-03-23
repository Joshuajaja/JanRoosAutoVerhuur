using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JanRoosAutoVerhuur.Models;
using JanRoosAutoVerhuur.Services;

namespace JanRoosAutoVerhuur.Viewmodel
{
    [QueryProperty(nameof(NameInfoText), "Username")]
    public partial class MainViewModel : ObservableObject
    {
        private readonly CarApiService _carService = new();

        public MainViewModel()
        {
            UpdateSpan(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density);

            DeviceDisplay.MainDisplayInfoChanged += (_, __) =>
            {
                UpdateSpan(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density);
            };
        }

        [ObservableProperty]
        private int name = 0;

        [ObservableProperty]
        private string nameInfoText;

        [RelayCommand]
        private void FilterSet()
        {
            Name++;
        }

        public ObservableCollection<Car> Cars { get; set; } = new();


        [ObservableProperty]
        private int cardSpan;

        private void UpdateSpan(double width)
        {
            CardSpan = width switch
            {
                < 480 => 2,
                < 720 => 3,
                < 1024 => 4,
                < 1400 => 5,
                _ => 6
            };
        }

        [RelayCommand]
        public async Task LoadCarsAsync()
        {
            var cars = await _carService.GetCarsAsync();

            Cars.Clear();
            foreach (var car in cars)
                Cars.Add(car);
        }


        [RelayCommand]
        private async Task CarTapped(Car car)
        {
            if (car == null)
                return;

            await Shell.Current.GoToAsync($"CarDetailPage?carId={car.Id}");
        }
    }
}