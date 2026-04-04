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

        private List<Car> AllCars = new();


        [ObservableProperty] private string? selectedBrand;
        [ObservableProperty] private string? selectedType;
        [ObservableProperty] private int? selectedSeat;
        [ObservableProperty] private int? selectedAge;
        [ObservableProperty] private string? selectedColor;
        [ObservableProperty] private string? selectedClass;

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
            AllCars = await _carService.GetCarsAsync();
            Cars.Clear();
            foreach (var car in AllCars)
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
        void ClearFilters()
        {
            SelectedAge = null;
            SelectedBrand = null;
            SelectedClass = null;
            SelectedSeat = null;
            SelectedType = null;
            SelectedColor = null;
            Cars.Clear();
            foreach (var car in AllCars)
            {
                Cars.Add(car);
            }
        }
        void FilterCars()
        { 
            var carsFilter = AllCars.Where(car =>
                (string.IsNullOrEmpty(SelectedBrand) || car.Brand == SelectedBrand) &&
                (string.IsNullOrEmpty(SelectedType) || car.Type == SelectedType) &&
                (SelectedSeat == null || car.Seats == SelectedSeat) &&
                (SelectedAge == null || car.Age == SelectedAge) &&
                (string.IsNullOrEmpty(SelectedColor) || car.Color == SelectedColor) &&
                (string.IsNullOrEmpty(SelectedClass) || car.Class == SelectedClass)
            ).ToList();

            Cars.Clear();
            foreach (var car in carsFilter)
            {
                Cars.Add(car);
            }
        }

        partial void OnSelectedBrandChanged(string oldValue, string newValue) => FilterCars();
        partial void OnSelectedTypeChanged(string oldValue, string newValue) => FilterCars();
        partial void OnSelectedSeatChanged(int? oldValue, int? newValue) => FilterCars();
        partial void OnSelectedAgeChanged(int? oldValue, int? newValue) => FilterCars();
        partial void OnSelectedColorChanged(string oldValue, string newValue) => FilterCars();
        partial void OnSelectedClassChanged(string oldValue, string newValue) => FilterCars();

        [RelayCommand]
        private async Task CarTapped(Car car)
        {
            if (car == null)
  
                return;

            await Shell.Current.GoToAsync($"CarDetailPage?carId={car.Id}");
        }
    }
}