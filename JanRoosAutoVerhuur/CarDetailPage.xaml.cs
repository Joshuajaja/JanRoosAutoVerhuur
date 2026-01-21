using JanRoosAutoVerhuur.Models;

namespace JanRoosAutoVerhuur;

public partial class CarDetailPage : ContentPage
{
    public CarDetailPage(Car car)
    {
        InitializeComponent();
        BindingContext = car;
    }
}
