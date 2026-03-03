using JanRoosAutoVerhuur.Models;
using System.Collections.ObjectModel;

namespace JanRoosAutoVerhuur;

public partial class Terms : ContentPage
{
    public ObservableCollection<Car> Cars { get; set; }
    public int CardSpan { get; set; }

    public Terms()
    {
        InitializeComponent();



        UpdateSpan(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density);

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
