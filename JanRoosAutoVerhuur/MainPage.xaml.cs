using JanRoosAutoVerhuur.Viewmodel;

namespace JanRoosAutoVerhuur
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            BindingContext = _viewModel;
        }

        private void FilterPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadCarsAsync();
        }
    }
}
