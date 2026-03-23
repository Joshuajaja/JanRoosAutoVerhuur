using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JanRoosAutoVerhuur.Models;
using JanRoosAutoVerhuur.Services;
using MongoDB.Bson.Serialization.Serializers;

namespace JanRoosAutoVerhuur.Viewmodel
{
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

        public ObservableCollection<Car> Cars { get; set; } = [];

        public ObservableCollection<string> Brands { get; set; } = [];
        public ObservableCollection<string> Class { get; set; } = [];
        public ObservableCollection<int> Seats { get; set; } = [];
        public ObservableCollection<int> Age { get; set; } = [];
        public ObservableCollection<string> Color { get; set; } = [];
        public ObservableCollection<string> Type { get; set; } = [];

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
            {
                Cars.Add(car); // yes i know its alot of if functions but it works :3
                if (!Brands.Contains(car.Brand))
                {
                    Brands.Add(car.Brand);
                }
                if (!Seats.Contains(car.Seats))
                {
                    Seats.Add(car.Seats);
                }
                if (!Type.Contains(car.Type))
                {
                    Type.Add(car.Type);
                }
                if (!Age.Contains(car.Age))
                {
                    Age.Add(car.Age);
                }
                if (!Color.Contains(car.Color))
                {
                    Color.Add(car.Color);
                }
                if (!Class.Contains(car.Class))
                {
                    Class.Add(car.Class);
                }
            }
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