using JanRoosAutoVerhuur.Models;

namespace JanRoosAutoVerhuur;

public partial class Kaartje : ContentView
{
    public event EventHandler<Car> CardTapped;

    public Kaartje()
    {
        InitializeComponent();

        var tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) =>
        {
            if (BindingContext is Car car)
                CardTapped?.Invoke(this, car);
        };

        GestureRecognizers.Add(tap);
    }
}