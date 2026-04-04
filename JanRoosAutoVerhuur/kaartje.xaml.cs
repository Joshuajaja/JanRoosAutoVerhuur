using JanRoosAutoVerhuur.Models;
using JanRoosAutoVerhuur.Viewmodel;
using System.Windows.Input;

namespace JanRoosAutoVerhuur;

public partial class Kaartje : ContentView
{
    public static readonly BindableProperty TapCommandProperty =
    BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(Kaartje));

    public ICommand TapCommand
    {
        get => (ICommand)GetValue(TapCommandProperty);
        set => SetValue(TapCommandProperty, value);
    }
    public Kaartje()
    {
        InitializeComponent();

        var tap = new TapGestureRecognizer();
        tap.Tapped += (s, e) =>
        {
            if (BindingContext is Car car && TapCommand?.CanExecute(car) == true)
            {
                TapCommand.Execute(car);
            }
        };

        GestureRecognizers.Add(tap);
    }
}