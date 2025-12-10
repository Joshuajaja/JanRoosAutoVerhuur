using JanRoosAutoVerhuur.Viewmodel;

namespace JanRoosAutoVerhuur
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void FilterPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
