using JanRoosAutoVerhuur.Viewmodel;

namespace JanRoosAutoVerhuur;

public partial class Terms : ContentPage
{
    private readonly MainViewModel _viewModel;

    public Terms()
    {
        InitializeComponent();

        _viewModel = new MainViewModel();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadCarsAsync();
    }
}