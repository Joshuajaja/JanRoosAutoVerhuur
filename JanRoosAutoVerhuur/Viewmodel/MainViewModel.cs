using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace JanRoosAutoVerhuur.Viewmodel
{
    [QueryProperty(nameof(NameInfoText), "Username")]
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private int name = 0;

        [RelayCommand]
        private void FilterSet()
        {
            Name++;
        }

        [ObservableProperty]
        private string nameInfoText;
    }
}
