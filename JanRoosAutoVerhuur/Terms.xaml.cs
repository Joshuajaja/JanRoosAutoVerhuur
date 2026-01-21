using JanRoosAutoVerhuur.Models;
using System.Collections.ObjectModel;

namespace JanRoosAutoVerhuur;

public partial class Terms : ContentPage
{
    public ObservableCollection<Car> Cars { get; set; }

    public Terms()
    {
        InitializeComponent();

        Cars = new ObservableCollection<Car>
        {
            new Car
            {
                CarName = "BMW 3 Series",
                DailyRate = "€75 / day",
                CarImage = "bmw.png"
            },
            new Car
            {
                CarName = "Audi A4",
                DailyRate = "€80 / day",
                CarImage = "audi.png"
            }
        };

        BindingContext = this;
    }
}
